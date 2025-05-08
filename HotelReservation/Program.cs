using HotelReservation.Core;
using HotelReservations.Data;
using Microsoft.EntityFrameworkCore;


namespace HotelReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using var context = new HotelReservationDBContext();
            var controller = new QueryController(context);

            while (true)
            {
                Console.WriteLine("\n--- Хотелска Система ---");
                Console.WriteLine("1. Хотели по град");
                Console.WriteLine("2. Стаи над цена");
                Console.WriteLine("3. Клиенти с повече от 1 резервация");
                Console.WriteLine("4. Стаи в конкретен хотел");
                Console.WriteLine("5. Резервации на клиент");
                Console.WriteLine("6. Популярни стаи");
                Console.WriteLine("7. Приходи на хотел");
                Console.WriteLine("8. Хотели без резервации");
                Console.WriteLine("9. Неизползвани стаи");
                Console.WriteLine("10. Клиенти по период");
                Console.WriteLine("0. Изход");
                Console.Write("Избор: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Въведи град: ");
                        var city = Console.ReadLine();
                        foreach (var hotel in controller.GetHotelsByCity(city))
                            Console.WriteLine($"{hotel.Name} - {hotel.Address}");
                        break;

                    case "2":
                        Console.Write("Минимална цена: ");
                        var price = decimal.Parse(Console.ReadLine());
                        foreach (var room in controller.GetRoomsAbovePrice(price))
                            Console.WriteLine($"Стая {room.RoomNumber} - {room.PricePerNight}лв");
                        break;

                    case "3":
                        foreach (var client in controller.GetClientsWithMultipleReservations())
                            Console.WriteLine(client.Name);
                        break;

                    case "4":
                        Console.Write("Име на хотел: ");
                        var hotelName = Console.ReadLine();
                        foreach (var room in controller.GetRoomsByHotelName(hotelName))
                            Console.WriteLine($"Стая {room.RoomNumber} - {room.PricePerNight}лв");
                        break;

                    case "5":
                        Console.Write("Име на клиент: ");
                        var clientName = Console.ReadLine();
                        foreach (var res in controller.GetReservationsForClient(clientName))
                            Console.WriteLine($"{res.CheckInDate.ToShortDateString()} до {res.CheckOutDate.ToShortDateString()} - {res.TotalPrice}лв");
                        break;

                    case "6":
                        foreach (var room in controller.GetPopularRooms())
                            Console.WriteLine($"Стая {room.RoomNumber} в {room.Hotel.Name}");
                        break;

                    case "7":
                        Console.Write("Име на хотел: ");
                        var hotelRevenue = Console.ReadLine();
                        var total = controller.GetTotalRevenueForHotel(hotelRevenue);
                        Console.WriteLine($"Общ приход: {total}лв");
                        break;

                    case "8":
                        foreach (var h in controller.GetHotelsWithoutReservations())
                            Console.WriteLine(h.Name);
                        break;

                    case "9":
                        foreach (var room in controller.GetUnusedRooms())
                            Console.WriteLine($"Стая {room.RoomNumber} в {room.Hotel.Name}");
                        break;

                    case "10":
                        Console.Write("Начална дата (гггг-мм-дд): ");
                        var start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Крайна дата (гггг-мм-дд): ");
                        var end = DateTime.Parse(Console.ReadLine());
                        foreach (var c in controller.GetClientsByDateRange(start, end))
                            Console.WriteLine(c.Name);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невалиден избор. Опитай пак.");
                        break;
                }
            }
        }
    } 
}