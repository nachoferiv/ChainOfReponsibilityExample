using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        EmployeeBLL employeeBLL;

        IList<Vacation> vacations = new List<Vacation>();
        IEmployee loggedEmployee = null;
        
        public MainForm()
        {
            InitializeComponent();
            employeeBLL = new EmployeeBLL();
            LoadDatagrid();
            createVacationButton.Enabled = false;
            buttonApprove.Enabled = false;
        }

        public void LoadDatagrid()
        {
            try
            {
                DataTable vacationsTable = new DataTable();
                vacationsTable.Columns.Add("ID", typeof(int));
                vacationsTable.Columns.Add("Number of days", typeof(int));
                vacationsTable.Columns.Add("Reason", typeof(string));
                vacationsTable.Columns.Add("Requester", typeof(string));
                vacationsTable.Columns.Add("Current Approver", typeof(string));
                vacationsTable.Columns.Add("Status", typeof(string));
                
                vacations = employeeBLL.GetAllVacations();
                foreach(Vacation v in vacations)
                {
                    vacationsTable.Rows.Add(
                        v.GetID(),
                        v.GetNumberOfDays(),
                        v.GetReason(),
                        v.GetRequester(),
                        v.GetCurrentApprover().GetUsername(),
                        v.GetStatus()
                        );
                }

                vacationsDatagridview.DataSource = vacationsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateVacation()
        {
            if(loggedEmployee == null)
            {
                MessageBox.Show("You must be logged in first");
                return;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginButton.Text == "Logout")
            {
                usernameTextbox.Text = string.Empty;
                usernameTextbox.Enabled = true;
                createVacationButton.Enabled = false;
                loggedEmployee = null;
                loginButton.Text = "Login";
                buttonApprove.Enabled = false;

                return;
            }

            string username = usernameTextbox.Text;
            if (username.Length == 0)
            {
                MessageBox.Show("Please enter a username");
                return;
            }
            
            try
            {
                loggedEmployee = employeeBLL.Login(username);
                createVacationButton.Enabled = true;
                buttonApprove.Enabled = true;

                usernameTextbox.Enabled = false;
                loginButton.Text = "Logout";

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void createVacationButton_Click(object sender, EventArgs e)
        {
            CreateVacationForm form = new CreateVacationForm(employeeBLL, loggedEmployee);
            form.ShowDialog();
            LoadDatagrid();
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (vacationsDatagridview.SelectedRows.Count != 1)
            {
                MessageBox.Show("Only one row must be selected");
                return;
            }

            if (loggedEmployee == null)
            {
                MessageBox.Show("First login");
                return;
            }


            try
            {
                int selectedRowIndex = vacationsDatagridview.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = vacationsDatagridview.Rows[selectedRowIndex];

                int vacationID = Convert.ToInt32(selectedRow.Cells[0].Value);
                Vacation vacation = employeeBLL.GetByID(vacationID);

                vacation = employeeBLL.HandleVacation((VacationHandler)loggedEmployee, vacation);

                employeeBLL.UpdateVacation(vacation);

                MessageBox.Show("Vacation handled");
                LoadDatagrid();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
