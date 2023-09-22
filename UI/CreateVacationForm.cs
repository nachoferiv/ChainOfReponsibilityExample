using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class CreateVacationForm : MetroFramework.Forms.MetroForm
    {
        IEmployee loggedEmployee = null;
        EmployeeBLL employeeBLL = null;
        public CreateVacationForm(EmployeeBLL employeBLL , IEmployee loggedEmployee)
        {
            InitializeComponent();
            this.loggedEmployee = loggedEmployee;
            this.employeeBLL = employeBLL;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int numberOfDays = 0;
            try
            {
                string strNumberOfDays = textboxNumberOfDays.Text;
                if (strNumberOfDays.Length == 0)
                    throw new Exception();
                
                numberOfDays = Convert.ToInt32(strNumberOfDays);
                if(numberOfDays < 1 || numberOfDays > 21 ) throw new Exception();

            } catch {
                MessageBox.Show("Invalid number of days. Must be a number between 1 and 21");
                return;
            }

            string reason = reasonTextbox.Text;
            IEmployee superior = null;
            try {
                superior = employeeBLL.GetSuperior(loggedEmployee.GetUsername());
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                Vacation vacation = new Vacation(numberOfDays, reason, loggedEmployee.GetUsername(), superior);
                employeeBLL.CreateVacation(vacation);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Vacation created!");

            this.Close();
        }
    }
}
