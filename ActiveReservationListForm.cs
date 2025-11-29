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
    public partial class ActiveReservationListForm : Form
    {
        public ActiveReservationListForm()
        {
            InitializeComponent();
        }

        private void ActiveReservationListForm_Load(object sender, EventArgs e)
        {
            LoadList();
            // (선택적) DataGridView 컬럼 설정
            dgvActiveList.Columns["CustomerName"].HeaderText = "손님 이름";
            dgvActiveList.Columns["GuestCount"].HeaderText = "인원수";
            dgvActiveList.Columns["TableInfo"].HeaderText = "테이블";
            dgvActiveList.Columns["SeatedAtTime"].HeaderText = "착석 시간";
            // 불필요한 컬럼 숨기기
            dgvActiveList.Columns["ReservationId"].Visible = false;
            dgvActiveList.Columns["PhoneNumber"].Visible = false;
            dgvActiveList.Columns["AssignedTableNumber"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            // DataManager의 현재 Reservations 리스트를 그대로 바인딩
            dgvActiveList.DataSource = null;
            dgvActiveList.DataSource = DataManager.Reservations;
        }
    }
}
