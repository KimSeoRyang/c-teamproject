namespace TeamProjectFinal
{
    partial class ActiveReservationListForm
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
            dgvActiveList = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvActiveList).BeginInit();
            SuspendLayout();
            // 
            // dgvActiveList
            // 
            dgvActiveList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveList.Location = new Point(51, 60);
            dgvActiveList.Name = "dgvActiveList";
            dgvActiveList.Size = new Size(655, 326);
            dgvActiveList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(610, 31);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "button1";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ActiveReservationListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(dgvActiveList);
            Name = "ActiveReservationListForm";
            Text = "ActiveReservationListForm";
            ((System.ComponentModel.ISupportInitialize)dgvActiveList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvActiveList;
        private Button btnRefresh;
    }
}