using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    internal class Program
    {
        private static void Main()
        {
            if (!IsUserDataExists())
            {
                Console.WriteLine("На данный момент не существует пользователя, пожалуйста, " +
                                  "введите имя, возраст и род деятельности пользователя");

                Console.WriteLine();

                InputUserData();

                Console.WriteLine("Спасибо большое, данные пользователя\n");

                DrawUserData();
            }
            else
            {
                Console.WriteLine("На данный момент, данные пользователя выглядят так :");
                DrawUserData();

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Если вы хотите изменить данные, введите yes(регистр не важен)");

                string answerUser = Console.ReadLine();

                if (answerUser.ToLower().Trim() == "yes")
                {
                    InputUserData();

                    Console.WriteLine("Данные пользователя сохранены.");
                }
                else
                {
                    Console.WriteLine("Наше дело предложить, ваше дело отказаться :)");
                }
            }
        }

        static void DrawUserData()
        {
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Имя пользователя - ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Properties.Settings.Default.UserName);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Возраст пользователя - ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Properties.Settings.Default.Age);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Род деятельности пользователя - ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Properties.Settings.Default.Occupation);

            Console.ForegroundColor = ConsoleColor.White;
        }

        static bool IsUserDataExists()
        {
            return !string.IsNullOrEmpty(Properties.Settings.Default.UserName) 
                   && Properties.Settings.Default.Age != 0 
                   && !string.IsNullOrEmpty(Properties.Settings.Default.Occupation);
        }

        static void InputUserData()
        {
            Console.WriteLine("Введите имя пользователя");
            Properties.Settings.Default.UserName = Console.ReadLine();

            Console.WriteLine("Введите возраст пользователя");
            Properties.Settings.Default.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите род деятельности пользователя");
            Properties.Settings.Default.Occupation = Console.ReadLine();

            Properties.Settings.Default.Save();
        }
    }
}
