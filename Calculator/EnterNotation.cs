using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class EnterNotation
    {
        //Dictionary<int, string>
        //public GetRangeOfNotation()
        //{

        //}
        public int GetSystem()
        {
            Console.WriteLine("Введите систему счисления до 50");
            string system = Console.ReadLine();
			int a = ToInt(system);
            if (system.Length > 2 && a == -1 )
            {
                Console.WriteLine("ВВЕДЕНЫ НЕКОРРЕКТНЫЕ ДАННЫЕ!");
            }
			return a;
        }
		private int CharToInt(char c)
		{
			return c -'0';
		}
		private int ToInt(string s)
		{
			if (s.Length == 0) return -1;
			switch (s[0])
			{
				case '-':
					return -1;
			}
			int result = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] < '0' || s[i] > '9') return -1;
				result = checked(result * 10 + CharToInt(s[i]));
			}
			return result;
		}

	}
}
