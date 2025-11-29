using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjectFinal
{
    public partial class WaitingRegistrationForm : Form
    {
        public WaitingRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnAddToWaiting_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int guests = (int)numGuests.Value;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("손님 이름을 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataManager의 AddToWaitingList 메서드를 호출하여 대기열에 등록
            DataManager.AddToWaitingList(name, phone, guests);

            MessageBox.Show($"{name}님 ({guests}명)이 대기열에 등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}