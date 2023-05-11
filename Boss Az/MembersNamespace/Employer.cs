using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.DatabaseNamespace;
using Boss.ModelsNamespace;

namespace Boss.MembersNamespace {
    public class Employer : User {

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
            }
        }
    }
}
