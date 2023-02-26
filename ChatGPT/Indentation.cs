using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Indentation
    {
        //For Indentation
        public string Indent(int count)
        {
            return "".PadLeft(count);
        }

        //For farve besked
        public static void ColorMessage(ConsoleColor color, string message, bool nextLine)
        {
            Console.ForegroundColor = color;
            if(nextLine)
                Console.WriteLine(message);

            else 
                Console.Write(message);

            Console.ResetColor();
        }


        public static int ValidNumberInput(string number, int maxNumber)
        {
            bool isValid = int.TryParse(number, out int num);


            while (!isValid || num == 0 || num > maxNumber)
            {
                ColorMessage(ConsoleColor.Red, "Enter correct Input: -> ", false);

                bool validNow = int.TryParse(Console.ReadLine(), out int num2);

                if (validNow && num2 != 0 && num2 <= maxNumber)
                    return num2;
                else
                    continue;
            }


            return num;
        }

        /*
        public static string NewBookName()
        {
            int maxNumber = 100;
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, maxNumber);
            
            return "newbook" + randomNumber.ToString();
        } 

        */
    }   
}
