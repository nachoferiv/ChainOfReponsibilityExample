using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employee : VacationHandler, IEmployee
    {
        private string Username;
        private string Name;
        private string Surname;
        public string GetName() { return Name; }
        public string GetSurname() { return Surname; }
        public string GetUsername() { return Username; }
        public string GetPosition() { return "employee"; }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetSurname(string surname)
        {
            this.Surname = surname;
        }

        public override Vacation HandleVacation(Vacation vacation)
        {
            throw new Exception("Employee cant handle vacations");
        }
    }
}
