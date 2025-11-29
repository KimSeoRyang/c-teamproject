using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.Json; // .NET 5 이상 기본
                        // using Newtonsoft.Json; // .NET Framework 구 버전용

namespace TeamProjectFinal
{
    public static class DataManager
    {
        private static string reservationFile = "reservations.json";

        // 프로그램 전역에서 사용할 데이터 리스트
        public static List<Reservation> Reservations { get; private set; }
        public static List<Table> Tables { get; private set; }

        // 1. 테이블 리스트 초기화 (앱 시작 시 1회 호출)
        public static void InitializeTables()
        {
            // 5. 다형성 (Polymorphism)
            // List<Table> 이라는 하나의 리스트에 각기 다른 하위 클래스 객체를 저장
            Tables = new List<Table>
        {
            new TwoPersonTable(1),
            new TwoPersonTable(2),
            new FourPersonTable(3),
            new FourPersonTable(4),
            new FourPersonTable(5),
            new SixPersonTable(6)
            // 필요한 만큼 테이블 추가
        };
        }

        // 2. 예약 정보 불러오기 (JSON)
        public static void LoadReservations()
        {
            if (!File.Exists(reservationFile))
            {
                Reservations = new List<Reservation>();
                return;
            }

            string json = File.ReadAllText(reservationFile);
            Reservations = JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();

            // 로드 후 테이블 상태 동기화
            UpdateTableStatus();
        }

        // 3. 예약 정보 저장하기 (JSON)
        public static void SaveReservations()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Reservations, options);
            File.WriteAllText(reservationFile, json);
        }

        // 4. 테이블 예약 상태 갱신 (Reservations 리스트 기준)
        public static void UpdateTableStatus()
        {
            // 모든 테이블을 '비어있음'으로 초기화
            foreach (var table in Tables)
            {
                table.IsReserved = false;
            }

            // 현재 Reservations 리스트에 있는 테이블만 '사용중'으로 변경
            foreach (var res in Reservations)
            {
                var tableToReserve = Tables.FirstOrDefault(t => t.TableNumber == res.AssignedTableNumber);
                if (tableToReserve != null)
                {
                    tableToReserve.IsReserved = true;
                }
            }
        }

        // 5. 배정 가능한 테이블 목록 반환
        public static List<Table> GetAvailableTables(int guestCount)
        {
            UpdateTableStatus(); // 항상 최신 상태에서 확인
            return Tables
                .Where(t => !t.IsReserved && t.Capacity >= guestCount)
                .ToList();
        }

        // 6. 새 손님 배정 (예약 생성)
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
            UpdateTableStatus(); // 테이블 상태 갱신
            SaveReservations(); // JSON 저장
        }

        // 7. 손님 퇴실 (예약 종료)
        public static void EndReservation(int tableNumber)
        {
            Reservation resToRemove = Reservations.FirstOrDefault(r => r.AssignedTableNumber == tableNumber);
            if (resToRemove != null)
            {
                Reservations.Remove(resToRemove);
                UpdateTableStatus(); // 테이블 상태 갱신
                SaveReservations(); // JSON 저장
            }
        }
    }
}
