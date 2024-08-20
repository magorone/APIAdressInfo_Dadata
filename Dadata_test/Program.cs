using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dadata;
using Dadata.Model;
using MySql.Data.MySqlClient;


namespace Dadata_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[,] informAdress = new string[20,7]; // создание массива 
                Console.WriteLine("Введите адресс: ");
                string input = Console.ReadLine();

                informAdress = AdressInfo(input).Result;

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(informAdress[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
 
        static async Task<string[,]> AdressInfo(string input)
        {
            var token = "ecab2beece880d207ceaf60c14a68602c3592445";
            var api = new SuggestClientAsync(token);
            var result = await api.SuggestAddress(input);

            string[,] informAdress = new string[20,7];

            int i = 0;
            foreach (var suggest in result.suggestions)
            {
                int j = 0;
                informAdress[i, j++] += suggest.data.fias_id;
                informAdress[i, j++] += suggest.data.city_with_type;
                informAdress[i, j++] += suggest.data.street_with_type;
                informAdress[i, j++] += suggest.data.house;
                informAdress[i, j++] += suggest.data.flat;
                i++;
            }
            return informAdress;
        }

        public static void Commander()
        {
            bool isExit = true;
            string name = "Roma";
            while (isExit)
            {
                Console.WriteLine("Введите команду: ");
                Console.WriteLine("Подсказка: \n" +
                    "1 - SetName\n" +
                    "2 - DisplayName\n" +
                    "3 - SetColor\n" +
                    "4 - DisplayBoxWithName\n" +
                    "5 - Exit");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "SetName":
                        name = SetName();
                        break;
                    case "1":
                        name = SetName();
                        break;
                    case "DisplayName":
                        DisplayName(name);
                        break;
                    case "2":
                        DisplayName(name);
                        break;
                    case "SetColor":
                        SetColor();
                        break;
                    case "3":
                        SetColor();
                        break;
                    case "DisplayBoxWithName":
                        DisplayBoxWithName(name);
                        break;
                    case "4":
                        DisplayBoxWithName(name);
                        break;
                    case "Exit":
                        isExit = false;
                        break;
                    case "5":
                        isExit = false;
                        Console.WriteLine("Выход!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверно введена команда!");
                        break;
                }
            }
        }

        public static string SetName()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            return name;
        }

        public static void DisplayName(string name)
        {
            Console.WriteLine("Введите количество повторений: ");
            int cout = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cout; i++)
            {
                Console.WriteLine(name);
            }
        }

        public static void SetColor()
        {
            Console.WriteLine("Введите цвет текста: \nПодсказка:\n");

            for (int i = 0; i <= 15; i++) 
            {
                Console.WriteLine(i + " - " + ((ConsoleColor)i).ToString());
            }
            int textColor = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = (ConsoleColor)textColor;

            Console.WriteLine("Введите цвет текста: \nПодсказка:\n");

            for (int i = 0; i <= 15; i++)
            {
                Console.WriteLine(i + " - " + ((ConsoleColor)i).ToString());
            }
            int backgroundColor = Convert.ToInt32(Console.ReadLine());
            Console.BackgroundColor = (ConsoleColor)backgroundColor;
        }

        public static void DisplayBoxWithName(string name)
        {
            int cout = name.Length;

            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
            Console.WriteLine($"#{name}#");

            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }

        public interface AdressInformation<T> : IEnumerable<T> //
        {
            string fias_id { get; set; }
            string region_with_type { get; set; }
            string city_with_type { get; set; }
            string street_with_type { get; set; }
            string house { get; set; }
            string flat { get; set; }
        } // INTERFACE ILIST:
          // https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.ilist?view=net-8.0


    }
}


    
