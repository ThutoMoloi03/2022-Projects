using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelProject1.BusinessLayer;

namespace PoppelProject1.PresentationLayer
{
    public partial class MDIParentForm : Form
    {

        #region Variables
        private int childFormNumber = 0;
        private CustomerRegistrationForm customerRegistrationForm;
        private CustomerListingForm customerListForm;
        private CustomerController customerController;
        private ProductListingForm productListForm;
        private ProductController productController;
        private OrderForm orderForm;
        private OrderController orderController;
        private OrderListingForm orderListingForm;

        #endregion
        public MDIParentForm()
        {
            InitializeComponent();
            customerController = new CustomerController();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerListForm = new CustomerListingForm(customerController);
            customerListForm.setUpCustomerListView();
            customerListForm.Show();
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRegistrationForm form = new CustomerRegistrationForm(customerController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void listAvailableProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productListForm = new ProductListingForm(productController);
            productListForm.setUpProductListView();
            productListForm.Show();
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm(orderController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void pickingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderListingForm form = new OrderListingForm(orderController);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
    }
}
