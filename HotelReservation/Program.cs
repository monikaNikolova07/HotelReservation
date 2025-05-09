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

            var context = new HotelReservationDBContext();
            var controller = new QueryController(context);

            while (true)
            {
                Console.WriteLine("\n--- Хотелска Система ---");
                Console.WriteLine("1. Хотели по град");
                Console.WriteLine("2. Стаи над цена");
                Console.WriteLine("3. Клиенти с повече от 1 резервация");
                Console.WriteLine("4. Стаи в конкретен хотел");
                Console.WriteLine("5. Резервации на клиент");
                //6 е изтрита 
                Console.WriteLine("6. Популярни стаи");
                Console.WriteLine("7. Приходи на хотел");
                Console.WriteLine("8. Хотели без резервации");
                Console.WriteLine("9. Неизползвани стаи");
                Console.WriteLine("10. Клиенти по период");
                Console.WriteLine("0. Изход");
                Console.Write("Избор:");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Въведи град: ");
                        var city = Console.ReadLine();
                        var hotelsByCity = controller.GetHotelsByCity(city);
                        if(hotelsByCity.Count() == 0)
                        {
                            Console.WriteLine("Няма хотели в този град!");
                        }
                        else
                        {
                            foreach (var hotel in hotelsByCity)
                            {
                                Console.WriteLine($"{hotel.Name} - {hotel.Address}");
                            }
                        }
                            
                        break;

                    case "2":
                        Console.Write("Минимална цена: ");
                        var price = decimal.Parse(Console.ReadLine());
                        var roomsWithPrice = controller.GetRoomsAbovePrice(price);
                        
                        if(roomsWithPrice.Count() == 0)
                        {
                            Console.WriteLine("Всички стаи са с по-големи цени!");
                        }
                        else
                        {
                            foreach (var room in roomsWithPrice)
                            {
                                Console.WriteLine($"Стая {room.RoomNumber} - {room.PricePerNight}лв");
                            }
                        }
                            
                            
                        break;

                    case "3":
                        Console.Write("Ваведи име на клиента: ");
                        var name = Console.ReadLine();
                        var multipleReservations = controller.GetClientsWithMultipleReservations();
                        if(multipleReservations.Count() == 0)
                        {
                            Console.WriteLine("Всички клиент имат само по една резервация!");
                        }
                        else
                        {
                            foreach (var client in multipleReservations)
                            {
                                Console.WriteLine(client.Name);
                            }
                        }
                            
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
                        var reservationsForClient = controller.GetReservationsForClient(clientName);
                        if(reservationsForClient.Count() == 0)
                        {
                            Console.WriteLine("Такъв клиент не е направил резервация!");
                        }
                        else
                        {
                            foreach (var res in reservationsForClient)
                            {
                                Console.WriteLine($"{res.CheckInDate.ToShortDateString()} до {res.CheckOutDate.ToShortDateString()} - {res.TotalPrice}лв");
                            }
                        }
                            
                        break;
                    /*
                    case "6":
                        foreach (var room in controller.GetPopularRooms())
                            Console.WriteLine($"Стая {room.RoomNumber} в {room.Hotel.Name}");
                        break;
                    */

                    case "7":
                        Console.Write("Име на хотел: ");
                        var hotelRevenue = Console.ReadLine();
                        var total = controller.GetTotalRevenueForHotel(hotelRevenue);
                        Console.WriteLine($"Общ приход: {total}лв");
                        break;

                    case "8":
                        var hotels = controller.GetHotelsWithoutReservations();

                        if(hotels.Count() == 0)
                        {
                            Console.WriteLine("Няма хотели без резервации!");
                        }
                        else
                        {
                            foreach (var h in hotels)
                                Console.WriteLine(h.Name);
                        }
                        break;

                    case "9":
                        foreach (var room in controller.GetUnusedRooms())
                        {
                            Console.WriteLine($"Стая {room.RoomNumber} в {room.Hotel.Name}");
                        }   
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