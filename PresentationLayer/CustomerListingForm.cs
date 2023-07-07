using PoppelProject1.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelProject1.DatabaseLayer;
using PoppelProject1.BusinessLayer;
using static System.Windows.Forms.AxHost;

namespace PoppelProject1.PresentationLayer
{
    public partial class CustomerListingForm : Form
    {

        #region Variables
        public bool listFormClosed;
        private Collection<Customer> customers;
        private CustomerController customerController;
        private Customer customer;
        #endregion

        #region Constructor
        public CustomerListingForm(CustomerController custController)
        {
            InitializeComponent();
            customerController = custController;

            //this.Load += CustomerListForm_Load;
            //this.Activated += CustomerListForm_Activated;
            // this.FormClosed += EmployeeListingForm_FormClosed;

        }
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

        #region The List View
        public void setUpCustomerListView()
        {
            ListViewItem customerDetails;

            listView1.Clear();
            listView1.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(1, "CustomerID", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(2, "Name", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(3, "Surname", 150, HorizontalAlignment.Left);
            listView1.Columns.Insert(4, "Email", 100, HorizontalAlignment.Left);
            listView1.Columns.Insert(5, "Phone", 150, HorizontalAlignment.Left);
            listView1.Columns.Insert(6, "CreditScore", 150, HorizontalAlignment.Left);
            listView1.Columns.Insert(7, "DeliveryAddress", 150, HorizontalAlignment.Left);

            customers = customerController.Allcustomers;
            //Add employee details to each ListView item 
            foreach (Customer customer in customers)
            {
                customerDetails = new ListViewItem();
                customerDetails.Text = customer.ID.ToString();
                customerDetails.SubItems.Add(customer.ID.ToString());
                customerDetails.SubItems.Add(customer.Name);
                customerDetails.SubItems.Add(customer.Surname);
                customerDetails.SubItems.Add(customer.Email);
                customerDetails.SubItems.Add(customer.Telephone);
                customerDetails.SubItems.Add(customer.CreditScore);
                customerDetails.SubItems.Add(customer.DeliveryAddress);
                listView1.Items.Add(customerDetails);
            }
            listView1.Refresh();
            listView1.GridLines = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerRegistrationForm form = new CustomerRegistrationForm(customerController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
        private void CustomerListForm_Activated(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            setUpCustomerListView();

        }

        private void CustomerListingForm_Load(object sender, EventArgs e)
        {

            listView1.View = View.Details;
            setUpCustomerListView();


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
