using Boss.DatabaseNamespace;
using Boss.MembersNamespace;
using Boss.ModelsNamespace;
using static Boss.Functions.Functions;
using static Boss.NetworkNamespace.Network;

namespace Boss {
    internal class Program {
        public static DataBase? dataBase = new(); 
        static void Main() {
            List<string> choose = new();
            choose.Add("Admin");
            choose.Add("User");
            choose.Add("Exit");
            var index = 1;

            while(index != -1) {
                index = Menu(choose);

                if (index == 0) {
                    ExceptionHandling(AdminChoose, dataBase!);
                }else if (index == 1) {
                    ExceptionHandling(UserChoose, dataBase!);
                }else if (index == 2) break;
            }
        }
    }
}