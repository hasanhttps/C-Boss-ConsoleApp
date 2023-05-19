using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.MembersNamespace;
using Boss.ModelsNamespace;
using static Boss.DatabaseNamespace.JsonHandling;
using static Boss.NetworkNamespace.Network;

namespace Boss.DatabaseNamespace {
    public sealed class DataBase : IDisposable {

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
            _admins = ReadData<List<Admin>>("admins");
            _workers = ReadData<List<Worker>>("workers");
            _employers = ReadData<List<Employer>>("employers");
            Admin.Notifications = ReadData<List<Notification>>("admin notifications");
            Admin.RequestedVacancies = ReadData<Dictionary<string, List<Vacancie>>>("Requested Vacancies");
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

        public void applyVacancies(string? id, string? adminName) {
            List<Vacancie> vacanciesToRemove = new();

            foreach (var keyValuePair in Admin.RequestedVacancies!) {
                foreach (var vacancie in keyValuePair.Value) {
                    if (vacancie.Id.ToString().Substring(0, 8) == id) {
                        foreach (var employer in Employers) {
                            if (keyValuePair.Key == employer.UserName) {
                                employer.addVacancy(vacancie);

                                Notification notification = new("Vacancy verified", $"Your {vacancie.AnnounceDate.ToString("d")} created vacancy had been verified by Admin", adminName);
                                employer.addNotification(notification);
                                saveData();

                                // Send Notification via SMTP

                                Thread thread = new Thread(() => sendMail(employer.Email!, notification));
                                thread.IsBackground = false;
                                thread.Start();
                            }
                        } vacanciesToRemove.Add(vacancie);
                    }
                }
                foreach (var vacancy in vacanciesToRemove) {
                    keyValuePair.Value.Remove(vacancy);
                }
            }saveData();
        }

        public Employer? FindEmployerByVacancyId(string? id) {
            foreach (var employer in Employers) {
                foreach (var vacancy in employer.Vacancies) {
                    if (vacancy.Id.ToString().Substring(0, 8) == id) {
                        return employer;
                    }
                }
            }return null;
        }

        public Worker? FindWorkerById(string? id) {
            foreach(var worker in Workers) {
                foreach(var cv in worker.Cvs) if (id == cv.Id.ToString().Substring(0,8)) return worker;
            }return null;
        }

        public void showVacancies() {
            foreach(var employer in Employers) {
                foreach(var vacancie in employer.Vacancies) {
                    if (vacancie.ExpireAnnounceDate >= DateTime.Now) Console.WriteLine(vacancie);
                }
            }
        }

        public void showCvs() {
            foreach(var worker in Workers) {
                foreach(var cv in worker.Cvs!) {
                    Console.WriteLine(cv);
                }
            }
        }

        public void Dispose() {
            saveData();
        }

        public void saveData() {
            WriteData<List<Worker>>(Workers, "workers");
            WriteData<List<Employer>>(Employers, "employers");
            WriteData<List<Admin>>(Admins, "admins");
            WriteData<List<Notification>>(Admin.Notifications, "admin notifications");
            WriteData<Dictionary<string, List<Vacancie>>>(Admin.RequestedVacancies, "Requested Vacancies");
        }
    }
}
