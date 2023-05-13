using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.Interfaces;
using Boss.ModelsNamespace;
using static Boss.Functions.Functions;

namespace Boss.MembersNamespace {
    public sealed class Employer : User, INotifable {

        // Private Fields

        private List<Vacancie> _vacancies = new();

        // Properties

        public List<Vacancie> Vacancies { get { return _vacancies; } set { _vacancies = value; } }

        // Constructors

        public Employer() { }
        public Employer(User user)
            : base(user.UserName, user.Email, user.Password, user.Budget, user)
        { }

        // Functions

        public override string ToString() { 
            return base.ToString();
        }
        
        public void showVacancies() {
            foreach(var vacancie in Vacancies) {
                Console.WriteLine(vacancie);
            }PressAnyKey();
        }

        public void showNotifications() {
            foreach (var notification in Notifications) {
                Console.WriteLine(notification);
            }PressAnyKey();
        }

        public void addVacancy(Vacancie? vacancie) {
            try {
                Console.WriteLine(vacancie);
                if (vacancie != null) { Vacancies.Add(vacancie); }
                else throw new ArgumentNullException(nameof(vacancie));
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }
        }

        public void addNotification(Notification? notification) {
            AddNotification(notification);
        }
    }
}
