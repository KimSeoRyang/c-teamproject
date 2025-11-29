namespace TeamProjectFinal
{
    partial class MainForm
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
            btnNewReservation = new Button();
            btnShowList = new Button();
            flpTables = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewReservation
            // 
            btnNewReservation.BackColor = Color.Blue;
            btnNewReservation.FlatStyle = FlatStyle.Flat;
            btnNewReservation.Font = new Font("Noto Sans KR", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnNewReservation.ForeColor = SystemColors.Control;
            btnNewReservation.Location = new Point(562, 21);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(107, 33);
            btnNewReservation.TabIndex = 0;
            btnNewReservation.Text = "신규 손님 배정";
            btnNewReservation.UseVisualStyleBackColor = false;
            btnNewReservation.Click += btnNewReservation_Click;
            // 
            // btnShowList
            // 
            btnShowList.BackColor = Color.SeaGreen;
            btnShowList.FlatStyle = FlatStyle.Flat;
            btnShowList.Font = new Font("Noto Sans KR", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnShowList.ForeColor = SystemColors.Control;
            btnShowList.Location = new Point(678, 21);
            btnShowList.Name = "btnShowList";
            btnShowList.Size = new Size(109, 33);
            btnShowList.TabIndex = 1;
            btnShowList.Text = "현재 손님 목록";
            btnShowList.UseVisualStyleBackColor = false;
            btnShowList.Click += btnShowList_Click;
            // 
            // flpTables
            // 
            flpTables.Location = new Point(45, 133);
            flpTables.Name = "flpTables";
            flpTables.Size = new Size(696, 265);
            flpTables.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnNewReservation);
            panel1.Controls.Add(btnShowList);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 77);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans KR", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = SystemColors.Control;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(45, 21);
            label1.Name = "label1";
            label1.Size = new Size(266, 39);
            label1.TabIndex = 2;
            label1.Text = "식당 좌석 배정 시스템";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(flpTables);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewReservation;
        private Button btnShowList;
        private FlowLayoutPanel flpTables;
        private Panel panel1;
        private Label label1;
    }
}