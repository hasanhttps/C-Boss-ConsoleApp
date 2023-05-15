using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static Boss.Functions.Functions;

namespace Boss.ModelsNamespace {
    public class Vacancie {

        // Private Fields

        private readonly Guid _id;
        private readonly DateTime _announceDate;
        private DateTime _expireAnnounceDate;
        private string? _experience;
        private string? _company;
        private string? _city;
        private string? _job;
        private string? _age;
        private int _payment;
        private int _salary;

        // Properties

        public Guid Id { get { return _id; } }
        public string? Job { get { return _job; } set { _job = value; } }
        public string? Age { get { return _age; } set { _age = value; } }
        public string? Company { get { return _company; } set { _company = value; } }
        public string? City { get { return _city; } set { _city = value; } }
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
        public int Payment { get { return _payment; } 
            set {
                try {
                    if (value < 0) throw new Exception("Payment couldn't be lower than zero !");
                    _payment = value;
                    int days = _payment * 7;
                    ExpireAnnounceDate = DateTime.Now.AddDays(days);
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
                }
            } 
        }
        public string? Experience { get { return _experience; } set { _experience = value; } }
        public DateTime AnnounceDate { get { return _announceDate; } }
        public DateTime ExpireAnnounceDate { get { return _expireAnnounceDate; } set { _expireAnnounceDate = value; } }

        // Constructors

        public Vacancie() {
            _id = Guid.NewGuid();
            _announceDate = DateTime.Now;
        }
        public Vacancie(string? experience, string? company,
            string? city, string? job, string? age, int salary, int payment) : this()
        {
            Experience = experience;
            Company = company;
            City = city;
            Job = job;
            Salary = salary;
            Age = age;
            Payment = payment;
        }

        // Functions

        public override string ToString() {
            return $"Id : {Id} \n" +
                   $"Job : {Job} \n" +
                   $"Age : {Age} \n" +
                   $"City : {City} \n" +
                   $"Salary : {Salary} \n" +
                   $"Payment : {Payment} \n" +
                   $"Company : {Company} \n" +
                   $"Experience : {Experience} \n" +
                   $"Announce Date : {AnnounceDate} \n" +
                   $"Expire of Announce Date : {ExpireAnnounceDate} \n";
        }
    }
}
