using GoodCharmePerfume.DAO;
using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI
{
    public partial class fLogin : Form
    {
        EmployeeDTO employee;

        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;

            AccountDTO account = Login(userName, passWord);

            if (account != null)
            {
                EmployeeAccount(account.MaTK);

                switch (account.PhanQuyen)
                {
                    case "admin":
                        {
                            Admin.fMain f = new Admin.fMain(employee);
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                            break;
                        }
                    case "empl":
                        {
                            Employee.fMain f = new Employee.fMain(employee);
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
        }

        AccountDTO Login(string userName, string passWord)
        {
            List<AccountDTO> accounts = AccountDAO.Instance.Login(userName, passWord);
            if (accounts != null && accounts.Count > 0)
            {
                return accounts[0];
            }
            return null;
        }

        void EmployeeAccount(string accountId)
        {
            List<EmployeeDTO> employees = EmployeeDAO.Instance.GetEmployeeListByAccountId(accountId);
            if (employees != null && employees.Count > 0)
            {
                employee = employees[0];
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
