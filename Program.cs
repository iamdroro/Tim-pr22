using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace aaasaxzsa
{
    internal class Program
    {
        static void printTab(string s, Hashtable a)
        {
            Console.WriteLine(s);
            ICollection key = a.Keys;
            foreach (string i in key)
            {
                Console.WriteLine(i + "\t" + a[i]);
            }
        }
        static void Main(string[] args)
        {
            Hashtable lud = new Hashtable();
            int[] mass = new int[100];
            StreamReader file = new StreamReader("r1.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] temp = line.Split(' ');
                lud.Add(temp[0], temp[1]);
            }

            printTab("Сейчас в ваших контактах: ", lud);

            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("Выберите что вы хотите сделать: ");
                Console.Write("1-Добавить в контакты. ");
                Console.WriteLine("2-Убрать из контактов. ");
                int otv = int.Parse(Console.ReadLine());
                switch (otv)
                {
                    case 1:
                        Console.WriteLine("Введите номер телефона: ");
                        line = Console.ReadLine();
                        if (lud.ContainsKey(line)) Console.WriteLine("У вас в записной книге под номер " + line + ", Записан " + lud[line]);
                        else
                        {
                            Console.WriteLine("Введите фамилию: ");
                            string line2 = Console.ReadLine();
                            lud.Add(line, line2);
                        }
                        printTab("Сейчас у вас в контактах: ", lud);
                        break;
                    case 2:
                        Console.WriteLine("Введите фамилию для удаления");
                        line = Console.ReadLine();
                        if (lud.ContainsValue(line))
                        {
                            ICollection key = lud.Keys;
                            Console.WriteLine(line);
                            string del = "";
                            foreach (string j in key)
                                if (string.Compare((string)lud[j], line) == 0)
                                {
                                    del = j;
                                    break;
                                }
                            Console.WriteLine(del + "\t" + lud[del] + "- удалено");
                            lud.Remove(del);
                            printTab("Сейчас у вас в контактах: ", lud);
                        }
                        break;
                    case 3:
                        printTab("Сейчас у вас в контактах: ", lud);
                        break;
                }
            }
        }
    }
}
