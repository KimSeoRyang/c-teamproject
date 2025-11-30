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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 프로그램 시작 시 데이터 로드
            DataManager.InitializeTables();
            DataManager.LoadReservations();
            RefreshTableLayout();
        }

        // 테이블 좌석 배치도를 새로고침하는 메소드
        private void RefreshTableLayout()
        {
            flpTables.Controls.Clear(); // 기존 버튼 모두 제거
            DataManager.UpdateTableStatus(); // 데이터 동기화

            // [안전 장치 추가] 예약 리스트가 아직 로드되지 않았다면 빈 리스트로 간주
            var currentReservations = DataManager.Reservations ?? new List<Reservation>();

            // 다형성: List<Table>을 순회하며 각 객체(Two, Four, Six)에 접근
            foreach (Table table in DataManager.Tables)
            {
                Button btnTable = new Button();
                btnTable.Tag = table; // 버튼에 Table 객체 정보 저장

                // 다형성: table.Capacity가 하위 클래스의 값을 따름
                //btnTable.Text = $"[{table.Capacity}인석]\n{table.TableNumber}번";
                if (table.IsReserved)
                {
                    // 1. 현재 이 테이블(table.TableNumber)을 누가 예약했는지 찾습니다.
                    // (DataManager.Reservations 리스트에서 검색)
                    //var reservation = DataManager.Reservations
                    //.FirstOrDefault(r => r.AssignedTableNumber == table.TableNumber);
                    var reservation = currentReservations
                        .FirstOrDefault(r => r.AssignedTableNumber == table.TableNumber);

                    // 2. 예약 정보를 찾았다면 이름과 인원수를 표시합니다.
                    if (reservation != null)
                    {
                        btnTable.Text = $"{table.TableNumber}번\n{reservation.CustomerName} 님\n({reservation.GuestCount}명)";
                        btnTable.BackColor = Color.Salmon; // 예약된 색상
                    }
                }
                else
                {
                    // 3. 예약이 없다면 기존처럼 테이블 정보를 표시합니다.
                    btnTable.Text = $"{table.TableNumber}번\n[{table.Capacity}인석]";
                    btnTable.BackColor = Color.LightGreen; // 빈 좌석 색상
                }

                btnTable.Width = 100;
                btnTable.Height = 80;
                btnTable.Margin = new Padding(10);

                // 공통 속성(IsReserved)을 사용하여 색상 결정
                if (table.IsReserved)
                {
                    btnTable.BackColor = Color.Salmon; // 사용중 (빨간색)
                }
                else
                {
                    btnTable.BackColor = Color.LightGreen; // 빈 좌석 (녹색)
                }

                btnTable.Click += TableButton_Click; // 공통 클릭 이벤트 핸들러
                flpTables.Controls.Add(btnTable);
            }
        }

        // 테이블 버튼 클릭 이벤트 (빈 좌석 / 사용중 좌석 처리)
        private void TableButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Table table = (Table)clickedButton.Tag; // 저장했던 Table 객체 복원

            if (table.IsReserved)
            {
                // 사용 중인 테이블 클릭 -> 퇴실 처리
                string msg = $"{table.TableNumber}번 테이블({table.Capacity}인석) 손님을 퇴실 처리합니다.";
                if (MessageBox.Show(msg, "퇴실 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataManager.EndReservation(table.TableNumber);
                    RefreshTableLayout(); // 화면 새로고침
                }
            }
            else
            {
                // 빈 테이블 클릭 -> 해당 테이블로 바로 예약 폼 열기
                ReservationForm resForm = new ReservationForm(table); // 생성자 오버로딩
                if (resForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshTableLayout(); // 배정 완료 후 새로고침
                }
            }
        }

        // '신규 손님 배정' 버튼 클릭 (특정 테이블 지정 안 함)
        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            // 💡 1. 빈 테이블 확인: 1인 이상 앉을 수 있는 테이블이 있는지 확인
            bool hasAvailableTable = DataManager.Tables.Any(t => !t.IsReserved && t.Capacity >= 1);

            if (hasAvailableTable)
            {
                // 💡 2. 빈 테이블이 있으면: ReservationForm을 열어 좌석을 선택하게 함
                ReservationForm resForm = new ReservationForm();
                if (resForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshTableLayout(); // 배정 완료 후 새로고침
                }
            }
            else
            {
                // 💡 3. 만석이면: WaitingRegistrationForm을 열어 대기열에 등록하게 함
                MessageBox.Show("현재 모든 테이블이 사용 중입니다. 대기열에 등록합니다.", "만석", MessageBoxButtons.OK, MessageBoxIcon.Information);

                WaitingRegistrationForm waitingForm = new WaitingRegistrationForm();
                if (waitingForm.ShowDialog() == DialogResult.OK)
                {
                    // 대기열 등록 후에도 화면을 갱신할 필요는 없지만, 리스트 확인을 위해 한 번 갱신
                    // (대기열 등록은 메인 화면에 반영되지 않으므로, 굳이 RefreshTableLayout()은 필요 없습니다.)
                }
            }
        }

        // '현재 손님 목록' 버튼 클릭
        // [수정] 이미 열려있는 창이 있는지 확인
        private void btnShowList_Click(object sender, EventArgs e)
        {
            // 이미 열려있는 창이 있는지 찾습니다.
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is ActiveReservationListForm)
                {
                    openForm.Activate(); // 이미 있으면 그 창을 맨 앞으로 가져옴
                    return;
                }
            }

            // 없으면 새로 만들어서 엽니다.
            DataManager.LoadReservations();
            ActiveReservationListForm listForm = new ActiveReservationListForm();
            listForm.Show();
        }
    }
}
