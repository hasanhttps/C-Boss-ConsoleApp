using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.MembersNamespace;

namespace Boss.Functions {
    public static partial class Functions {
        
        public static void WorkerChoose(DataBase dataBase) { 
            List<string> choose = new();
            choose.Add("Log In");
            choose.Add("Sign Up");
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
                        if (dataBase.checkWorker(username, password)) {
                            PressAnyKey();
                        }else throw new Exception("Username or password is not valid !");
                    }
                }
                else if (index == 1) {
                    registration(dataBase, addWorkerDatabase);
                }
                else if (index == 2) break;
            }
        }

        public static void WorkerMenu(DataBase dataBase) {

        }

        public static void addWorkerDatabase(DataBase dataBase, User user) {
            Worker worker = new(user); // create worker
            dataBase.Workers.Add(worker); // add worker to database
        }
    }
}
