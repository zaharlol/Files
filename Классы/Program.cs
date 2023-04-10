using System;
using System.IO;
class FileWriter
{
    public static void Main()
    {
        string filePath = @"D:/VS/SkillFactory/Students.txt"; // Укажем путь 
        if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
        {
            //   Если не существует - создаём и записываем в строку
            using (StreamWriter sw = File.CreateText(filePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
            {
                sw.WriteLine("Олег");
                sw.WriteLine("Дмитрий");
                sw.WriteLine("Иван");
            }
        }
        // Откроем файл и прочитаем его содержимое
        using (StreamReader sr = File.OpenText(filePath))
        {
            string str = "";
            while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
            {
                Console.WriteLine(str);
            }
        }

        string fileSK = @"D:/VS/Проекты/Files/Классы/Program.cs";
        using (StreamReader sr = File.OpenText(fileSK))
        {
            string str = "";
            while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
            {
                Console.WriteLine(str);
            }
        }

        var fleInfo = new FileInfo("D:/VS/Проекты/Files/Классы/Program.cs");

        using (StreamWriter sw = fleInfo.AppendText())
        {
            sw.WriteLine($"// Время запуска: {DateTime.Now}");
        }

        using (StreamReader sr = fleInfo.OpenText())
        {
            string str = "";
            while ((str = sr.ReadLine()) != null)
                Console.WriteLine(str);

        }
    }
}
