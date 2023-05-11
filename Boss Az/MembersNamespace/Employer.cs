﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.Interfaces;
using Boss.ModelsNamespace;
using static Boss.Functions.Functions;

namespace Boss.MembersNamespace {
    public class Employer : User, INotifable {

        // Private Fields

        private List<Vacancie> _vacancies;

        // Properties

        public List<Vacancie> Vacancies { get { return _vacancies; } set { _vacancies = value; } }

        // Constructors

        public Employer() { }
        public Employer(User user)
            : base(user.UserName, user.Email, user.Password, user)
        { }

        // Functions

        public void addVanacncie(Vacancie? vacancie) {
            try {
                if (vacancie != null) { Vacancies.Add(vacancie); }
                else throw new ArgumentNullException(nameof(vacancie));
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }
        }

        public void addNotification(Notification notification) {
            Notifications.Add(notification);
        }
    }
}
