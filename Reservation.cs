using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectFinal
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int GuestCount { get; set; }
        public int AssignedTableNumber { get; set; } // 필수
        public DateTime SeatedAtTime { get; set; } // 배정된 시간

        public bool IsWaiting { get; set; } = false;

        // GridView 표시용 (읽기 전용 속성)
        public string TableInfo { get { return $"{AssignedTableNumber}번"; } }
    }
}
