using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Manager : VacationHandler, IEmployee
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GetName() { return Name; }
        public string GetSurname() { return Username; }
        public string GetUsername() { return Username; }
        public string GetPosition() { return "manager"; }
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
            if (vacation.GetStatus() == EnumVacationStatus.APPROVED)
                throw new Exception("Vacation already approved");

            if (vacation.GetNumberOfDays() < 15)
            {
                vacation.Approve(this);
                return vacation;
            }

            return this.Superior.HandleVacation(vacation);
        }
    }
}
