using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace record
{
    internal class print
    {
        static int second = 60;
        static int i = 0;
        static string name = "";
        static string text = "";
        public static List<Records> t = new List<Records>();
        public static void start()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, 0);
            Console.Write("Введите ваш ник:");
            name = Console.ReadLine();
            Fast_text();
        }
        static void ToFile()
        {
            Records.op(t);
            string path = "score.json";
            if (File.Exists(path))
            {
                string json = JsonConvert.SerializeObject(t);
                File.AppendAllText(path, json);
            }
            else { File.Create(path); }

        }
        public static void Time()
        {
            while (second <= 60 && second >= 0)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(40, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(second + "..");
                if (second == 0)
                {
                    t.Add(new Records(name, i, Math.Round((double)i / 60, 2)));
                    ToFile();
                    Console.SetCursorPosition(60, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Время закончилось");
                    ConsoleKeyInfo v = Console.ReadKey();
                    if (v.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        start();
                    }
                }
                second--;
            }
        }
        public static void Fast_text()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Нажмите Enter, чтобы начать.");
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo v = Console.ReadKey();
            Random rnd = new Random();
            int value = rnd.Next(0, 3);
            if (value == 0) { text = ""; }
            else if (value == 1) { text = ""; }
            else if (value == 2) { text = ""; }
            Console.SetCursorPosition(0, 1);
            Console.Write(text);
            char c;
            int mistakesCount = 0;
            Thread thread1 = new Thread(Time);
            if (v.Key == ConsoleKey.Enter)
            {
                thread1.Start();
                while (i < text.Length || second <= 0)
                {
                    c = Console.ReadKey(true).KeyChar;
                    if (c == text[i])
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(c);
                        i++;
                    }
                    else mistakesCount++;
                }
            }
        }
    }
}

