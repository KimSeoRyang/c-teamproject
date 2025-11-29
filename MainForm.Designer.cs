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
            SuspendLayout();
            // 
            // btnNewReservation
            // 
            btnNewReservation.Location = new Point(567, 12);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(107, 33);
            btnNewReservation.TabIndex = 0;
            btnNewReservation.Text = "신규 손님 배정";
            btnNewReservation.UseVisualStyleBackColor = true;
            // 
            // btnShowList
            // 
            btnShowList.Location = new Point(679, 12);
            btnShowList.Name = "btnShowList";
            btnShowList.Size = new Size(109, 33);
            btnShowList.TabIndex = 1;
            btnShowList.Text = "현재 손님 목록";
            btnShowList.UseVisualStyleBackColor = true;
            btnShowList.Click += btnShowList_Click;
            // 
            // flpTables
            // 
            flpTables.Location = new Point(45, 51);
            flpTables.Name = "flpTables";
            flpTables.Size = new Size(696, 347);
            flpTables.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpTables);
            Controls.Add(btnShowList);
            Controls.Add(btnNewReservation);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewReservation;
        private Button btnShowList;
        private FlowLayoutPanel flpTables;
    }
}