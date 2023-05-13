using Boss;
using System;
using System.Linq;
using System.Text;
using Boss.ModelsNamespace;
using Boss.MembersNamespace;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using System.Collections.Generic;
using static Boss.NetworkNamespace.Network;

namespace Boss.Functions {
    public static partial class Functions {

        public static void PressAnyKey() {
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

        public static void ExceptionHandling(Action<DataBase> action, DataBase dataBase) {
            try {
                action(dataBase);
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }
        }

        public static int Menu(List<string> choose) {
            Console.Clear();
            bool entered = false;
            int index = 0;
            while (true) {
                int y = 14 - choose.Count;
                for (int i = 0; i < choose.Count; i++) {
                    Console.SetCursorPosition(55, y + i);
                    if (index == i) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(choose[i]);
                }
                dynamic ascii = Console.ReadKey();
                if (ascii.Key == ConsoleKey.Escape) break;
                else if (ascii.Key == ConsoleKey.UpArrow) {
                    if (index > 0) index--;
                    else index = choose.Count - 1;
                }
                else if (ascii.Key == ConsoleKey.DownArrow) {
                    if (index < choose.Count - 1) index++;
                    else index = 0;
                }
                else if (ascii.Key == ConsoleKey.Enter) { 
                    entered = true;
                    break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            if (entered) return index;
            return -1;
        }
        
    }
}