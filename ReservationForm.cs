using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TeamProjectFinal
{
    public partial class ReservationForm : Form
    {
        // 특정 테이블을 지정하고 들어온 경우 사용
        private Table specificTable = null;

        // 생성자 1: (MainForm에서 '신규 손님 배정' 버튼 클릭 시)
        public ReservationForm()
        {
            InitializeComponent();
            numGuestCount.ValueChanged += numGuestCount_ValueChanged;
            LoadAvailableTables();
        }

        // 생성자 2: (MainForm에서 '빈 좌석' 버튼 클릭 시)
        public ReservationForm(Table table)
        {
            InitializeComponent();
            this.specificTable = table;

            // 특정 테이블이 정해졌으므로 컨트롤 잠금
            numGuestCount.Value = table.Capacity; // 인원수를 테이블 용량으로 설정
            numGuestCount.Enabled = false;

            // 콤보박스에 해당 테이블만 표시
            cmbAvailableTables.Items.Add(table.TableDescription); // TableDescription 속성 사용
            cmbAvailableTables.SelectedIndex = 0;
            cmbAvailableTables.Enabled = false;
        }

        // (생성자 1 전용) 인원수가 바뀔 때마다 콤보박스 갱신
        private void numGuestCount_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableTables();
        }

        // (생성자 1 전용) 배정 가능한 테이블 목록을 콤보박스에 로드
        private void LoadAvailableTables()
        {
            int guests = (int)numGuestCount.Value;

            // 다형성: GetAvailableTables는 List<Table>을 반환
            List<Table> tables = DataManager.GetAvailableTables(guests);

            cmbAvailableTables.DataSource = null;
            cmbAvailableTables.DataSource = tables; // 데이터 소스로 리스트 바인딩

            // Table.TableDescription 속성을 콤보박스에 표시
            cmbAvailableTables.DisplayMember = "TableDescription";
        }

        // '배정하기' 버튼 클릭
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int guests = (int)numGuestCount.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("손님 이름을 입력하세요.");
                return;
            }

            int tableNumToAssign;

            if (specificTable != null)
            {
                // 생성자 2로 진입한 경우
                tableNumToAssign = specificTable.TableNumber;
            }
            else
            {
                // 생성자 1로 진입한 경우, 콤보박스에서 선택된 테이블 확인
                Table selectedTable = (Table)cmbAvailableTables.SelectedItem;
                if (selectedTable == null)
                {
                    MessageBox.Show("배정할 좌석을 선택하세요.");
                    return;
                }
                tableNumToAssign = selectedTable.TableNumber;
            }

            // 데이터 매니저를 통해 예약 생성
            DataManager.CreateReservation(name, txtPhone.Text, guests, tableNumToAssign);

            this.DialogResult = DialogResult.OK; // MainForm에 성공 알림
            this.Close();
        }
    }
}
