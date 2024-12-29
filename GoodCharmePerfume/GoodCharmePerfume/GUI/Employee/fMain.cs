using GoodCharmePerfume.DTO;
using GoodCharmePerfume.GUI.Admin.Customer;
using GoodCharmePerfume.GUI.Employee.Category;
using GoodCharmePerfume.GUI.Employee.Order;
using GoodCharmePerfume.GUI.Employee.Product;
using GoodCharmePerfume.GUI.Employee.Sell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Employee
{
    public partial class fMain : Form
    {
        EmployeeDTO employee;

        fSell fSell;
        fOrder fOrder;
        fCategory fCategory;
        fProduct fProduct;

        public fMain(EmployeeDTO e)
        {
            InitializeComponent();
            this.employee = e;
            mdiProp();

            txtName.Text = employee.HoTenNV;

            foreach (Control control in flpSidebarTransition.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.Click += Button_Click;
                }
            }
        }

        #region Methods
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        #endregion

        #region Events
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.FromArgb(100, 105, 116);
            foreach (Control control in flpSidebarTransition.Controls)
            {
                if (control is Button && control != button)
                {
                    Button btn = (Button)control;
                    btn.BackColor = Color.FromArgb(33, 38, 49);
                }
            }
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (fSell == null)
            {
                fSell = new fSell();
                fSell.FormClosed += fSell_FormClosed;
                fSell.MdiParent = this;
                fSell.Dock = DockStyle.Fill;
                fSell.Show();
            }
            else
            {
                fSell.Activate();
            }
        }

        private void fSell_FormClosed(object sender, FormClosedEventArgs e)
        {
            fSell = null;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (fOrder == null)
            {
                fOrder = new fOrder();
                fOrder.FormClosed += fOrder_FormClosed;
                fOrder.MdiParent = this;
                fOrder.Dock = DockStyle.Fill;
                fOrder.Show();
            }
            else
            {
                fOrder.Activate();
            }
        }

        private void fOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            fOrder = null;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (fCategory == null)
            {
                fCategory = new fCategory();
                fCategory.FormClosed += fCategory_FormClosed;
                fCategory.MdiParent = this;
                fCategory.Dock = DockStyle.Fill;
                fCategory.Show();
            }
            else
            {
                fCategory.Activate();
            }
        }

        private void fCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            fCategory = null;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (fProduct == null)
            {
                fProduct = new fProduct();
                fProduct.FormClosed += fProduct_FormClosed;
                fProduct.MdiParent = this;
                fProduct.Dock = DockStyle.Fill;
                fProduct.Show();
            }
            else
            {
                fProduct.Activate();
            }
        }

        private void fProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            fProduct = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
