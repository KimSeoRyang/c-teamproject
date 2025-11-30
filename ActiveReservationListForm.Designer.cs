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
            this.dgvActiveList = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelActive = new System.Windows.Forms.Label();
            this.dgvWaitingList = new System.Windows.Forms.DataGridView();
            this.labelWaiting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActiveList
            // 
            this.dgvActiveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveList.Location = new System.Drawing.Point(20, 40);
            this.dgvActiveList.Name = "dgvActiveList";
            this.dgvActiveList.ReadOnly = true;
            this.dgvActiveList.RowTemplate.Height = 25;
            this.dgvActiveList.Size = new System.Drawing.Size(760, 200);
            this.dgvActiveList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(685, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 26);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Location = new System.Drawing.Point(20, 15);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(95, 15);
            this.labelActive.TabIndex = 3;
            this.labelActive.Text = "📝 현재 손님 목록";
            // 
            // dgvWaitingList
            // 
            this.dgvWaitingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitingList.Location = new System.Drawing.Point(20, 300);
            this.dgvWaitingList.Name = "dgvWaitingList";
            this.dgvWaitingList.ReadOnly = true;
            this.dgvWaitingList.RowTemplate.Height = 25;
            this.dgvWaitingList.Size = new System.Drawing.Size(760, 200);
            this.dgvWaitingList.TabIndex = 4;
            // 
            // labelWaiting
            // 
            this.labelWaiting.AutoSize = true;
            this.labelWaiting.Location = new System.Drawing.Point(20, 275);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(83, 15);
            this.labelWaiting.TabIndex = 5;
            this.labelWaiting.Text = "⌛ 대기열 목록";
            // 
            // ActiveReservationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.labelWaiting);
            this.Controls.Add(this.dgvWaitingList);
            this.Controls.Add(this.labelActive);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvActiveList);
            this.Name = "ActiveReservationListForm";
            this.Text = "현재 손님 및 대기열 목록";
            this.Load += new System.EventHandler(this.ActiveReservationListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActiveList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.DataGridView dgvWaitingList;
        private System.Windows.Forms.Label labelWaiting;
    }
}