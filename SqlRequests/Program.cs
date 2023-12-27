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
            DbHelper db = new DbHelper("localhost\\SQLEXPRESS");
        }
    }
}
