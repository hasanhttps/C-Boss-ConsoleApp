using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boss.Functions.Functions;

namespace Boss.ModelsNamespace {
    public class Cv {

        // Private Fields

        private Guid _id;
        private DateTime _startTime;
        private DateTime _endTime;
        private string? _job;
        private string? _school;
        private string? _skills;
        private string? _companies;
        private string? _foreignLanguages;
        private string? _gitUrl;
        private string? _linkedin;
        private string? _haveDifCert;
        private float _graduateScore;
        private int _payment;

        // Properties

        public Guid Id { get { return _id; } set { _id = value; } }
        public DateTime StartTime { get { return _startTime; } set { _startTime = value; } }
        public DateTime EndTime { get { return _endTime; } set { _endTime = value; } }
        public string? Job { get { return _job; } set { _job = value; } }
        public string? School { get { return _school; } set { _school = value; } }
        public string? Skills { get { return _skills; } set { _skills = value; } }
        public string? Companies { get { return _companies; } set { _companies = value; } }
        public string? ForeignLanguages { get { return _foreignLanguages; } set { _foreignLanguages = value; } }
        public string? Linkedin { get { return _linkedin; } set { _linkedin = value; } }
        public string? GitUrl { get { return _gitUrl; } set { _gitUrl = value; } }
        public string? HaveDifCert { get { return _haveDifCert; } set { _haveDifCert = value; } }
        public float GraduateScore { get { return _graduateScore; }  
            set {
                try {
                    if (value < 0) throw new Exception("Graduate Score could'nt be lower than zero !");
                    _graduateScore = value;
                }
                catch (Exception ex) {
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
                    _endTime = _startTime.AddDays(days);
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    PressAnyKey();
                }
            } 
        }

        // Constructors

        public Cv() { }

        public Cv(string? job, string? school, string? skills,
            string? companies, string? foreignLanguages, string? gitUrl, string? linkedin,
            float graduateScore, string? haveDifCert) : this()
        {
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

        // Functions

        public override string ToString() {
            return $"Id : {Id} \n" +
                   $"Job : {Job} \n" +
                   $"School : {School} \n" +
                   $"Skills : {Skills} \n" +
                   $"Companies : {Companies} \n" +
                   $"Foreign Languages : {ForeignLanguages} \n" +
                   $"Git Url : {GitUrl} \n" +
                   $"Linkedn : {Linkedin} \n" +
                   $"Graduate Score : {GraduateScore} \n" +
                   $"Difference Certificate : {HaveDifCert} \n";
        }
    }
}
