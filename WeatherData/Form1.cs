using Newtonsoft.Json.Linq;
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
        // токен для подключения к openweatherAPI
        static string APIkey = "d09ac650ab9ce38049779f4aef823612";

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку поиска данных о погоде
        private void button1_Click(object sender, EventArgs e)
        {
            string country = searchText.Text;

            // Обработчик ошибок, связанных с ошибкой 404, например, неправильно ввели название города или сервер не отвечает
            try
            {
                // Строка запроса с введенным в TextBox городом и ключом, который выдал сайт openweathermap.org
                string APIaddress = $"https://api.openweathermap.org/data/2.5/weather?q={country}&appid={APIkey}";

                // Создаем экземпляр класса GetRequest, с помощью которого мы получим необходимые нам данные
                var request = new GetRequest(APIaddress);
                request.Run();

                // Результат запроса
                var response = request.Response;

                // Переводим полученные данные с API в json формат
                var json = JObject.Parse(response);

                // Заполняем текстовые поля, которые необходимы по заданию
                descriptionText.Text = (string)json["weather"][0]["description"];
                temperatureText.Text = (string)json["main"]["temp"];
                speedText.Text = (string)json["wind"]["speed"];

            }
            catch 
            {
                // Оповещение пользователся, что он неправильно ввел город
                MessageBox.Show("Город не найден!", "O_o", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
