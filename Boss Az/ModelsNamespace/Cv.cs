using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.ModelsNamespace {
    public class Cv {

        // Private Fields

        private readonly DateTime _startTime;
        private DateTime _endTime;
        private string _job;
        private string _school;
        private string _skills;
        private string _companies;
        private string _foreignLanguages;
        private string _gitUrl;
        private string _linkedin;
        private int _graduateScore;
        private bool _haveDifCert;

        // Properties

        public int GraduateScore { get { return _graduateScore; }  
            set {
                try {
                    if (value < 0) throw new Exception("Graduate Score could'nt be lower than zero !");
                    _graduateScore = value;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } 
        }
        public DateTime StartTime { get { return _startTime; } }
        public DateTime EndTime { get { return _endTime; } set { _endTime = value; } }
        public string Job { get { return _job; } set { _job = value; } }
        public string School { get { return _school; } set { _school = value; } }
        public string Skills { get { return _skills; } set { _skills = value; } }
        public string Companies { get { return _companies; } set { _companies = value; } }
        public string ForeignLanguages { get { return _foreignLanguages; } set { _foreignLanguages = value; } }
        public string Linkedin { get { return _linkedin; } set { _linkedin = value; } }
        public string GitUrl { get { return _gitUrl; } set { _gitUrl = value; } }
        public bool HaveDifCert { get { return _haveDifCert; } set { _haveDifCert = value; } }

        // Constructors

        public Cv() { 
            _startTime = DateTime.Now;
        }
        public Cv(DateTime endTime, string job, string school, string skills,
            string companies, string foreignLanguages, string gitUrl, string linkedin,
            int graduateScore, bool haveDifCert) : this()
        {
            _endTime = endTime;
            Job = job;
            School = school;
            Skills = skills;
            Companies = companies;
            ForeignLanguages = foreignLanguages;
            GitUrl = gitUrl;
            Linkedin = linkedin;
            GraduateScore = graduateScore;
            HaveDifCert = haveDifCert;
        }
    }
}
