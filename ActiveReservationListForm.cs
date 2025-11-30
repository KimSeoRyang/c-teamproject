using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjectFinal
{
    public partial class ActiveReservationListForm : Form
    {
        // [중요] 그리드뷰와 실제 데이터 사이의 '완충제' 역할 (오류 방지)
        private BindingSource activeSource = new BindingSource();
        private BindingSource waitingSource = new BindingSource();

        public ActiveReservationListForm()
        {
            InitializeComponent();
        }

        private void ActiveReservationListForm_Load(object sender, EventArgs e)
        {
            // 1. 시작할 때 그리드뷰에 BindingSource를 미리 연결합니다.
            dgvActiveList.DataSource = activeSource;
            dgvWaitingList.DataSource = waitingSource;

            // 2. 데이터를 불러옵니다.
            LoadList();

            // 3. 컬럼 디자인 설정 (데이터가 로드된 후 설정하는 것이 안전)
            SetColumnHeaders();
        }

        // [핵심 기능] 새로고침 버튼 클릭 시 동작
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 메인 화면에서 변경된 내용이 파일에 저장되었을 테니, 
            // 파일을 다시 읽어와서 화면을 갱신합니다.
            LoadList();
        }

        private void LoadList()
        {
            // 1. 파일에서 최신 데이터를 다시 읽어옵니다. (MainForm에서의 변경 사항 반영)
            DataManager.LoadReservations();
            DataManager.LoadWaitingList();

            // 2. BindingSource의 데이터 원본을 최신 리스트로 교체합니다.
            // (DataSource = null을 하지 않으므로 오류가 발생하지 않습니다)
            activeSource.DataSource = DataManager.Reservations.ToList();
            waitingSource.DataSource = DataManager.WaitingList.ToList();

            // 3. 그리드뷰에게 데이터가 바뀌었으니 다시 그리라고 알립니다.
            activeSource.ResetBindings(false);
            waitingSource.ResetBindings(false);
        }

        private void SetColumnHeaders()
        {   // 예약 목록 컬럼 설정
            if (dgvActiveList.Columns.Count != 0)
            {
                dgvActiveList.Columns["CustomerName"].HeaderText = "손님 이름";
                dgvActiveList.Columns["GuestCount"].HeaderText = "인원수";
                dgvActiveList.Columns["TableInfo"].HeaderText = "테이블";
                dgvActiveList.Columns["SeatedAtTime"].HeaderText = "착석 시간";
                dgvActiveList.Columns["SeatedAtTime"].DefaultCellStyle.Format = "tt h:mm";

                dgvActiveList.Columns["ReservationId"].Visible = false;
                dgvActiveList.Columns["PhoneNumber"].Visible = false;
                dgvActiveList.Columns["AssignedTableNumber"].Visible = false;
                dgvActiveList.Columns["IsWaiting"].Visible = false;
            }

            // 대기열 목록 컬럼 설정
            if (dgvWaitingList.Columns.Count != 0)
            {
                dgvWaitingList.Columns["CustomerName"].HeaderText = "손님 이름";
                dgvWaitingList.Columns["GuestCount"].HeaderText = "인원수";
                dgvWaitingList.Columns["SeatedAtTime"].HeaderText = "대기 등록 시간";
                dgvWaitingList.Columns["SeatedAtTime"].DefaultCellStyle.Format = "tt h:mm";

                dgvWaitingList.Columns["TableInfo"].Visible = false;
                dgvWaitingList.Columns["ReservationId"].Visible = false;
                dgvWaitingList.Columns["PhoneNumber"].Visible = false;
                dgvWaitingList.Columns["AssignedTableNumber"].Visible = false;
                dgvWaitingList.Columns["IsWaiting"].Visible = false;
            }
        }
    }
}