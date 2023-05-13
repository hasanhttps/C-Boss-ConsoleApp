using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.MembersNamespace;
using Boss.ModelsNamespace;
using static Boss.NetworkNamespace.Network;

namespace Boss.Functions {
    public static partial class Functions {

        public static void EmployerChoose(DataBase dataBase) {
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
                        if (dataBase.checkEmployer(username, password)) {
                            ExceptionHandling(EmployerMenu, dataBase);
                        }else throw new Exception("Username or password is not valid !");
                    }
                }
                else if (index == 1) {
                    registration(dataBase, addEmployerDatabase);
                }else if (index == 2) break;
            }
        }
        public static void EmployerMenu(DataBase dataBase) {
            List<string> choose = new();
            choose.Add("Create Vacancie");
            choose.Add("Vacancies");
            choose.Add("Notifications");
            choose.Add("Verify Cv");
            choose.Add("Profile");
            choose.Add("Exit");
            var index = 1;

            while (index != -1) {
                index = Menu(choose);

                if (index == 0) {
                    ExceptionHandling(createVacancie, dataBase);
                }else if (index == 1) {
                    dataBase!.currentEmployer!.showVacancies();
                }else if (index == 2){
                    dataBase!.currentEmployer!.showNotifications();
                }else if (index == 3) {
                    ExceptionHandling(verifyCv, dataBase);
                }else if (index == 4){
                    Console.WriteLine(dataBase.currentEmployer);
                    PressAnyKey();
                }
                else if (index == 5) break;
            }
        }

        public static void verifyCv(DataBase dataBase) {
            Console.Write("Please enter the name of worker : ");
            string? name = Console.ReadLine();
            if (name != null) { 
                Worker? worker = dataBase!.FindWorkerByUsername(name);
                if (worker != null) {
                    Notification notification = new("Vacancy verified", $"Your cv accepted by Employer", dataBase!.currentEmployer!.UserName);
                    worker.addNotification(notification);

                    // Send Notification via SMTP

                    Thread thread = new Thread(() => sendMail(worker.Email!, notification));
                    thread.IsBackground = false;
                    thread.Start();
                    dataBase!.saveData();
                }
            }
        }

        public static void createVacancie(DataBase dataBase) {

            Console.WriteLine("Fill the vacancie\n");

            Console.Write("Please enter the job : ");
            string? job = Console.ReadLine();
            Console.Write("Please enter the company : ");
            string? company = Console.ReadLine();
            Console.Write("Please enter the city : ");
            string? city = Console.ReadLine();
            Console.Write("Please enter the experience requierment : ");
            string? experience = Console.ReadLine();
            Console.Write("Please enter the salary : ");
            string? salarystr = Console.ReadLine();
            int.TryParse(salarystr, out int salary);
            Console.Write("Please enter the age distance : ");
            string? age = Console.ReadLine();
            Console.Write("Please enter payment for expire Date : ");
            string? paymentstr = Console.ReadLine();
            int.TryParse(paymentstr, out int payment);
            Employer currentEmployer = dataBase.currentEmployer!;

            if (currentEmployer.Budget - payment < 0) throw new Exception("Budget isn't enough !");
            currentEmployer.Budget -= payment;

            Vacancie vacancie = new(experience, company, city, job, age, salary, payment);

            try {
                Admin.RequestedVacancies![currentEmployer.UserName].Add(vacancie);
            }catch {
                List<Vacancie> vacancies = new();
                vacancies.Add(vacancie);
                Admin.RequestedVacancies!.Add(currentEmployer.UserName, vacancies);
            }
        }


        public static void addEmployerDatabase(DataBase dataBase, User user) {
            Employer employer = new(user); // create employer
            dataBase.Employers.Add(employer); // add employer to database
            dataBase!.saveData(); // Save employers to the Json File 
        }
    }
}
