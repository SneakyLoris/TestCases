using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherData
{
    public partial class Form1 : Form
    {
        // токен для подключения к API
        static string APIkey = "d09ac650ab9ce38049779f4aef823612";

        static string APIcall = $"https://api.openweathermap.org/data/2.5/weather?q={"Москва"}&appid={APIkey}";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string country = searchText.Text;

            if (country.Trim() != null)
            {

            }
        }

        private void GetResponse(string country)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIcall);
            HttpWebRequest response = 
        }
    }
}
