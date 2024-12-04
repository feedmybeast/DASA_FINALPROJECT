using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DASA_FinalProject_01
{
    public partial class Excercise01Form : Form
    {
        private CircularLinkedList employeeList;
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public Excercise01Form()
        {
            InitializeComponent();
            employeeList = new CircularLinkedList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id) && !string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                Employee employee = new Employee(id, txtName.Text, txtPosition.Text);
                employeeList.InsertAtEnd(employee);
                txtID.Clear();
                txtName.Clear();
                txtPosition.Clear();
                employeeList.PrintList(lstEmployees);
            }
            else
            {
                MessageBox.Show("Please enter valid employee details.");
            }
        }

        private void btnRemoveFirst_Click(object sender, EventArgs e)
        {
            employeeList.RemoveFirst();
            employeeList.PrintList(lstEmployees);
        }

        private void btnRemoveLast_Click(object sender, EventArgs e)
        {
            employeeList.RemoveLast();
            employeeList.PrintList(lstEmployees);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            employeeList.PrintList(lstEmployees);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                Node foundNode = employeeList.Search(id);
                if (foundNode != null)
                {
                    MessageBox.Show($"Employee found: {foundNode.Data}");
                }
                else
                {
                    MessageBox.Show($"Employee with ID {id} not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid employee ID.");
            }
        }
    }
}
