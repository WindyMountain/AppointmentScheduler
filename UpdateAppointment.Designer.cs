namespace WendyMonahanC969
{
    partial class UpdateAppointment
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
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.endAMPM = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.endTimeZone = new System.Windows.Forms.Label();
            this.endDropDownMin = new System.Windows.Forms.ComboBox();
            this.endDropDownHour = new System.Windows.Forms.ComboBox();
            this.startAMPM = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.startTimeZone = new System.Windows.Forms.Label();
            this.startDropDownMin = new System.Windows.Forms.ComboBox();
            this.startDropDownHour = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 41);
            this.label2.TabIndex = 33;
            this.label2.Text = "Update Appointment";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(254, 659);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(96, 40);
            this.cancelBtn.TabIndex = 74;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.updateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(144, 659);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(96, 40);
            this.updateBtn.TabIndex = 73;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click_1);
            // 
            // endAMPM
            // 
            this.endAMPM.FormattingEnabled = true;
            this.endAMPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.endAMPM.Location = new System.Drawing.Point(239, 612);
            this.endAMPM.MaxDropDownItems = 24;
            this.endAMPM.Name = "endAMPM";
            this.endAMPM.Size = new System.Drawing.Size(41, 21);
            this.endAMPM.TabIndex = 72;
            this.endAMPM.Text = "AM";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(179, 600);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 37);
            this.label13.TabIndex = 71;
            this.label13.Text = ":";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endTimeZone
            // 
            this.endTimeZone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimeZone.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endTimeZone.Location = new System.Drawing.Point(286, 612);
            this.endTimeZone.Name = "endTimeZone";
            this.endTimeZone.Size = new System.Drawing.Size(63, 21);
            this.endTimeZone.TabIndex = 70;
            this.endTimeZone.Text = "ABC";
            this.endTimeZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endDropDownMin
            // 
            this.endDropDownMin.FormattingEnabled = true;
            this.endDropDownMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.endDropDownMin.Location = new System.Drawing.Point(197, 612);
            this.endDropDownMin.MaxDropDownItems = 24;
            this.endDropDownMin.Name = "endDropDownMin";
            this.endDropDownMin.Size = new System.Drawing.Size(36, 21);
            this.endDropDownMin.TabIndex = 69;
            this.endDropDownMin.Text = "00";
            // 
            // endDropDownHour
            // 
            this.endDropDownHour.FormattingEnabled = true;
            this.endDropDownHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.endDropDownHour.Location = new System.Drawing.Point(144, 612);
            this.endDropDownHour.MaxDropDownItems = 24;
            this.endDropDownHour.Name = "endDropDownHour";
            this.endDropDownHour.Size = new System.Drawing.Size(38, 21);
            this.endDropDownHour.TabIndex = 68;
            this.endDropDownHour.Text = "12";
            // 
            // startAMPM
            // 
            this.startAMPM.FormattingEnabled = true;
            this.startAMPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.startAMPM.Location = new System.Drawing.Point(239, 577);
            this.startAMPM.MaxDropDownItems = 24;
            this.startAMPM.Name = "startAMPM";
            this.startAMPM.Size = new System.Drawing.Size(41, 21);
            this.startAMPM.TabIndex = 67;
            this.startAMPM.Text = "AM";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(179, 565);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 37);
            this.label12.TabIndex = 66;
            this.label12.Text = ":";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startTimeZone
            // 
            this.startTimeZone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeZone.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startTimeZone.Location = new System.Drawing.Point(286, 577);
            this.startTimeZone.Name = "startTimeZone";
            this.startTimeZone.Size = new System.Drawing.Size(63, 21);
            this.startTimeZone.TabIndex = 65;
            this.startTimeZone.Text = "ABC";
            this.startTimeZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startDropDownMin
            // 
            this.startDropDownMin.FormattingEnabled = true;
            this.startDropDownMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.startDropDownMin.Location = new System.Drawing.Point(197, 577);
            this.startDropDownMin.MaxDropDownItems = 24;
            this.startDropDownMin.Name = "startDropDownMin";
            this.startDropDownMin.Size = new System.Drawing.Size(36, 21);
            this.startDropDownMin.TabIndex = 64;
            this.startDropDownMin.Text = "00";
            // 
            // startDropDownHour
            // 
            this.startDropDownHour.FormattingEnabled = true;
            this.startDropDownHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.startDropDownHour.Location = new System.Drawing.Point(144, 577);
            this.startDropDownHour.MaxDropDownItems = 24;
            this.startDropDownHour.Name = "startDropDownHour";
            this.startDropDownHour.Size = new System.Drawing.Size(38, 21);
            this.startDropDownHour.TabIndex = 63;
            this.startDropDownHour.Text = "12";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(6, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 37);
            this.label11.TabIndex = 62;
            this.label11.Text = "Date:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "yyyy-MM-dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(144, 537);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(104, 20);
            this.datePicker.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(6, 568);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 37);
            this.label8.TabIndex = 60;
            this.label8.Text = "Start Time:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(6, 603);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 37);
            this.label9.TabIndex = 59;
            this.label9.Text = "End Time:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(6, 486);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 37);
            this.label10.TabIndex = 58;
            this.label10.Text = "URL:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(144, 498);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(282, 20);
            this.urlTextBox.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(6, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 37);
            this.label6.TabIndex = 56;
            this.label6.Text = "Contact:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(6, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 37);
            this.label7.TabIndex = 55;
            this.label7.Text = "Type:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(144, 457);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(282, 20);
            this.typeTextBox.TabIndex = 54;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Location = new System.Drawing.Point(144, 414);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(282, 20);
            this.contactTextBox.TabIndex = 53;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(144, 171);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(287, 174);
            this.descriptionTextBox.TabIndex = 52;
            this.descriptionTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(11, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 37);
            this.label4.TabIndex = 51;
            this.label4.Text = "Description:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(6, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 37);
            this.label5.TabIndex = 50;
            this.label5.Text = "Location:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(144, 372);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(282, 20);
            this.locationTextBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 37);
            this.label1.TabIndex = 48;
            this.label1.Text = "Customer ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 37);
            this.label3.TabIndex = 47;
            this.label3.Text = "Title:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(149, 125);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(282, 20);
            this.titleTextBox.TabIndex = 46;
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.Location = new System.Drawing.Point(149, 82);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.Size = new System.Drawing.Size(282, 20);
            this.customerIDTextBox.TabIndex = 45;
            // 
            // UpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(453, 750);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.endAMPM);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.endTimeZone);
            this.Controls.Add(this.endDropDownMin);
            this.Controls.Add(this.endDropDownHour);
            this.Controls.Add(this.startAMPM);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.startTimeZone);
            this.Controls.Add(this.startDropDownMin);
            this.Controls.Add(this.startDropDownHour);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.customerIDTextBox);
            this.Controls.Add(this.label2);
            this.Name = "UpdateAppointment";
            this.Text = "UpdateAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ComboBox endAMPM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label endTimeZone;
        private System.Windows.Forms.ComboBox endDropDownMin;
        private System.Windows.Forms.ComboBox endDropDownHour;
        private System.Windows.Forms.ComboBox startAMPM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label startTimeZone;
        private System.Windows.Forms.ComboBox startDropDownMin;
        private System.Windows.Forms.ComboBox startDropDownHour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox customerIDTextBox;
    }
}