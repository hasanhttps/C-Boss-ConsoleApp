using Boss.DatabaseNamespace;
using static Boss.Functions.Functions; // Functions class that contains all functions. (Menus, Send Notification etc.)
using static Boss.NetworkNamespace.Network; // This class provide us send mail.

namespace Boss {
    public class Program {
        static void Main() {

            Console.Title = "Boss Az";
            DataBase? dataBase = new();

            List<string> menu = new();
            menu.Add("Guest");
            menu.Add("Register");
            menu.Add("Exit");
            var index = 1;

            while (index != -1) {

                index = Menu(menu);

                if (index == 0) {
                    GuiSystem(dataBase!); // Call the guest menu 
                }else if (index == 1) {
                    MenuSystem(dataBase!); // Call the register menu
                }else if (index == 2) break;
            }
        }
    }
}