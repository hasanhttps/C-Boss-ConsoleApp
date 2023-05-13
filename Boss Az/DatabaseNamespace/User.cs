using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Members;
using Boss.ModelsNamespace;
using static Boss.Functions.Functions;

namespace Boss.DatabaseNamespace {
    public class User : Person {

        // Private Fields

        private List<Notification> _notifications = new();
        private string _email;
        private string _username;
        private string _password;
        private int _budget;

        // Properties

        public string UserName { get { return _username; } set { _username = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } 
            set {
                try {
                    if (value.Length < 8) throw new Exception("Password couldn't be lower than 8 character !");
                    _password = value;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
                }
            } 
        }
        public int Budget { get { return _budget; }
            set {
                try {
                    if (value < 0) throw new Exception("Budget could'nt be lower than zero !");
                    _budget = value;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
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
        public User(string username, string email, string password, int budget, Person person)
            : base(person.Name, person.Surname, person.City, person.Phone, person.Age){
            UserName = username;
            Password = password;
            Email = email;
            Budget = budget;
        }

        // Functions

        public void AddNotification(Notification? notification) {
            try {
                if (notification != null) { Notifications.Add(notification); }
                else throw new ArgumentNullException(nameof(notification));
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }
        }

    }
}
