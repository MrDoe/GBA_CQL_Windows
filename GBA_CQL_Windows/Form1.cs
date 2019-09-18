using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GBA_CQL_Windows
{
    public partial class Form1 : Form
    {
        public bool bInit;
        public Form1()
        {
            InitializeComponent();
        }
        public class Content
        {
            public string contentType { get; set; }
            public string data { get; set; }
        }
        public class JSON_Library
        {
            public string resourceType { get; set; }
            public List<Content> content { get; set; }
            public string url { get; set; }
            public JSON_Library()
            {
                resourceType = "Library";
                content = new List<Content>();
            }
        }
        public class Coding
        {
            public string system { get; set; }
            public string code { get; set; }
        }
        public class Scoring
        {
            public List<Coding> coding { get; set; }
            public Scoring()
            {
                coding = new List<Coding>
                {
                    new Coding { system = "http://terminology.hl7.org/CodeSystem/measure-scoring",
                                 code = "cohort" }
                };
            }
        }
        public class Criteria
        {
            public string expression { get; set; }
            public string language { get; set; }
            public Criteria()
            {
                expression = "InInitialPopulation";
                language = "text/cql";
            }
        }
        public class Code
        {
            public List<Coding> coding { get; set; }
            public Code()
            {
                coding = new List<Coding>
                {
                    new Coding { system = "http://terminology.hl7.org/CodeSystem/measure-population",
                                 code = "initial-population" }
                };
            }
        }
        public class Population
        {
            public Criteria criteria { get; set; }
            public Code code { get; set; }
            public Population()
            {
                criteria = new Criteria();
                code = new Code();
            }
        }
        public class Group
        {
            public List<Population> population { get; set; }
            public Group()
            {
                population = new List<Population> { new Population() };
            }
        }
        public class SubjectCodeableConcept
        {
            public List<Coding> coding;
            public SubjectCodeableConcept(string sType)
            {
                coding = new List<Coding> { new Coding { system = "http://hl7.org/fhir/resource-types",
                                                         code = sType }};
            }
        }
        public class JSON_Measure
        {
            public string url { get; set; }
            public Scoring scoring { get; set; }
            public List<Group> group { get; set; }
            public string status { get; set; }
            public List<string> library { get; set; }
            public string resourceType { get; set; }
            public SubjectCodeableConcept subjectCodeableConcept { get; set; }
            public JSON_Measure(string sType)
            {
                scoring = new Scoring();
                group = new List<Group> { new Group() };
                status = "active";
                resourceType = "Measure";
                subjectCodeableConcept = new SubjectCodeableConcept(sType);
            }
        }
        public class JSON_Requests
        {
            public string sMeaID { get; set; }
            public string sJSON_Lib { get; set; }
            public string sJSON_Mea { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!bInit)
            {
                txtCQL.Text = "library Retrieve\r\nusing FHIR version '4.0.0'\r\ninclude FHIRHelpers version '4.0.0'\r\n\r\ncontext Patient\r\n\r\ndefine InInitialPopulation:\r\n  Patient.gender = 'male'\r\n";
                bInit = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            ProcessData(txtCQL.Text);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private List<string> CreateLibrary(string b64Input)
        {
            string uuid_lib = System.Guid.NewGuid().ToString();

            // set content
            Content cCQL = new Content { contentType = "text/cql", data = b64Input };

            // create json library object
            JSON_Library oJson = new JSON_Library
            {
                content = { cCQL },
                url = "urn:uuid:" + uuid_lib
            };

            return new List<string> { uuid_lib, JsonConvert.SerializeObject(oJson, Formatting.Indented) };
        }
        private string CreateMeasure(string uuid_lib)
        {
            string sType = (string)ddlResourceType.SelectedValue;

            // create json measure object
            JSON_Measure oJson = new JSON_Measure(sType)
            {
                url = "urn:uuid:" + System.Guid.NewGuid().ToString(),
                library = new List<string> { "urn:uuid:" + uuid_lib }
            };

            return JsonConvert.SerializeObject(oJson, Formatting.Indented);
        }
        private void ProcessData(string input)
        {
            JSON_Requests requests = new JSON_Requests();

            // convert to base64
            var bInput = System.Text.Encoding.UTF8.GetBytes(input);
            string b64Input = System.Convert.ToBase64String(bInput);

            // create library
            List<string> aReturn = CreateLibrary(b64Input);
            string uuid_lib = aReturn[0];
            requests.sJSON_Lib = aReturn[1];

            // post to server
            SendRequest(requests.sJSON_Lib, "Library");

            // create measure
            requests.sJSON_Mea = CreateMeasure(uuid_lib);

            // post to server
            string sResponse = SendRequest(requests.sJSON_Mea, "Measure");

            if (sResponse == "-1")
            {
                MessageBox.Show("Fehler", "Keine Antwort vom Server!");
                return;
            }

            // retrieve response id
            JObject oMea = JObject.Parse(@sResponse);
            string uuid_mea = (string)oMea.SelectToken(".id");
            requests.sMeaID = uuid_mea;

            // send get request to evaluate measure
            sResponse = SendRequest(null, "Measure/" + requests.sMeaID + "/$evaluate-measure?periodStart=2000&periodEnd=2099");

            // beautify and print JSON output
            txtOutput.Text = JValue.Parse(sResponse).ToString(Formatting.Indented);
        }
        private string SendRequest(string sJSON, string sType)
        {
            var client = new RestClient(ddlServer.Text + "/" + sType);
            var request = new RestRequest();

            if (sJSON == null)
                request.Method = Method.GET;
            else
                request.Method = Method.POST;

            request.AddHeader("content-type", "application/fhir+json");
            request.Parameters.Clear();
            request.AddParameter("application/fhir+json", sJSON, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.Content.Length > 0)
                return response.Content;
            else
                return "-1"; // no response
        }
        protected void txtCQL_TextChanged(object sender, EventArgs e)
        {
            if (txtCQL.Text.Contains("context Patient"))
                ddlResourceType.Text = "Patient";
            else if (txtCQL.Text.Contains("context Specimen"))
                ddlResourceType.Text = "Specimen";
            else if (txtCQL.Text.Contains("codesystem icd10"))
                ddlResourceType.Text = "Condition";
        }
    }
}
