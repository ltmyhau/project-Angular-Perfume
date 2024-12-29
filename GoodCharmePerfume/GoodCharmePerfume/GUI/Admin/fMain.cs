using GoodCharmePerfume.DTO;
using GoodCharmePerfume.GUI.Admin.Category;
using GoodCharmePerfume.GUI.Admin.Customer;
using GoodCharmePerfume.GUI.Admin.Employee;
using GoodCharmePerfume.GUI.Admin.Order;
using GoodCharmePerfume.GUI.Admin.Product;
using GoodCharmePerfume.GUI.Admin.Statistic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Admin
{
    public partial class fMain : Form
    {
        EmployeeDTO employee;

        fOrder fOrder;
        fCategory fCategory;
        fProduct fProduct;
        fCustomer fCustomer;
        fEmployee fEmployee;
        fStatistic fStatistic;
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (fCustomer == null)
            {
                fCustomer = new fCustomer();
                fCustomer.FormClosed += fCustomer_FormClosed;
                fCustomer.MdiParent = this;
                fCustomer.Dock = DockStyle.Fill;
                fCustomer.Show();
            }
            else
            {
                fCustomer.Activate();
            }
        }

        private void fCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            fCustomer = null;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (fEmployee == null)
            {
                fEmployee = new fEmployee();
                fEmployee.FormClosed += fEmployee_FormClosed;
                fEmployee.MdiParent = this;
                fEmployee.Dock = DockStyle.Fill;
                fEmployee.Show();
            }
            else
            {
                fEmployee.Activate();
            }
        }

        private void fEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            fEmployee = null;
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            if (fStatistic == null)
            {
                fStatistic = new fStatistic();
                fStatistic.FormClosed += fStatistic_FormClosed;
                fStatistic.MdiParent = this;
                fStatistic.Dock = DockStyle.Fill;
                fStatistic.Show();
            }
            else
            {
                fStatistic.Activate();
            }
        }

        private void fStatistic_FormClosed(object sender, FormClosedEventArgs e)
        {
            fStatistic = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
