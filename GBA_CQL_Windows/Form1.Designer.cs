namespace GBA_CQL_Windows
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlServer = new System.Windows.Forms.ComboBox();
            this.ddlResourceType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCQL = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CQL-Abfrage:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(14, 295);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(71, 28);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Absenden";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 339);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Antwort:";
            // 
            // ddlServer
            // 
            this.ddlServer.FormattingEnabled = true;
            this.ddlServer.Items.AddRange(new object[] {
            "https://blaze.life.uni-leipzig.de/fhir"});
            this.ddlServer.Location = new System.Drawing.Point(58, 10);
            this.ddlServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlServer.Name = "ddlServer";
            this.ddlServer.Size = new System.Drawing.Size(210, 21);
            this.ddlServer.TabIndex = 6;
            this.ddlServer.Text = "https://blaze.life.uni-leipzig.de/fhir";
            // 
            // ddlResourceType
            // 
            this.ddlResourceType.FormattingEnabled = true;
            this.ddlResourceType.Items.AddRange(new object[] {
            "Patient",
            "Specimen",
            "Observation",
            "Condition"});
            this.ddlResourceType.Location = new System.Drawing.Point(100, 262);
            this.ddlResourceType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlResourceType.Name = "ddlResourceType";
            this.ddlResourceType.Size = new System.Drawing.Size(120, 21);
            this.ddlResourceType.TabIndex = 7;
            this.ddlResourceType.Text = "Patient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "FHIR Resource:";
            // 
            // txtCQL
            // 
            this.txtCQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCQL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCQL.Location = new System.Drawing.Point(16, 57);
            this.txtCQL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCQL.Name = "txtCQL";
            this.txtCQL.Size = new System.Drawing.Size(686, 200);
            this.txtCQL.TabIndex = 9;
            this.txtCQL.Text = "";
            this.txtCQL.TextChanged += new System.EventHandler(this.txtCQL_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(14, 356);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(686, 326);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 693);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtCQL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlResourceType);
            this.Controls.Add(this.ddlServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "GBA CQL Query Tool";
            this.Load += new System.EventHandler(this.Page_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlServer;
        private System.Windows.Forms.ComboBox ddlResourceType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtCQL;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

