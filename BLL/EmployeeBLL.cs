using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL EmployeeDAL;
        VacationDAL VacationDAL;
        VacationHandler VacationHandler;
        public EmployeeBLL() 
        { 
            EmployeeDAL = new EmployeeDAL();
            VacationDAL = new VacationDAL(EmployeeDAL);
        }

        public IEmployee GetByUsername(string username)
        {
           return this.EmployeeDAL.GetByUsername(username);
        }

        public IEmployee GetSuperior(string username)
        {
            return this.EmployeeDAL.GetSuperior(username);
        }

        public void CreateVacation(Vacation vacation)
        {
            this.VacationDAL.Create(vacation);
        }

        public void UpdateVacation(Vacation vacation)
        {
            this.VacationDAL.Update(vacation);
        }

        public IList<Vacation> GetAllVacations()
        {
            return this.VacationDAL.GetAll();
        }

        public Vacation GetByID(int id)
        {
            return this.VacationDAL.GetByID(id);
        }

        public IEmployee Login(string username)
        {
            IEmployee employee =  EmployeeDAL.GetByUsername(username);
            LoadSuperior(employee.GetUsername(), (VacationHandler)employee);
            
            return employee;
        }

        private void LoadSuperior(string username, VacationHandler employee)
        {
            IEmployee superior = this.GetSuperior(username);
            if (superior == null)
                return;
            
            employee.SetSuperior((VacationHandler)superior);
            LoadSuperior(superior.GetUsername(), (VacationHandler)superior);
        }

        public Vacation HandleVacation(VacationHandler handler, Vacation vacation)
        {
            return handler.HandleVacation(vacation);
        }
    }
}
