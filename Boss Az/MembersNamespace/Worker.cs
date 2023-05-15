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
    public sealed class Worker : User, INotifable {

        // Private Fields

        private List<Cv> _cvs = new();

        // Properties

        public List<Cv> Cvs { get { return _cvs; } set { _cvs = value; } }

        // Constructors

        public Worker() { }
        public Worker(User user)
            : base(user.UserName, user.Email, user.Password, user.Budget, user)
        { }

        // Functions

        public override string ToString() { 
            return base.ToString();
        }

        public void showNotifications() {
            foreach(var notification in Notifications) {
                Console.WriteLine(notification);
            }PressAnyKey();
        }

        public void addCv(Cv? cv) {
            try {
                if (cv != null) { Cvs!.Add(cv); }
                else throw new ArgumentNullException(nameof(cv));
            }catch (ArgumentNullException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void addNotification(Notification notification) {
            Notifications.Add(notification);
        }

    }
}
