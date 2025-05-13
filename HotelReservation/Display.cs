using HotelReservation.Core;
using HotelReservations.Data;
using HotelReservations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class Display
    {
        private HotelReservationDBContext context;

        private QueryController queryController;
        private ClientController clientController;
        private HotelController hotelController;
        private ReservationController reservationController;
        private RoomController roomController;
        private ServiceController serviceController;

        public Display()
        {
            context = new HotelReservationDBContext();
            queryController = new QueryController(context);
            clientController = new ClientController(context);
            hotelController = new HotelController(context);
            reservationController = new ReservationController(context);
            roomController = new RoomController(context);
            serviceController = new ServiceController(context);
        }

        public void Menu()
        {
            string choice;

            Console.WriteLine("----------------------");
            Console.WriteLine("!     Добре дошли    !");
            Console.WriteLine("----------------------");
            //Круд операции
            //Клиенти
            Console.WriteLine(" ");
            Console.WriteLine("Клиенти:");
            Console.WriteLine("1. Добави клиент");
            Console.WriteLine("2. Изведи клиент по ID");
            Console.WriteLine("3. Изведи всички клиенти");
            Console.WriteLine("4. Update на клиент");
            Console.WriteLine("5. Изтрий клиент");
            //Хотели
            Console.WriteLine(" ");
            Console.WriteLine("Хотели:");
            Console.WriteLine("6. Добави хотел");
            Console.WriteLine("7. Ъпдейт на хотели");
            Console.WriteLine("8. Изтрий хотел");
            //Резервации
            Console.WriteLine(" ");
            Console.WriteLine("Резервации:");
            Console.WriteLine("9. Направи резервация");
            Console.WriteLine("10. Изведи информация за всички резервации");
            Console.WriteLine("11. Ъпдейт на резервация");
            Console.WriteLine("12. Откажи резервация");
            //Стаи
            Console.WriteLine(" ");
            Console.WriteLine("Стаи:");
            Console.WriteLine("13. Добави стая");
            Console.WriteLine("14. Update на стая");
            Console.WriteLine("15. Изтрий стая");
            //Услуги
            Console.WriteLine(" ");
            Console.WriteLine("Услуги:");
            Console.WriteLine("16. Добави услуга");

            //Общи заявки
            Console.WriteLine(" ");
            Console.WriteLine("-------------------");
            Console.WriteLine("17. Хотели по град");
            Console.WriteLine("18. Стаи под цена");
            Console.WriteLine("19. Клиенти с повече от 1 резервация");
            Console.WriteLine("20. Стаи в конкретен хотел");
            Console.WriteLine("21. Резервации на клиент");
            Console.WriteLine("22. Приходи на хотел");
            Console.WriteLine("23. Хотели без резервации");
            Console.WriteLine("24. Неизползвани стаи");
            Console.WriteLine("25. Клиенти по период");
            //Изход
            Console.WriteLine("0. Изход");

            do
            {
                Console.Write("Избор:");

                choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        //string name, string email, string phone
                        Console.WriteLine("Ваведи име");
                        string nameAdd = Console.ReadLine();
                        Console.WriteLine("Ваведи имеил");
                        string emailAdd = Console.ReadLine();
                        Console.WriteLine("Ваведи телефонен номер");
                        string phoneAdd = Console.ReadLine();

                        var addClient = clientController.AddClient(nameAdd, emailAdd, phoneAdd);
                        if (addClient == true)
                        {
                            Console.WriteLine("Успешно добавихте нов клиент!");
                        }
                        else
                        {
                            Console.WriteLine("Добавянето не е успешно!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Ваведете Ад на клиента, който търсите:");
                        int idClient = int.Parse(Console.ReadLine());
                        Client client = clientController.GetClientById(idClient);
                        Console.WriteLine($"Name - {client.Name} Number - {client.PhoneNumber}");
                        break;

                    case "3":
                        Console.WriteLine("Всички клиенти:");
                        List<Client> allclient = clientController.GetAllClients();
                        foreach (var item in allclient)
                        {
                            Console.WriteLine($"{item.Name}-{item.PhoneNumber}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Ваведете АД:");
                        int idClientUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете име:");
                        string nameClient = Console.ReadLine();
                        Console.WriteLine("Ваведете имеил:");
                        string emailClient = Console.ReadLine();
                        Console.WriteLine("Ваведете телефонен номер:");
                        string phoneClient = Console.ReadLine();

                        var clientUpdate = clientController.UpdateClient(idClientUpdate, nameClient, emailClient, phoneClient);
                        if (clientUpdate == true)
                        {
                            Console.WriteLine("Успешно е ъпдейтване!");
                        }
                        else
                        {
                            Console.WriteLine("Ъпдейта не е успешен!");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Ваведи Ад на клиента, който искаш да изтриеш:");
                        int idClientDelete = int.Parse(Console.ReadLine());
                        var clientDelite = clientController.DeleteClient(idClientDelete);
                        if (clientDelite == true)
                        {
                            Console.WriteLine("Успешно изтрихте клиент!");
                        }
                        else
                        {
                            Console.WriteLine("Изтриването не е успешно!");
                        }
                        break;

                    case "6":
                        //string name, string address, string city
                        Console.WriteLine("Ваведи име");
                        string nameHotelAdd = Console.ReadLine();
                        Console.WriteLine("Ваведи адрес");
                        string addressHotel = Console.ReadLine();
                        Console.WriteLine("Ваведи град");
                        string cityHotel = Console.ReadLine();

                        var hotelAdd = hotelController.AddHotel(nameHotelAdd, addressHotel, cityHotel);
                        if (hotelAdd == true)
                        {
                            Console.WriteLine("Успешно добавихте нов хотел!");
                        }
                        else
                        {
                            Console.WriteLine("Добавянето на нов хотел е неуспешно!");
                        }
                        break;

                    case "7":
                        //int id, string name, string address, string city

                        Console.WriteLine("Ваведете АД:");
                        int idHotelUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете име:");
                        string nameHotel = Console.ReadLine();
                        Console.WriteLine("Ваведете адрес:");
                        string addressHotel1 = Console.ReadLine();
                        Console.WriteLine("Ваведете град:");
                        string cityHotel1 = Console.ReadLine();
                        var hotelUpdate = hotelController.UpdateHotel(idHotelUpdate, nameHotel, addressHotel1, cityHotel1);
                        if (hotelUpdate == true)
                        {
                            Console.WriteLine("Ъпдейта е успешен!");
                        }
                        else
                        {
                            Console.WriteLine("Ъпдейта е неуспешен!");
                        }
                        break;

                    case "8":
                        Console.WriteLine("Ваведи Ад на хотела, който искаш да изтриеш:");
                        int idHotelDelete = int.Parse(Console.ReadLine());
                        var hotelDelite = hotelController.DeleteHotel(idHotelDelete);
                        if (hotelDelite == true)
                        {
                            Console.WriteLine("Хотелът е изтрит!");
                        }
                        else
                        {
                            Console.WriteLine("Хотелът не е успешно изтрит!");
                        }
                        break;

                    case "9":
                        //int clientId, int roomId, DateTime checkIn, DateTime checkOut
                        Console.WriteLine("Ваведи Id на клиента");
                        int clientId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведи ID на стаята");
                        int roomId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете дата за начало на резервацията");
                        DateTime checkIn = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете крайна дата на резервацията");
                        DateTime checkOut = DateTime.Parse(Console.ReadLine());

                        var makereservation = reservationController.MakeReservation(clientId, roomId, checkIn, checkOut);
                        if (makereservation == true)
                        {
                            Console.WriteLine("Резервацията е успешно направена");
                        }
                        else
                        {
                            Console.WriteLine("Резервацията не е направена!");
                        }
                        break;

                    case "10":
                        Console.WriteLine("Всички резервации");
                        reservationController.GetAllReservations();
                        break;

                    case "11":
                        //int id, DateTime newCheckIn, DateTime newCheckOut
                        Console.WriteLine("Ваведи Ад на хотела, който искаш да изтриеш:");
                        int idreservation = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете начална дата на резервацията");
                        DateTime newCheckIn = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете крайна дата на резервацията");
                        DateTime newCheckOut = DateTime.Parse(Console.ReadLine());
                        var reservationUpdate = reservationController.UpdateReservation(idreservation, newCheckIn, newCheckOut);
                        if (reservationUpdate == true)
                        {
                            Console.WriteLine("Ъпдейта е успешен!");
                        }
                        else
                        {
                            Console.WriteLine("Ъпдейта е неуспешен!");
                        }
                        break;

                    case "12":
                        Console.WriteLine("Ваведи Ад на хотела, който искаш да изтриеш:");
                        int idReservationCancel = int.Parse(Console.ReadLine());
                        var reservationCancel = reservationController.CancelReservation(idReservationCancel);
                        if (reservationCancel == true)
                        {
                            Console.WriteLine("Резервацията е успешно отказана!");
                        }
                        else
                        {
                            Console.WriteLine("Резервацията не е успешно отказана!");
                        }
                        break;

                    case "13":
                        //int hotelId, string roomNumber, int capacity, decimal price
                        Console.WriteLine("Ваведи на хотела в който се намира тази стая");
                        int hotelId = int.Parse(Console.ReadLine());
                        Console.WriteLine("ваведи номер на стаята");
                        string roomNumber = Console.ReadLine();
                        Console.WriteLine("Ваведи максимален капацитет на стаята");
                        int capacity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведи цена на стаята");
                        decimal price = decimal.Parse(Console.ReadLine());

                        var roomAdd = roomController.AddRoom(hotelId, roomNumber, capacity, price);
                        if (roomAdd == true)
                        {
                            Console.WriteLine("Успешно добавихте нова стая!");
                        }
                        else
                        {
                            Console.WriteLine("Добавянето на стая е неуспешно!");
                        }
                        break;

                    case "14":
                        //int roomId, string roomNumber, int capacity, decimal price
                        Console.WriteLine("Ваведете Ад на стаята която ще ъпдейтнете");
                        int roomIdUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете номер на стаята");
                        string roomNumberUpdate = Console.ReadLine();
                        Console.WriteLine("Ваведете капацитет на стаята");
                        int capasityUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ваведете цена на стаята");
                        decimal priceUpdate = decimal.Parse(Console.ReadLine());
                        var roomUpdate12 = roomController.UpdateRoom(roomIdUpdate, roomNumberUpdate, capasityUpdate, priceUpdate);
                        if (roomUpdate12 == true)
                        {
                            Console.WriteLine("Ъпдейта е успешен!");
                        }
                        else
                        {
                            Console.WriteLine("Ъпдейта е неуспешен!");
                        }
                        break;

                    case "15":
                        Console.WriteLine("Ваведете ид на стаята която искате да изтриете:");
                        int idDelite = int.Parse(Console.ReadLine());
                        var roomDelite = roomController.DeleteRoom(idDelite);
                        if (roomDelite == true)
                        {
                            Console.WriteLine("Успешно изтрихте стая!");
                        }
                        else
                        {
                            Console.WriteLine("Изтриването не е успешно!");
                        }
                        break;

                    case "16":
                        //string name, decimal price
                        Console.WriteLine("Ваведе име на новата услуга:");
                        string nameService = Console.ReadLine();
                        Console.WriteLine("Ваведете цена на услугата:");
                        decimal priceService = decimal.Parse(Console.ReadLine());

                        var serviseAdd = serviceController.AddService(nameService, priceService);
                        if (serviseAdd == true)
                        {
                            Console.WriteLine("Успешно добавихте нова услуга!");
                        }
                        else
                        {
                            Console.WriteLine("Добавянето на услуга е неуспешно!");
                        }
                        break;

                    case "17":
                        Console.Write("Въведи град: ");
                        var city = Console.ReadLine();
                        var hotelsByCity = queryController.GetHotelsByCity(city);
                        if (hotelsByCity.Count() == 0)
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

                    case "18":
                        Console.WriteLine("Ваведете максимална цена: ");
                        var price123 = decimal.Parse(Console.ReadLine());
                        var roomsWithPrice = queryController.GetRoomsAbovePrice(price123);

                        if (roomsWithPrice.Count() == 0)
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

                    case "19":
                        Console.WriteLine("Ваведи име на клиента: ");
                        var name = Console.ReadLine();
                        var multipleReservations = queryController.GetClientsWithMultipleReservations();
                        if (multipleReservations.Count() == 0)
                        {
                            Console.WriteLine("Всички клиент имат само по една резервация!");
                        }
                        else
                        {
                            foreach (var client2 in multipleReservations)
                            {
                                Console.WriteLine(client2.Name);
                            }
                        }

                        break;

                    case "20":
                        Console.WriteLine("Име на хотел: ");
                        var hotelName = Console.ReadLine();
                        foreach (var room in queryController.GetRoomsByHotelName(hotelName))
                            Console.WriteLine($"Стая {room.RoomNumber} - {room.PricePerNight}лв");
                        break;

                    case "21":
                        Console.Write("Име на клиент: ");
                        var clientName = Console.ReadLine();
                        var reservationsForClient = queryController.GetReservationsForClient(clientName);
                        if (reservationsForClient.Count() == 0)
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

                    case "22":
                        Console.WriteLine("Име на хотел: ");
                        var hotelRevenue = Console.ReadLine();
                        var total = queryController.GetTotalRevenueForHotel(hotelRevenue);
                        Console.WriteLine($"Общ приход: {total}лв");
                        break;

                    case "23":
                        var hotels = queryController.GetHotelsWithoutReservations();

                        if (hotels.Count() == 0)
                        {
                            Console.WriteLine("Няма хотели без резервации!");
                        }
                        else
                        {
                            foreach (var h in hotels)
                                Console.WriteLine(h.Name);
                        }
                        break;

                    case "24":
                        foreach (var room in queryController.GetUnusedRooms())
                        {
                            Console.WriteLine($"Стая {room.RoomNumber} в {room.Hotel.Name}");
                        }
                        break;

                    case "25":
                        Console.Write("Начална дата (гггг-мм-дд): ");
                        var start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Крайна дата (гггг-мм-дд): ");
                        var end = DateTime.Parse(Console.ReadLine());
                        foreach (var c in queryController.GetClientsByDateRange(start, end))
                            Console.WriteLine(c.Name);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невалиден избор. Опитай пак.");
                        break;
                }
            }
            while (choice != "0");
        }
    }
}
