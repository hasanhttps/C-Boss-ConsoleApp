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

        public static int gindex = 0;

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

        public static void GuiSystem(DataBase dataBase) {
            var guessIndex = 1;

            while (guessIndex != -1) {
                guessIndex = GuessMenu(guessCheck, dataBase);
            } Console.Clear();
            dataBase.saveData();
        }

        public static void MenuSystem(DataBase dataBase) {
             List<string> choose = new();
            choose.Add("Admin");
            choose.Add("User");
            choose.Add("Exit");
            var index = 1;

            while(index != -1) {
                index = Menu(choose);
                
                if (index == 0) {
                    ExceptionHandling(AdminChoose, dataBase); // Admin Side of Program
                }else if (index == 1) {
                    ExceptionHandling(UserChoose, dataBase); // User Side of Program
                }else if (index == 2) break;
            }dataBase.Dispose();
        }

        public static void guessCheck(DataBase dataBase, int guessIndex) {
            Console.SetCursorPosition(0, 7);

            if (guessIndex == 0) {
                foreach (var employer in dataBase!.Employers) {
                    foreach (var vacancie in employer.Vacancies) {
                        Console.WriteLine($"Id : {vacancie.Id}\n{vacancie.Job}\n{vacancie.Salary} AZN\n{vacancie.Company}\n");
                    }
                }
            }
            else if (guessIndex == 1) { 
                dataBase!.showCvs();
            }else if (guessIndex == 2) {
                Console.WriteLine("Boss Az is originally worker or job finder platform. This program provides you with job.\nAll rights are deserved.");
            }else if (guessIndex == 3) {
                Console.BackgroundColor = ConsoleColor.Black;
                UserChoose(dataBase);
                gindex = 0;
                Console.Write("Press any key to continue . . .");
            }
        }

        public static int GuessMenu(Action<DataBase, int> check, DataBase dataBase) {
            Console.Clear();
            Console.WriteLine(@"  ____                     _         
 | __ )  ___  ___ ___     / \    ____
 |  _ \ / _ \/ __/ __|   / _ \  |_  /
 | |_) | (_) \__ \__ \  / ___ \  / / 
 |____/ \___/|___/___/ /_/   \_\/___|
                                     ");
            List<string> choose = new();
            choose.Add("| Vacancies |");
            choose.Add("| Cvs |");
            choose.Add("| About Us |");
            choose.Add("| Drop Announce |");
            int y = 4;

            List<int> x = new();
            x.Add(40);
            x.Add(55);
            x.Add(80);
            x.Add(95);

            while (true) {
                for (int i = 0; i < choose.Count; i++) {
                    Console.SetCursorPosition(x[i], y);
                    if (gindex == i) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(choose[i]);
                }
                check(dataBase, gindex);
                dynamic ascii = Console.ReadKey();
                if (ascii.Key == ConsoleKey.Escape) gindex = -1;
                else if (ascii.Key == ConsoleKey.LeftArrow) {
                    if (gindex > 0) gindex--;
                    else gindex = choose.Count - 1;
                }
                else if (ascii.Key == ConsoleKey.RightArrow) {
                    if (gindex < choose.Count - 1) gindex++;
                    else gindex = 0;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                break;
            }
            return gindex;
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