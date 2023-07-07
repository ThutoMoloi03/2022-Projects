using PoppelProject1.BusinessLayer;
using PoppelProject1.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelProject1.PresentationLayer
{
    public partial class CustomerRegistrationForm : Form
    {
        #region Data Members
        private Customer customer;
        private CustomerController customerController;//
        public bool employeeFormClosed = false;

        #endregion

        #region Property Method

        public Customer Customer
        {

            set
            {

                customer = value;
            }

        }

        #endregion

        #region Constructor
        public CustomerRegistrationForm(CustomerController aController)
        {
            InitializeComponent();
            customerController = aController;
        }

        #endregion
        #region Utility methods
        private void ShowAll(bool value, Customer customer)
        {
            label1.Visible = value;
            label2.Visible = value;
            label3.Visible = value;
            label4.Visible = value;
            label5.Visible = value;
            label6.Visible = value;
            label7.Visible = value;



        }
        private void ClearAll()
        {
            IDtxt.Text = "";
            Nametxt.Text = "";
            Surnametxt.Text = "";
            Emailtxt.Text = "";
            Phonetxt.Text = "";
            Addresstxt.Text = "";
            CreditScoretxt.Text = "";
        }
        private void PopulateObject()
        {

            customer = new Customer();
            customer.ID = IDtxt.Text;
            customer.Name = Nametxt.Text;
            customer.Surname = Surnametxt.Text;
            customer.Email = Emailtxt.Text;
            customer.Telephone = Phonetxt.Text;
            customer.DeliveryAddress = Addresstxt.Text;
            customer.CreditScore = CreditScoretxt.Text;

        }

        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateObject();
            MessageBox.Show("To be submitted to the Database!");

            customerController.DataMaintenance(customer, DB.DBOperation.Add);
            customerController.FinalizeChanges(customer);
            ClearAll();
            
        }

        private void CustomerRegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
