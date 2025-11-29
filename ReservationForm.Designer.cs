namespace TeamProjectFinal
{
    partial class ReservationForm
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
            txtName = new TextBox();
            txtPhone = new TextBox();
            name = new Label();
            phone = new Label();
            guestCount = new Label();
            availableTables = new Label();
            numGuestCount = new NumericUpDown();
            cmbAvailableTables = new ComboBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numGuestCount).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.Location = new Point(12, 84);
            txtName.Name = "txtName";
            txtName.Size = new Size(543, 23);
            txtName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(12, 173);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(543, 23);
            txtPhone.TabIndex = 1;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(12, 45);
            name.Name = "name";
            name.Size = new Size(38, 15);
            name.TabIndex = 2;
            name.Text = "이름: ";
            // 
            // phone
            // 
            phone.AutoSize = true;
            phone.Location = new Point(12, 134);
            phone.Name = "phone";
            phone.Size = new Size(50, 15);
            phone.TabIndex = 3;
            phone.Text = "연락처: ";
            // 
            // guestCount
            // 
            guestCount.AutoSize = true;
            guestCount.Location = new Point(12, 225);
            guestCount.Name = "guestCount";
            guestCount.Size = new Size(50, 15);
            guestCount.TabIndex = 4;
            guestCount.Text = "인원수: ";
            // 
            // availableTables
            // 
            availableTables.AutoSize = true;
            availableTables.Location = new Point(12, 328);
            availableTables.Name = "availableTables";
            availableTables.Size = new Size(94, 15);
            availableTables.TabIndex = 5;
            availableTables.Text = "배정 가능 좌석: ";
            // 
            // numGuestCount
            // 
            numGuestCount.Location = new Point(12, 275);
            numGuestCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numGuestCount.Name = "numGuestCount";
            numGuestCount.Size = new Size(109, 23);
            numGuestCount.TabIndex = 6;
            numGuestCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbAvailableTables
            // 
            cmbAvailableTables.FormattingEnabled = true;
            cmbAvailableTables.Location = new Point(12, 377);
            cmbAvailableTables.Name = "cmbAvailableTables";
            cmbAvailableTables.Size = new Size(543, 23);
            cmbAvailableTables.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(252, 475);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "배정하기";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(570, 510);
            Controls.Add(btnSave);
            Controls.Add(cmbAvailableTables);
            Controls.Add(numGuestCount);
            Controls.Add(availableTables);
            Controls.Add(guestCount);
            Controls.Add(phone);
            Controls.Add(name);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Name = "ReservationForm";
            Text = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)numGuestCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPhone;
        private Label name;
        private Label phone;
        private Label guestCount;
        private Label availableTables;
        private NumericUpDown numGuestCount;
        private ComboBox cmbAvailableTables;
        private Button btnSave;
    }
}