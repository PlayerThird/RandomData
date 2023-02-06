using System;
using System.IO;
using System.Text;

class Test
{

    public static void Main()
    {
        Console.WriteLine("Файл будет создан по пути: C:\\NewRandomData.txt");
        Console.WriteLine("Сколько рандома вам дать?");
        int x = Convert.ToInt32(Console.ReadLine());
        string path = @"C:\NewRandomData.txt";

        // Delete the file if it exists.
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        //Create the file.
        using (FileStream fs = File.Create(path))
        {
            
            for (int i = 0; i < x; i++)
            {
                
                AddText(fs, RandomWords());
                
            }
            
            


        }

        //Open the stream and read it back.
        using (FileStream fs = File.OpenRead(path))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            int readLen;
            while ((readLen = fs.Read(b, 0, b.Length)) > 0)
            {
                Console.WriteLine(temp.GetString(b, 0, readLen));
            }
        }
    }

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
    private static string RandomWords(){
        string random = String.Empty;
        string[] names = { "Василий", "Александр", "Николай", "Дарья", "Игнат", "Артём",
        "Вероника", "Даниил", "Антонина", "Леонид", "Полина"};
        string[] famale = { "Куст","Шарага","Кумарь","Хвоя", "Береза", "Синька", "Чертила", "Одуванчик", 
        "Жук", "Ли", "Качан"};
        int x = new Random().Next(famale.Length);
        int y = new Random().Next(names.Length);
        return random = ($"{names[x]} {famale[y]}\r\n");
        }
}

