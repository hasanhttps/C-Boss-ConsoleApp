using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boss.Functions.Functions;

namespace Boss.ModelsNamespace {
    public class Vacancie {

        // Private Fields

        private readonly Guid _id;
        private readonly DateTime _announceDate;
        private DateTime _expireAnnounceDate;
        private string _experience;
        private string _company;
        private string _city;
        private string _job;
        private int _salary;
        private int _age;

        // Properties

        public Guid Id { get { return _id; } }
        public DateTime AnnounceDate { get { return _announceDate; } }
        public DateTime ExpireAnnounceDate { get { return _expireAnnounceDate; } set { _expireAnnounceDate = value; } }
        public string Experience { get { return _experience; } set { _experience = value; } }
        public string Company { get { return _company; } set { _company = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Job { get { return _job; } set { _job = value; } }
        public int Salary { get { return _salary; }
            set {
                try {
                    if (value < 0) throw new Exception("Salary couldn't be lower than zero !");
                    _salary = value;
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
                }
            } 
        }
        public int Age { get { return _age; }
            set {
                try {
                    if (value < 0 || value > 100) throw new Exception("Your age is not valid !");
                    _age = value;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
                }
            }
        }

        // Constructors

        public Vacancie() {
            _id = Guid.NewGuid();
            _announceDate = DateTime.Now;
        }
        public Vacancie(DateTime expireAnnounceDate, string experience, string company,
            string city, string job, int salary, int age) : this()
        {
            ExpireAnnounceDate = expireAnnounceDate;
            Experience = experience;
            Company = company;
            City = city;
            Job = job;
            Salary = salary;
            Age = age;
        }
    }
}
