namespace WendyMonahanC969
{
    partial class loginScreen
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
            this.usernameText = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTitle = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.Label();
            this.timezoneText = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.englishRadBtn = new System.Windows.Forms.RadioButton();
            this.espanolRadBtn = new System.Windows.Forms.RadioButton();
            this.languageGroup = new System.Windows.Forms.GroupBox();
            this.timezoneText2 = new System.Windows.Forms.Label();
            this.languageGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.usernameText.Location = new System.Drawing.Point(13, 97);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(109, 37);
            this.usernameText.TabIndex = 0;
            this.usernameText.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(128, 103);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(282, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(128, 146);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(282, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // loginTitle
            // 
            this.loginTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.loginTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginTitle.Location = new System.Drawing.Point(12, 9);
            this.loginTitle.Name = "loginTitle";
            this.loginTitle.Size = new System.Drawing.Size(110, 46);
            this.loginTitle.TabIndex = 3;
            this.loginTitle.Text = "Login";
            this.loginTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.passwordText.Location = new System.Drawing.Point(13, 146);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(109, 37);
            this.passwordText.TabIndex = 4;
            this.passwordText.Text = "Password";
            // 
            // timezoneText
            // 
            this.timezoneText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timezoneText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timezoneText.Location = new System.Drawing.Point(133, 9);
            this.timezoneText.Name = "timezoneText";
            this.timezoneText.Size = new System.Drawing.Size(277, 33);
            this.timezoneText.TabIndex = 5;
            this.timezoneText.Text = "Timezone:";
            this.timezoneText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(165, 191);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(96, 40);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(279, 191);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(96, 40);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // englishRadBtn
            // 
            this.englishRadBtn.AutoSize = true;
            this.englishRadBtn.Checked = true;
            this.englishRadBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.englishRadBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.englishRadBtn.Location = new System.Drawing.Point(6, 13);
            this.englishRadBtn.Name = "englishRadBtn";
            this.englishRadBtn.Size = new System.Drawing.Size(79, 25);
            this.englishRadBtn.TabIndex = 0;
            this.englishRadBtn.TabStop = true;
            this.englishRadBtn.Text = "English";
            this.englishRadBtn.UseVisualStyleBackColor = true;
            this.englishRadBtn.CheckedChanged += new System.EventHandler(this.englishRadBtn_CheckedChanged);
            // 
            // espanolRadBtn
            // 
            this.espanolRadBtn.AutoSize = true;
            this.espanolRadBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espanolRadBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.espanolRadBtn.Location = new System.Drawing.Point(6, 44);
            this.espanolRadBtn.Name = "espanolRadBtn";
            this.espanolRadBtn.Size = new System.Drawing.Size(84, 25);
            this.espanolRadBtn.TabIndex = 1;
            this.espanolRadBtn.Text = "Espanol";
            this.espanolRadBtn.UseVisualStyleBackColor = true;
            this.espanolRadBtn.CheckedChanged += new System.EventHandler(this.espanolRadBtn_CheckedChanged);
            // 
            // languageGroup
            // 
            this.languageGroup.Controls.Add(this.englishRadBtn);
            this.languageGroup.Controls.Add(this.espanolRadBtn);
            this.languageGroup.Location = new System.Drawing.Point(420, 9);
            this.languageGroup.Name = "languageGroup";
            this.languageGroup.Size = new System.Drawing.Size(97, 76);
            this.languageGroup.TabIndex = 8;
            this.languageGroup.TabStop = false;
            // 
            // timezoneText2
            // 
            this.timezoneText2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timezoneText2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timezoneText2.Location = new System.Drawing.Point(128, 42);
            this.timezoneText2.Name = "timezoneText2";
            this.timezoneText2.Size = new System.Drawing.Size(282, 33);
            this.timezoneText2.TabIndex = 9;
            this.timezoneText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(529, 265);
            this.Controls.Add(this.timezoneText2);
            this.Controls.Add(this.languageGroup);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.timezoneText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginTitle);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameText);
            this.Name = "loginScreen";
            this.languageGroup.ResumeLayout(false);
            this.languageGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label loginTitle;
        private System.Windows.Forms.Label passwordText;
        private System.Windows.Forms.Label timezoneText;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.RadioButton espanolRadBtn;
        private System.Windows.Forms.RadioButton englishRadBtn;
        private System.Windows.Forms.GroupBox languageGroup;
        private System.Windows.Forms.Label timezoneText2;
    }
}

