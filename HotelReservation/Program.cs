using HotelReservation.Core;
using HotelReservations.Data;
using Microsoft.EntityFrameworkCore;


namespace HotelReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Display display = new Display();
                display.Menu();
            }
        }
    } 
}