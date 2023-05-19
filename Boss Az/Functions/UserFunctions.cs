using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.ModelsNamespace;
using static Boss.NetworkNamespace.Network;


namespace Boss.Functions {
    public static partial class Functions {

        public static void UserChoose(DataBase dataBase) {
            List<string> choose = new();
            choose.Add("Worker");
            choose.Add("Employer");
            choose.Add("Exit");
            var index = 1;

            while (index != -1) {
                index = Menu(choose);
                
                if (index == 0) {
                    ExceptionHandling(WorkerChoose, dataBase); 
                }else if (index == 1) {
                    ExceptionHandling(EmployerChoose, dataBase);
                }else if (index == 2) break;
            }
        }

        public static bool checkRegistrationCode(string email) {

            // Creating Random Data

            Random random = new Random();
            int randint = random.Next(100000, 1000000);

            // Html Mesage content

            string message = $"<div class=\"\"><div class=\"aHl\"></div><div id=\":ot\" tabindex=\"-1\"></div><div id=\":mk\" class=\"ii gt\" jslog=\"20277; u014N:xr6bB; 1:WyIjdGhyZWFkLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsW11d; 4:WyIjbXNnLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxbXV0.\"><div id=\":ml\" class=\"a3s aiL msg1943207792933616446\"><u></u><div style=\"margin:0;padding:0\" bgcolor=\"#FFFFFF\"><table width=\"100%\" height=\"100%\" style=\"min-width:348px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" lang=\"az\"><tbody><tr height=\"32\" style=\"height:32px\"><td></td></tr><tr align=\"center\"><td><div><div></div></div><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding-bottom:20px;max-width:516px;min-width:220px\"><tbody><tr><td width=\"8\" style=\"width:8px\"></td><td><div style=\"border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px\" align=\"center\" class=\"m_1943207792933616446mdv2rw\"><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAflBMVEX4yxz8zhuvkifSrSL6zBzmvR8ADzUiKDQXIDRwYC7/0RszMzMrLTN3Zi3/1xn/0xowMTNVTDB1ZC4THzQ+OzKMdysnKzQJGjW1liYeJTQaIjTvxB3KpyPetyCDbyyagSpFQDEPHTT/0hpmWS9RSTGqjigAFzW/niV+ay3WsSElUrH7AAAA4klEQVR4Ab2SBUIDMRBFk/ZvnE6g7m73vyBJcZgsUPvrm5dxcT3JrDqgkdQsE6iU1sa6GsB4Hx7uA6AWaJEUkhwKQHx88qbd7nQrxwM+hpjvvX6DeOBd/YHjLQxNexQy0R6DjWFSjaezYQL03LFZEIDWrJfYBRULhXE7mVgKFCtJi5TLaFoGVusU57ApzwdoU+8CMOUgV+mNtjqluWHTtI4I22xAbyVX6mBix+hTv/Cj1G2fFePpvvsx3xDDYe51VtR6wgyE3B86bTMajZaduZCCkXSE6nicjvPIFQRAAuLKega+nxJ+iuhvoQAAAABJRU5ErkJggg==\" width=\"74\" height=\"24\" aria-hidden=\"true\" style=\"margin-bottom:16px\" alt=\"Google\" class=\"CToWUd\" data-bit=\"iit\"><div style=\"font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word\"><div style=\"font-size:24px\">E-poçtunuzu doğrulayın </div></div><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left\">Hesabinizi dogrulamaq ucun asagidaki koddan istifade edin : <br><div style=\"text-align:center;font-size:36px;margin-top:20px;line-height:44px\">{randint.ToString()}</div><br>Bu kodun vaxtı 24 saat sonra bitəcək.<br><br></div></div><div style=\"text-align:left\"><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\"><div>Google Hesabı və xidmətlərinə edilən mühüm dəyişikliklərdən xəbərdar olmaq üçün bu e-məktubu aldınız.</div><div style=\"direction:ltr\">© 2023 Google LLC, <a class=\"m_1943207792933616446afal\" style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\">1600 Amphitheatre Parkway, Mountain View, CA 94043, USA</a></div></div></div></td><td width=\"8\" style=\"width:8px\"></td></tr></tbody></table></td></tr><tr height=\"32\" style=\"height:32px\"><td></td></tr></tbody></table></div></div><div class=\"yj6qo\"></div><div class=\"yj6qo\"></div></div><div id=\":op\" class=\"ii gt\" style=\"display:none\"><div id=\":oo\" class=\"a3s aiL \"></div></div><div class=\"hi\"></div></div>";
            Notification notification = new Notification("Registration Code", message, "Boss Az");
            notification.DateTime = DateTime.Now; // Set time of notification

            isHtml = true; // Enable Html formatting

            // Send Notification via SMTP

            Thread thread = new Thread(() => sendMail(email!, notification));
            thread.IsBackground = false;
            thread.Start();
            Console.Write("Please enter the registration code : ");
            int code = Convert.ToInt32(Console.ReadLine());

            return (code == randint);
        }

        public static void registration(DataBase dataBase, Action<DataBase, User> addDatabase) {

            Console.Write("Please enter the name : ");
            string? name = Console.ReadLine();
            Console.Write("Please enter the surname : ");
            string? surname = Console.ReadLine();
            Console.Write("Please enter the username : ");
            string? username = Console.ReadLine();
            Console.Write("Please enter the email : ");
            string? email = Console.ReadLine();
            Console.Write("Please enter the password : ");
            string? password = Console.ReadLine();
            Console.Write("Please enter the age : ");
            string? ages = Console.ReadLine();
            bool isAge = int.TryParse(ages, out int age);
            if (!isAge) throw new Exception("Age can't be any character !"); // Checking if age doesn't contains any char.
            Console.Write("Please enter the city : ");
            string? city = Console.ReadLine();
            Console.Write("Please enter the phone number : ");
            string? phone = Console.ReadLine();
            Console.Write("Please enter the budget amount : ");
            string? budgetstr = Console.ReadLine();
            bool isBudget = int.TryParse(budgetstr, out int budget);
            if (!isBudget) throw new Exception("Budget can't be any character !"); // Checking if budget doesn't contains any char.

            bool isRegistrationCode = checkRegistrationCode(email!);

            if (isRegistrationCode) { // Checking if registration code is true
                User user = new User(username!, email!, password!); // create user
                user.Name = name!;
                user.Surname = surname!;
                user.Age = age;
                user.City = city!;
                user.Phone = phone!;
                user.Budget = budget;

                addDatabase(dataBase, user);

                Notification notification = new Notification("Sign Uped", "You have signed up succsessfuly", "Boss Az");
                notification.DateTime = DateTime.Now;
                Notification adminNotification = new("New User", $"{user.Name} signed up in {notification.DateTime}", "Boss Az");
                Admin.Notifications.Add(adminNotification); // Send admin notification

                Thread thread = new Thread(() => sendMail(email!, notification));
                thread = new Thread(() => sendMail(email!, notification)); ;
                thread.IsBackground = false;
                thread.Start();
            }
        }
    }
}
