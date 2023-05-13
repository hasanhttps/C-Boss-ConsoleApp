using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;

namespace Boss.Functions {
    public static partial class Functions {
        public static void AdminChoose(DataBase dataBase) {
            List<string> choose = new();
            choose.Add("Log In");
            choose.Add("Exit");
            var index = 1;

            while (index != -1) {
                index = Menu(choose);

                if (index == 0) {
                    Console.Write("Please enter the username or email : ");
                    string? username = Console.ReadLine();
                    Console.Write("Please enter the password : ");
                    string? password = Console.ReadLine();

                    if (username != null && password != null) {
                        if (dataBase.checkAdmin(username, password)) {
                            ExceptionHandling(AdminMenu, dataBase);
                        } else throw new Exception("Username or password is not valid !");
                    }
                }else if (index == 1) break;
            }
        }

        public static void AdminMenu(DataBase dataBase) {
            List<string> choose = new();
            choose.Add("Apply Vacancies");
            choose.Add("Show Vacancies");
            choose.Add("Notifications");
            choose.Add("Edit");
            choose.Add("Exit");
            var index = 1;
            
            while (index != -1) {
                index = Menu(choose);
                Admin? currentAdmin = dataBase.currentAdmin;

                if (index == 0) { // Apply the requested vacancies
                    currentAdmin!.showRequestVacancies();
                    Console.Write("Please enter the first 8 character of id for apply vacancie : ");
                    string? id = Console.ReadLine();
                    dataBase!.applyVacancies(id, currentAdmin.UserName);
                }else if (index == 1) {
                    dataBase!.showVacancies();
                    PressAnyKey();
                }
                else if (index == 2) {
                    currentAdmin!.showNotifications();
                    PressAnyKey();
                }else if (index == 4) break;
            }
        }

    }
}
