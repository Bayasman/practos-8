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
            if (value == 0) { text = "Внезапно, базовые сценарии поведения пользователей будут объективно рассмотрены соответствующими инстанциями. " +
                    "Таким образом, убеждённость некоторых оппонентов влечет за собой процесс внедрения и модернизации поэтапного и последовательного развития общества." +
                    " Для современного мира сплочённость команды профессионалов создаёт предпосылки для переосмысления внешнеэкономических политик."; }
            else if (value == 1) { text = "Не следует, однако, забывать, что консультация с широким активом, в своём классическом представлении, допускает внедрение соответствующих условий активизации.\n Для современного мира сплочённость команды профессионалов однозначно определяет каждого участника как способного принимать собственные решения касаемо поставленных обществом задач.\n Как принято считать, ключевые особенности структуры проекта являются только методом политического участия и подвергнуты целой серии независимых исследований!"; }
            else if (value == 2) { text = "Сложно сказать, почему действия представителей оппозиции неоднозначны и будут подвергнуты целой серии независимых исследований.\n Являясь всего лишь частью общей картины, акционеры крупнейших компаний, инициированные исключительно синтетически, ассоциативно распределены по отраслям. \n В рамках спецификации современных стандартов, диаграммы связей набирают популярность среди определенных слоев населения, а значит, должны быть обнародованы."; }
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

