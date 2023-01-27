using System;
using System.Collections.Generic;
using System.Linq;
using static Calculator.EnterNotation;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<MenuItem> menu = new List<MenuItem>
            {
                new MenuItem {Text = "Ввести исходную систему счисления", Logic = new EnterNotation(), IsSelected = true},
                new MenuItem {Text = "Ввести число", Logic = new EnterValue()},
                new MenuItem {Text = "Ввести конечную систему счисления", Logic = new EnterNotation()},
                new MenuItem {Text = "Выполнить", Logic = null},
                new MenuItem {Text = "Выход", Logic = new Exit()}
                
            };
            
            do
            {
                DrawMenu(menu);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuSelectNext(menu);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuSelectPrev(menu);
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Execute(GetSelectedItem(menu).Logic, GetSelectedItem(menu).Text);

                }

            } while (true);

            
        }
        public static int StartNotation = -1;
        public static int FinishNotation = -1;
        public static string Value;
        public static void Execute(object logic, string text) 
        {
            ClearConsole();
            if (logic is EnterNotation notation)
            {
                if (text == "Ввести исходную систему счисления")
                {
                    StartNotation = notation.GetSystem();
                }
                if (text == "Ввести конечную систему счисления")
                {
                    FinishNotation = notation.GetSystem();
                }
            }
            else if (logic is Exit exit)
            {
                exit.Off();
            }
            else if (logic is EnterValue enter)
            {
                Value = enter.GetValue();
            }
        }
        private static void ClearConsole()
        {
            Console.SetCursorPosition(0, 0);
            for (int index = 0; index < Console.WindowWidth * Console.WindowHeight; index++)
                Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }
        public static void DrawMenu(List<MenuItem> menu)
        {
            ClearConsole();
            foreach (var item in menu)
            {
                Console.BackgroundColor = item.IsSelected ? ConsoleColor.Green : ConsoleColor.Black;
                Console.WriteLine(item.Text);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void MenuSelectNext(List<MenuItem> menu)
        {
            var selectedItem = GetSelectedItem(menu);
            if (selectedItem is null)
            {
                if (menu.Count > 0)
                {
                    menu[0].IsSelected = true;
                }
                return;
            }
            int selectedIndex = GetSelectedIndex(menu);
            selectedItem.IsSelected = false;

            selectedIndex = selectedIndex == menu.Count - 1
                ? 0
                : ++selectedIndex;

            menu[selectedIndex].IsSelected = true;
        }

        static void MenuSelectPrev(List<MenuItem> menu)
        {
            var selectedItem = GetSelectedItem(menu);
            if (selectedItem is null)
            {
                if(menu.Count > 0)
                {
                    menu[0].IsSelected = true;
                }
                return;
            }
            int selectedIndex = GetSelectedIndex(menu);
            selectedItem.IsSelected = false;

            selectedIndex = selectedIndex == 0
                ? menu.Count - 1
                : --selectedIndex;

            menu[selectedIndex].IsSelected = true;
        }
        static MenuItem GetSelectedItem(List<MenuItem> menu)
        {
            foreach (var item in menu)
            {
                if (item.IsSelected) return item;
            }
            return null;
        }
        static int GetSelectedIndex(List<MenuItem> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                MenuItem item = menu[i];
                if (item.IsSelected) return i;
                
            }
            return 0;
        }
    }
}
