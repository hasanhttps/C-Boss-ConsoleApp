using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Members;
using Boss.ModelsNamespace;

namespace Boss.DatabaseNamespace {
    public class User : Person {

        // Private Fields

        private string _email;
        private string _username;
        private string _password;
        private List<Notification> _notifications;

        // Properties

        public string UserName { get { return _username; } set { _username = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } 
            set {
                try {
                    if (_password.Length < 8) throw new Exception("Password couldn't be lower than 8 character !");
                    _password = value;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } 
        }
        public List<Notification> Notifications { get { return _notifications; } set { _notifications = value; } }

        // Constructorcs

        public User() { }
        public User(string username, string email, string password) {
            UserName = username;
            Password = password;
            Email = email;
        }
        public User(string username, string email, string password, Person person)
            : base(person.Name, person.Surname, person.City, person.Phone, person.Age){
            UserName = username;
            Password = password;
            Email = email;
        }

        // Functions

        public void AddNotification(Notification? notification) {
            try {
                if (notification != null) { Notifications.Add(notification); }
                else throw new ArgumentNullException(nameof(notification));
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
