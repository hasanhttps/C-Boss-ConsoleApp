using Boss.ModelsNamespace;
using Boss.MembersNamespace;
using Boss.DatabaseNamespace;
using static Boss.Functions.Functions; // Functions class that contains all functions. (Menus, Send Notification etc.)
using static Boss.NetworkNamespace.Network; // This class provide us send mail.

namespace Boss {
    public class Program {

        static void Main() {
            Console.Title = "Boss Az";
            DataBase? dataBase = new();

            // GUI System

            var guessIndex = 1;

            while (guessIndex != -1) {
                guessIndex = GuessMenu(guessCheck, dataBase);
            }
            Console.Clear();

            // Menu System

            List<string> choose = new();
            choose.Add("Admin");
            choose.Add("User");
            choose.Add("Exit");
            var index = 1;

            while(index != -1) {
                index = Menu(choose);
                
                if (index == 0) {
                    ExceptionHandling(AdminChoose, dataBase!); // Admin Side of Program
                }else if (index == 1) {
                    ExceptionHandling(UserChoose, dataBase!); // User Side of Program
                }else if (index == 2) break;
            }dataBase!.Dispose();
        }
    }
}