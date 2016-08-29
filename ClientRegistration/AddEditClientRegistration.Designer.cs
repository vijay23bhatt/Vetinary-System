namespace AppointmentSystem.ClientRegistration
{
    partial class AddEditClientRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsuburb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.epname = new System.Windows.Forms.ErrorProvider(this.components);
            this.eppassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.epemail = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eppassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epemail)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtlastname);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtpassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtsuburb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtfirstname);
            this.groupBox1.Font = new System.Drawing.Font("Gadugi", 9F);
            this.groupBox1.Location = new System.Drawing.Point(5, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 266);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Registration Detail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label6.Location = new System.Drawing.Point(4, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 520;
            this.label6.Text = "Last Name :";
            // 
            // txtlastname
            // 
            this.txtlastname.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtlastname.Location = new System.Drawing.Point(90, 58);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(356, 25);
            this.txtlastname.TabIndex = 2;
            this.txtlastname.Enter += new System.EventHandler(this.txtlastname_Enter);
            this.txtlastname.Leave += new System.EventHandler(this.txtlastname_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label9.Location = new System.Drawing.Point(9, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 518;
            this.label9.Text = "Password :";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtpassword.Location = new System.Drawing.Point(90, 236);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(149, 25);
            this.txtpassword.TabIndex = 6;
            this.txtpassword.UseSystemPasswordChar = true;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label5.Location = new System.Drawing.Point(35, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 513;
            this.label5.Text = "Email :";
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtemail.Location = new System.Drawing.Point(91, 205);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(356, 25);
            this.txtemail.TabIndex = 5;
            this.txtemail.Enter += new System.EventHandler(this.txtemail_Enter);
            this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label4.Location = new System.Drawing.Point(266, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 511;
            this.label4.Text = "Suburb :";
            // 
            // txtsuburb
            // 
            this.txtsuburb.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtsuburb.Location = new System.Drawing.Point(331, 236);
            this.txtsuburb.MaxLength = 6;
            this.txtsuburb.Name = "txtsuburb";
            this.txtsuburb.Size = new System.Drawing.Size(116, 25);
            this.txtsuburb.TabIndex = 7;
            this.txtsuburb.UseSystemPasswordChar = true;
            this.txtsuburb.Enter += new System.EventHandler(this.txtsuburb_Enter);
            this.txtsuburb.Leave += new System.EventHandler(this.txtsuburb_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label3.Location = new System.Drawing.Point(28, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 509;
            this.label3.Text = "Phone :";
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtphone.Location = new System.Drawing.Point(90, 174);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(159, 25);
            this.txtphone.TabIndex = 4;
            this.txtphone.Enter += new System.EventHandler(this.txtphone_Enter);
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtphone_KeyPress);
            this.txtphone.Leave += new System.EventHandler(this.txtphone_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 505;
            this.label1.Text = "First Name :";
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtaddress.Location = new System.Drawing.Point(90, 92);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(356, 76);
            this.txtaddress.TabIndex = 3;
            this.txtaddress.Enter += new System.EventHandler(this.txtaddress_Enter);
            this.txtaddress.Leave += new System.EventHandler(this.txtaddress_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 10F);
            this.label2.Location = new System.Drawing.Point(18, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 507;
            this.label2.Text = "Address :";
            // 
            // txtfirstname
            // 
            this.txtfirstname.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtfirstname.Location = new System.Drawing.Point(91, 27);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(356, 25);
            this.txtfirstname.TabIndex = 1;
            this.txtfirstname.TextChanged += new System.EventHandler(this.txtfirstname_TextChanged);
            this.txtfirstname.Enter += new System.EventHandler(this.txtname_Enter);
            this.txtfirstname.Leave += new System.EventHandler(this.txtname_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(8, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 36);
            this.panel1.TabIndex = 540;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::AppointmentSystem.Properties.Resources.CLOSE;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(274, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "     &Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epname
            // 
            this.epname.ContainerControl = this;
            // 
            // eppassword
            // 
            this.eppassword.ContainerControl = this;
            // 
            // epemail
            // 
            this.epemail.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::AppointmentSystem.Properties.Resources.SAVEORG;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(112, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "     &Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.BackgroundImage = global::AppointmentSystem.Properties.Resources.TITLEBACKGROUND;
            this.pnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(507, 80);
            this.pnlTitle.TabIndex = 541;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gadugi", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTitle.Location = new System.Drawing.Point(111, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Client Registration";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::AppointmentSystem.Properties.Resources.CLEAR;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(193, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 31);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "     C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // AddEditClientRegistration
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(507, 404);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditClientRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditRegistraion";
            this.Load += new System.EventHandler(this.AddEditRegistraion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eppassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epemail)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsuburb;
        private System.Windows.Forms.ErrorProvider epname;
        private System.Windows.Forms.ErrorProvider eppassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.ErrorProvider epemail;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
    }
}