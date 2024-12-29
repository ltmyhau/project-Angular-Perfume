using GoodCharmePerfume.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Admin.Customer
{
    public partial class fAddEditCustoner : Form
    {
        public fAddEditCustoner()
        {
            InitializeComponent();

            txtCustomerID.Text = CustomerDAO.Instance.GetNextMaKH();
            btnSave.Visible = false;
            btnAdd.Location = new Point(557, 333);
        }

        #region Methods

        public void LoadData(DataGridViewRow selectedRow)
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            string maKH = selectedRow.Cells["MaKH"].Value?.ToString();
            txtCustomerID.Text = maKH;
            txtCustomerName.Text = selectedRow.Cells["HoTenKH"].Value?.ToString();
            dtpDate.Value = DateTime.Parse(selectedRow.Cells["NgaySinh"].Value?.ToString());
            txtPhoneNumber.Text = selectedRow.Cells["DienThoai"].Value?.ToString();
            txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString();
            txtAddress.Text = selectedRow.Cells["DiaChi"].Value?.ToString();
            string gioiTinh = selectedRow.Cells["GioiTinh"].Value?.ToString();
            switch (gioiTinh)
            {
                case "Nam":
                    rdoMale.Checked = true;
                    break;
                case "Nữ":
                    rdoFemale.Checked = true;
                    break;
                default:
                    rdoOther.Checked = true;
                    break;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }

        private bool InsertCustomerToDatabase()
        {
            string hoTenKH = txtCustomerName.Text;
            DateTime ngaySinh = dtpDate.Value;
            string dienThoai = txtPhoneNumber.Text;
            string email = !string.IsNullOrEmpty(txtEmail.Text.Trim()) ? txtEmail.Text.Trim() : null;
            string diaChi = !string.IsNullOrEmpty(txtAddress.Text.Trim()) ? txtAddress.Text.Trim() : null;

            string gioiTinh;
            if (rdoMale.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (rdoFemale.Checked)
            {
                gioiTinh = "Nữ";
            }
            else
            {
                gioiTinh = "Khác";
            }

            return CustomerDAO.Instance.InsertCustomer(hoTenKH, gioiTinh, ngaySinh, dienThoai, email, diaChi);
        }

        private bool UpdateCustomerToDatabase()
        {
            string maKH = txtCustomerID.Text;
            string hoTenKH = txtCustomerName.Text;
            DateTime ngaySinh = dtpDate.Value;
            string dienThoai = txtPhoneNumber.Text;
            string email = !string.IsNullOrEmpty(txtEmail.Text.Trim()) ? txtEmail.Text.Trim() : null;
            string diaChi = !string.IsNullOrEmpty(txtAddress.Text.Trim()) ? txtAddress.Text.Trim() : null;

            string gioiTinh;
            if (rdoMale.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (rdoFemale.Checked)
            {
                gioiTinh = "Nữ";
            }
            else
            {
                gioiTinh = "Khác";
            }

            return CustomerDAO.Instance.UpdateCustomer(maKH, hoTenKH, gioiTinh, ngaySinh, dienThoai, email, diaChi);
        }
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (InsertCustomerToDatabase())
            {
                fCustomer f = Application.OpenForms.OfType<fCustomer>().FirstOrDefault();
                if (f != null)
                {
                    f.LoadCustomerList();
                }
                MessageBox.Show("Đã thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm khách hàng vào CSDL.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (UpdateCustomerToDatabase())
            {
                fCustomer f = Application.OpenForms.OfType<fCustomer>().FirstOrDefault();
                if (f != null)
                {
                    f.LoadCustomerList();
                }
                MessageBox.Show("Đã chỉnh sửa thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi chỉnh sửa thông tin khách hàng.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
