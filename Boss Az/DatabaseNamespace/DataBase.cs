using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.MembersNamespace;

namespace Boss.DatabaseNamespace {
    public class DataBase {

        // Static Fields

        private static Admin _currentAdmin;
        private static Worker _currentWorker;
        private static Employer _currentEmployer;

        // Private Fields

        private Admin[] _admins = new Admin[1];
        private List<Worker> _workers = new();
        private List<Employer> _employers = new();

        // Properties

        public Admin[] Admins { get { return _admins; } set { _admins = value; } }
        public List<Worker> Workers { get { return _workers; } set { _workers = value; } }
        public List<Employer> Employers { get { return _employers; } set { _employers = value; } }
        public static Admin currentAdmin { get { return _currentAdmin; } }

        // Constructors

        public DataBase() { 
            Admin admin1 = new Admin("Hasanhttps", "hasanabdullazad@gmail.com", "2000Hasan");
            admin1.Age = 15;
            admin1.Name = "Hesen";
            admin1.Surname = "Abdullazade";
            admin1.City = "Baku";
            _admins[0] = admin1;

            Worker worker = new();
            worker.Age = 16;
            worker.Name = "Rustem";
            worker.Surname = "Hesenli";
            worker.City = "Baku";
            worker.Email = "clientrustem2000@gmail.com";
            worker.UserName = "rustemHh";
            worker.Password = "2000Rustem";
            Workers.Add(worker);

            Employer employer = new();
            employer.Age = 16;
            employer.Name = "Rustem";
            employer.Surname = "Hesenli";
            employer.City = "Baku";
            employer.Email = "rustamh2006@gmail.com";
            employer.UserName = "rustemHh";
            employer.Password = "2000Rustem";
            Employers.Add(employer);
        }

        // Functions

        public bool checkAdmin(string username, string password) {
            foreach (Admin admin in _admins) {
                if ((admin.UserName == username || admin.Email == username) && admin.Password == password) {
                    _currentAdmin = admin;
                    return true;
                }
            } return false;
        }

        public bool checkWorker(string username, string password) {
            foreach (Worker worker in Workers) {
                if ((worker.Name == username || worker.Email == username) && worker.Password == password) {
                    _currentWorker = worker;
                    return true;
                }
            } return false;
        }

        public bool checkEmployer(string username, string password) {
            foreach (Employer employer in Employers) {
                if ((employer.Name == username || employer.Email == username) && employer.Password == password) {
                    _currentEmployer = employer;
                    return true;
                }
            } return false;
        }
    }
}
