﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Members {
    public class Person {

        // Private Fields

        private readonly Guid _id;
        private int _age;
        private string _name;
        private string _surname;
        private string _city;
        private string _phone;

        // Properties

        public Guid Id { get { return _id; } }
        public int Age { get { return _age; }
            set {
                try { 
                    if (value < 0 || value > 150) throw new Exception("Your age is not valid !");
                    _age = value;
                }
                catch (Exception ex) when (value < 0) {
                    Console.WriteLine($"{ex.Message} Age can't be lower than zero !");
                }
                catch (Exception ex) when (value > 150) {
                    Console.WriteLine($"{ex.Message} Age can't be higher than 150 !");
                }
            }
        }
        public string Name { get { return _name; }
            set {
                try {
                    if (value.Length >= 3) _name = value;
                    else throw new Exception("Name must be at least 3 characters !");
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }

        // Constructors

        public Person() {
            _id = Guid.NewGuid();
        }
        public Person(string name, string surname, string city, string phone, int age) 
            : this() 
        {
            Age = age;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
        }
    }
}