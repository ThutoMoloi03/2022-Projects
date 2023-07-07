using PoppelProject1.BusinessLayer;
using PoppelProject1.DatabaseLayer;
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

namespace PoppelProject1.PresentationLayer
{
    public partial class ProductListingForm : Form
    {
        #region Variables
        public bool listFormClosed;
        private Collection<Product> products;
        private ProductController productController;
        private Product product;
        #endregion
        #region Constructor
        public ProductListingForm(ProductController prodController)
        {
            InitializeComponent();
            productController = prodController;
        }
        #endregion

        #region Property Method       
        public Product Product
        {
            set
            {
                product = value;
            }

        }
        #endregion

        #region The List View
        public void setUpProductListView()
        {
            ListViewItem productDetails;

            listView1.Clear();
            listView1.Columns.Insert(0, "ProductID", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(1, "Type", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(2, "Description", 120, HorizontalAlignment.Left);
            listView1.Columns.Insert(3, "QuantityOnHand", 150, HorizontalAlignment.Left);
            listView1.Columns.Insert(4, "Price(p/u)", 100, HorizontalAlignment.Left);
            
            productController = new ProductController();
            products = productController.Allproducts;
            //Add employee details to each ListView item 
            foreach (Product product in products)
            {
                productDetails = new ListViewItem();
                productDetails.Text = product.ProductID.ToString();
                //productDetails.SubItems.Add(product.ProductID.ToString());
                productDetails.SubItems.Add(product.ProductType);
                productDetails.SubItems.Add(product.Description);
                productDetails.SubItems.Add(product.QuantityOnHand.ToString());
                productDetails.SubItems.Add(product.Price.ToString());
                listView1.Items.Add(productDetails);

            }
            listView1.Refresh();
            listView1.GridLines = true;
        }

        #endregion

        private void ProductListingForm_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            setUpProductListView();
        }

        private void ProductListForm_Activated(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            setUpProductListView();

        }
    }
}
