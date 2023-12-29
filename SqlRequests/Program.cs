using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRequests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создается экземпляр класса DbHelper, в котором написаны все запросы по заданию
            // В качестве параметра передается название сервера баз данных
            // DbHelper.Connect(@"Data Source = localhost\\SQLEXPRESS;Initial Catalog = 'Market';Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // 1 Задание
            Console.WriteLine("1 Задание");
            var managers = DbHelper.Task1();
            foreach (var manager in managers)
                Console.WriteLine(manager);

            // 2 Задание
            Console.WriteLine("\n2 Задание");
            Console.WriteLine(DbHelper.Task2());

            // 3 Задание
            Console.WriteLine("\n3 Задание");
            Console.WriteLine(DbHelper.Task3());

            // 4 Задание
            // Console.WriteLine("\n4 Задание");
            // Console.WriteLine(DbHelper.Task4());

            //
            //
            //



            Console.WriteLine("Конец программы!");
            Console.ReadKey();
        }
    }
}
