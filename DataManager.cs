using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TeamProjectFinal
{
    public static class DataManager
    {
        private static string reservationFile = "reservations.json";
        private static string waitingFile = "waitinglist.json";

        // 리스트 초기화 (Null 방지)
        public static List<Reservation> Reservations { get; private set; } = new List<Reservation>();
        public static List<Table> Tables { get; private set; } = new List<Table>();
        public static List<Reservation> WaitingList { get; private set; } = new List<Reservation>();

        // 1. 테이블 리스트 초기화
        public static void InitializeTables()
        {
            Tables = new List<Table>
            {
                new TwoPersonTable(1),
                new TwoPersonTable(2),
                new FourPersonTable(3),
                new FourPersonTable(4),
                new FourPersonTable(5),
                new SixPersonTable(6)
            };
        }

        // 2. 예약 정보 불러오기
        public static void LoadReservations()
        {
            if (!File.Exists(reservationFile)) return;
            try
            {
                string json = File.ReadAllText(reservationFile);
                Reservations = JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
            }
            catch { Reservations = new List<Reservation>(); }
            UpdateTableStatus();
        }

        // 3. 예약 정보 저장하기
        public static void SaveReservations()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Reservations, options);
            File.WriteAllText(reservationFile, json);
        }

        // 4. 대기열 정보 불러오기
        public static void LoadWaitingList()
        {
            if (!File.Exists(waitingFile)) return;
            try
            {
                string json = File.ReadAllText(waitingFile);
                WaitingList = JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
            }
            catch { WaitingList = new List<Reservation>(); }
        }

        // 5. 대기열 정보 저장하기 (핵심!)
        public static void SaveWaitingList()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(WaitingList, options);
            File.WriteAllText(waitingFile, json);
        }

        // 6. 테이블 상태 갱신
        public static void UpdateTableStatus()
        {
            foreach (var table in Tables) table.IsReserved = false;

            foreach (var res in Reservations)
            {
                var tableToReserve = Tables.FirstOrDefault(t => t.TableNumber == res.AssignedTableNumber);
                if (tableToReserve != null) tableToReserve.IsReserved = true;
            }
        }

        // 7. 배정 가능한 테이블 목록 반환
        public static List<Table> GetAvailableTables(int guestCount)
        {
            UpdateTableStatus();
            return Tables.Where(t => !t.IsReserved && t.Capacity >= guestCount).ToList();
        }

        // 8. 예약 생성
        public static void CreateReservation(string name, string phone, int guests, int tableNumber)
        {
            Reservation newRes = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                CustomerName = name,
                PhoneNumber = phone,
                GuestCount = guests,
                AssignedTableNumber = tableNumber,
                SeatedAtTime = DateTime.Now
            };

            Reservations.Add(newRes);
            UpdateTableStatus();
            SaveReservations();
        }

        // 9. 대기열 추가 (이 부분이 수정되었습니다)
        public static void AddToWaitingList(string name, string phone, int guests)
        {
            Reservation newRes = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                CustomerName = name,
                PhoneNumber = phone,
                GuestCount = guests,
                AssignedTableNumber = 0,
                SeatedAtTime = DateTime.Now,
                IsWaiting = true
            };

            WaitingList.Add(newRes);

            // [수정 완료] 기존에 SaveReservations()로 되어있던 것을 올바른 저장 메소드로 변경
            SaveWaitingList();
        }

        // 10. 예약 종료 (퇴실)
        public static void EndReservation(int tableNumber)
        {
            Reservation resToRemove = Reservations.FirstOrDefault(r => r.AssignedTableNumber == tableNumber);
            if (resToRemove != null)
            {
                Reservations.Remove(resToRemove);
                UpdateTableStatus();
                SaveReservations();
            }
        }

        // 11. 대기 손님을 테이블로 배정 (추후 기능을 위해 수정)
        public static void AssignWaitingCustomer(Reservation waitingCustomer, int tableNumber)
        {
            WaitingList.Remove(waitingCustomer);

            Reservation newRes = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                CustomerName = waitingCustomer.CustomerName,
                PhoneNumber = waitingCustomer.PhoneNumber,
                GuestCount = waitingCustomer.GuestCount,
                AssignedTableNumber = tableNumber,
                SeatedAtTime = DateTime.Now,
                IsWaiting = false
            };

            Reservations.Add(newRes);
            UpdateTableStatus();

            // 두 파일 모두 갱신해야 함
            SaveReservations();
            SaveWaitingList();
        }
    }
}