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

            // 다형성: List<Table>을 순회하며 각 객체(Two, Four, Six)에 접근
            foreach (Table table in DataManager.Tables)
            {
                Button btnTable = new Button();
                btnTable.Tag = table; // 버튼에 Table 객체 정보 저장

                // 다형성: table.Capacity가 하위 클래스의 값을 따름
                btnTable.Text = $"[{table.Capacity}인석]\n{table.TableNumber}번";

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
            ReservationForm resForm = new ReservationForm(); // 기본 생성자
            if (resForm.ShowDialog() == DialogResult.OK)
            {
                RefreshTableLayout(); // 배정 완료 후 새로고침
            }
        }

        // '현재 손님 목록' 버튼 클릭
        private void btnShowList_Click(object sender, EventArgs e)
        {
            ActiveReservationListForm listForm = new ActiveReservationListForm();
            listForm.ShowDialog(); // Show() 대신 ShowDialog() 사용 권장
        }
    }
}
