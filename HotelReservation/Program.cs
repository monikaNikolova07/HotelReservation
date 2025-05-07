
using HotelReservation.Core;
using HotelReservation.Data;
using HotelReservation.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ClientController clientController = new ClientController();
            HotelController hotelController = new HotelController();
            ReservationController reservationController = new ReservationController();
            RoomController roomController = new RoomController();

            Console.WriteLine("---------- ДОБРЕ ДОШЛИ ----------");
            Console.WriteLine("1. Добавете хотел");
            Console.WriteLine("2. Добавете клиент");
            Console.WriteLine("3. Добавете резервация");
            Console.WriteLine("4. Добавете стая");
            Console.WriteLine("5. Добавете хотел");
            //-------------------------------------
            Console.WriteLine("2. Добавете 4 отговора на избран въпрос");
            Console.WriteLine("3. Редактирайте на въпрос по id");
            Console.WriteLine("4. Редактирайте на отговор по id");
            Console.WriteLine("5. Изтрийте жокер");
            Console.WriteLine("6. Добавете участник");
            Console.WriteLine("7. Изведете текста на въпросите за сума по-голяма от 3000 лв.");
            Console.WriteLine("8. Изведете текста на въпросите и всичките възможни отговори за всеки въпрос");
            Console.WriteLine("9. Изведете текста на въпроса и на верния отговор само за въпросите за посочена сума");
        }
    } 
}