using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.MembersNamespace;
using Boss.ModelsNamespace;
using static Boss.DatabaseNamespace.JsonHandling;

namespace Boss.DatabaseNamespace {
    public sealed class DataBase {

        // Static Fields

        private Admin? _currentAdmin;
        private Worker? _currentWorker;
        private Employer? _currentEmployer;

        // Private Fields

        private List<Admin> _admins = new();
        private List<Worker> _workers = new();
        private List<Employer> _employers = new();

        // Properties

        public List<Admin> Admins { get { return _admins; } set { _admins = value; } }
        public List<Worker> Workers { get { return _workers; } set { _workers = value; } }
        public List<Employer> Employers { get { return _employers; } set { _employers = value; } }
        public Admin? currentAdmin { get { return _currentAdmin; } }
        public Worker? currentWorker { get { return _currentWorker; } }
        public Employer? currentEmployer { get { return _currentEmployer; } }

        // Constructors

        public DataBase() {
            List<Admin> admins = ReadData<Admin>("admins");
            _admins = admins;

            List<Worker> workers = ReadData<Worker>("workers");
            _workers = workers;

            List<Employer> employers = ReadData<Employer>("employers");
            _employers = employers;
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
                if ((worker.UserName == username || worker.Email == username) && worker.Password == password) {
                    _currentWorker = worker;
                    return true;
                }
            } return false;
        }

        public bool checkEmployer(string username, string password) {
            foreach (Employer employer in Employers) {
                if ((employer.UserName == username || employer.Email == username) && employer.Password == password) {
                    _currentEmployer = employer;
                    return true;
                }
            } return false;
        }

        public void applyVacancies(string? id) {
            List<Vacancie> vacanciesToRemove = new();

            foreach (var keyValuePair in Admin.RequestedVacancies!) {
                foreach (var vacancie in keyValuePair.Value) {
                    if (vacancie.Id.ToString() == id) {
                        foreach (var employer in Employers) {
                            if (keyValuePair.Key == employer.UserName) {
                                employer.addVanacncie(vacancie);
                            }
                        } vacanciesToRemove.Add(vacancie);
                    }
                }
                foreach (var vacancy in vacanciesToRemove) {
                    keyValuePair.Value.Remove(vacancy);
                }
            }
        }

        public void showVacancies() {
            foreach(var employer in Employers) {
                foreach(var vacancie in employer.Vacancies) {
                    Console.WriteLine(vacancie);
                }
            }
        }

        public void saveData() {
            WriteData<List<Worker>>(Workers, "workers");
            WriteData<List<Employer>>(Employers, "employers");
            WriteData<List<Admin>>(Admins, "admins");
            
        }
    }
}
