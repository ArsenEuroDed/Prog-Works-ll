using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Zadanie_12
{
    class Program
    {
        //константа (массив строк), содержащая наименования всех цветов радуги
        private static readonly string[] rbColors =
        {
        ">красный<", ">оранжевый<", ">жёлтый<", ">зелёный<", ">голубой<", ">синий<", ">фиолетовый<"
    };

        static void Main(string[] args)
        {

            //имя файла
            string filePath = Path.Combine(Environment.CurrentDirectory, "clrs.txt");

            //меню
            bool isRunning = true; //переменная для управления циклом меню
            while (isRunning == true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать файл");
                Console.WriteLine("2. Прочитать файл");
                Console.WriteLine("3. Выход");
                Console.Write(">>>Выберите опцию: ");

                string choice = Console.ReadLine();

                //в зависимости от выбранного пункта, запускаем ту или иную часть программы
                switch (choice)
                {
                    case "1":
                        CreateFile(filePath); //создание файла
                        break;
                    case "2":
                        ReadFile(filePath); //чтение файла
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1, 2 или 3.");
                        break;
                }
            }
        }

        //метод для создания файла и записи в него цветов радуги
        private static void CreateFile(string filePath)
        {

            Random random = new Random();
            var newrbColors = rbColors.OrderBy(x => random.Next()).ToArray();

            //запись массива строк (названий цветов) в файл
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.GetEncoding(1251))) // Кодировка ANSI (Windows-1251)
                {
                    foreach (var color in newrbColors)
                    {
                        writer.WriteLine(color);
                    }
                }
                Console.WriteLine($"Файл '{filePath}' успешно создан.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[e][r][r]Ошибка при создании файла: {ex.Message}");
            }
        }

        //метод для чтения файла и вывода его содержимого на экран
        private static void ReadFile(string filePath)
        {
            //проверка существования файла
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[e][r][r]Файл '{filePath}' не существует.");
                return;
            }

            //чтение содержимого файла
            try
            {
                using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.GetEncoding(1251))) // Кодировка ANSI (Windows-1251)
                {
                    Console.WriteLine("<<<Содержимое файла:");

                    string line;
                    bool isRunning = true;
                    while (isRunning == true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            isRunning = false;
                        }
                        Console.WriteLine(line);
                    }
                }
            }
            //обработка ошибки чтения файла
            catch (Exception ex)
            {
                Console.WriteLine($"[e][r][r]Ошибка при чтении файла: {ex.Message}");
            }
        }

    }

}
