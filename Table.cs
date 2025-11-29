using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectFinal
{
    // 1. 추상 클래스 (abstract class)
    public abstract class Table
    {
        // 공통 속성
        public int TableNumber { get; set; }
        public int Capacity { get; protected set; } // 하위 클래스에서만 설정
        public bool IsReserved { get; set; }

        // 콤보박스 표시에 사용할 속성 (다형성을 통해 하위 클래스의 Capacity가 반영됨)
        public string TableDescription
        {
            get { return $"[{Capacity}인석] {TableNumber}번"; }
        }

        // 생성자
        public Table(int tableNumber)
        {
            this.TableNumber = tableNumber;
            this.IsReserved = false;
        }

        // 2. 추상 메소드 (하위 클래스에서 재정의 필요)
        // 이것이 '메소드 오버라이딩'의 대상이 됩니다.
        public abstract string GetFullStatusInfo();
    }

    // 3. 상속 (Inheritance)
    public class TwoPersonTable : Table
    {
        // 부모 생성자 호출 및 Capacity 설정
        public TwoPersonTable(int tableNumber) : base(tableNumber)
        {
            this.Capacity = 2; // 2인석 설정
        }

        // 4. 메소드 오버라이딩 (Method Overriding)
        public override string GetFullStatusInfo()
        {
            return $"[2인석] {TableNumber}번 (상태: {(IsReserved ? "사용중" : "비어있음")})";
        }
    }
    public class FourPersonTable : Table
    {
        public FourPersonTable(int tableNumber) : base(tableNumber)
        {
            this.Capacity = 4;
        }

        public override string GetFullStatusInfo()
        {
            return $"[4인석] {TableNumber}번 (상태: {(IsReserved ? "사용중" : "비어있음")})";
        }
    }
    public class SixPersonTable : Table
    {
        public SixPersonTable(int tableNumber) : base(tableNumber)
        {
            this.Capacity = 6;
        }

        public override string GetFullStatusInfo()
        {
            return $"[6인석] {TableNumber}번 (상태: {(IsReserved ? "사용중" : "비어있음")})";
        }
    }
}
