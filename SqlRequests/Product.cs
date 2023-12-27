using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRequests
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public int Volume { get; set; }

        public Product(int id, string name, float cost, int volume) { 
            ID = id;
            Name = name;
            Cost = cost;
            Volume = volume;
        }
    }
}
