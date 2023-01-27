using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class EnterValue
    {
        public string GetValue()
        {
            if (Program.StartNotation == -1)
            {
                Console.WriteLine("Сначала требуется ввести исходную систему счисления\nДля возврата в меню нажмите любую клавишу");
                Console.ReadKey();
                return null;
            }
            Console.WriteLine("Введите число:");
            string value = Console.ReadLine();
            if (!Validation(value))
            {
                Console.WriteLine("Введенное число не соответствует исходной системе счисления\nДля возврата в меню нажмине любую клавишу");
                Console.ReadKey();
                return null;
            }
            return value;
        }
        private string GetValidChars() 
        {
            return "0123456789ABCDEF";
        }
        private bool Validation(string value) 
        {
            if (value.Length == 0)
            {
                return false;
            }
            foreach (var symbol in value)
            {
                for (int i = 0; i <= Program.StartNotation; i++)
                {
                    if (symbol != GetValidChars()[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
