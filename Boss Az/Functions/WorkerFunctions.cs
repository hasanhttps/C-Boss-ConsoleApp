using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.MembersNamespace;
using Boss.ModelsNamespace;
using static Boss.NetworkNamespace.Network;

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
                            ExceptionHandling(WorkerMenu, dataBase);
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
            List<string> choose = new();
            choose.Add("Vacancies");
            choose.Add("Profile");
            choose.Add("Notifications");
            choose.Add("Exit");
            var index = 1;

            while (index != -1) {
                index = Menu(choose);

                if (index == 0) {
                    dataBase!.showVacancies();
                    sendCv(dataBase);
                }
                else if (index == 1) {
                    Console.WriteLine("Profile Info\n");
                    Console.WriteLine(dataBase!.currentWorker);
                    PressAnyKey();
                }else if (index == 2) {
                    dataBase!.currentWorker!.showNotifications();
                }else if (index == 3) break;
            }
        }

        public static void sendCv(DataBase dataBase) {
            Console.Write("Please enter the first 8 char of Id : ");
            string? id = Console.ReadLine();
            Cv? cv = createCv(dataBase);

            if (cv != null) {
                Notification? notification = new("You have cv request", $"Your vacancy with [{id}] id have cv request by worker.\nWorker Cv\n\n{cv}", dataBase!.currentWorker!.UserName);
                Employer? employer = dataBase!.FindEmployerByVacancyId(id);
                employer!.addNotification(notification);
                dataBase!.saveData();

                // Send Notification via SMTP

                Thread thread = new Thread(() => sendMail(employer.Email!, notification));
                thread.IsBackground = false;
                thread.Start();
            }
        }
        public static void addWorkerDatabase(DataBase dataBase, User user) {
            Worker worker = new(user); // create worker
            dataBase.Workers.Add(worker); // add worker to database
            dataBase!.saveData(); // save data to database
        }

        public static Cv? createCv(DataBase dataBase) {
            Console.Write("Please enter the job you do : ");
            string? job = Console.ReadLine();
            Console.Write("Please enter the school you studied : ");
            string? school = Console.ReadLine();
            Console.Write("Please enter your graduate score : ");
            string? graduateScoreStr = Console.ReadLine();
            if (!int.TryParse(graduateScoreStr, out int graduateScore)) throw new Exception("Graduate score couldn't be any char !");
            Console.Write("Please enter your skills : ");
            string? skills = Console.ReadLine();
            Console.Write("Please enter the companies you worked : ");
            string? companies = Console.ReadLine();
            Console.Write("Please enter the languages that you know : ");
            string? foreignLanguages = Console.ReadLine();
            Console.Write("Please enter your git url : ");
            string? gitUrl = Console.ReadLine();
            Console.Write("Please enter your Linkedn : ");
            string? linkedIn = Console.ReadLine();
            Console.Write("Do you have difference Certificate (true, false) : ");
            string? haveDifferCert = Console.ReadLine();
            Console.Write("Please enter the payment : ");
            string? paymentstr = Console.ReadLine();
            if (!int.TryParse(paymentstr, out int payment)) throw new Exception("Payment couldn't be any char !");
            dataBase!.currentWorker!.Budget -= payment;

            Cv? newCv = new(job, school, skills, companies, foreignLanguages, gitUrl, linkedIn, graduateScore, haveDifferCert);
            newCv.Payment = payment;

            return newCv;
        }

    }
}
