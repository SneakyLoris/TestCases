using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData
{
    public class GetRequest
    {
        // Поля и свойство необходимые для работы класса
        HttpWebRequest _request;
        string _address;

        public string Response {  get; set; }

        // При создании данного класса необходимо передать адрес, по которому необходимо совершить запрос
        public GetRequest(string address) { 
            _address = address;
        }

        // Основная функция класса, которая выполняет GET запрос по заданному в конструкторе классу
        public void Run()
        {
            // Создаем запрос
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "GET";

            // Получаем ответ и записываем полученное через поток в свойство Response
            HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream != null)
                Response = new StreamReader(stream).ReadToEnd();
        }
    }
}
