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

namespace GoodCharmePerfume.GUI.Admin.Employee
{
    public partial class fAddEditEmloyee : Form
    {
        public fAddEditEmloyee()
        {
            InitializeComponent();

            txtEmployeeID.Text = EmployeeDAO.Instance.GetNextMaNV();
            btnSave.Visible = false;
            btnAdd.Location = new Point(557, 333);
        }

        #region Methods

        public void LoadData(DataGridViewRow selectedRow)
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            string maNV = selectedRow.Cells["MaNV"].Value?.ToString();
            txtEmployeeID.Text = maNV;
            txtEmployeeName.Text = selectedRow.Cells["HoTenNV"].Value?.ToString();
            dtpDate.Value = DateTime.Parse(selectedRow.Cells["NgaySinh"].Value?.ToString());
            dtpStartWork.Value = DateTime.Parse(selectedRow.Cells["NgayVaoLam"].Value?.ToString());
            txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString();
            txtPhoneNumber.Text = selectedRow.Cells["DienThoai"].Value?.ToString();
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
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("Họ tên nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }

        private bool InsertEmployeeToDatabase()
        {
            string hoTenNV = txtEmployeeName.Text;
            DateTime ngaySinh = dtpDate.Value;
            DateTime ngayVaoLam = dtpStartWork.Value;
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

            return EmployeeDAO.Instance.InsertEmployee(hoTenNV, gioiTinh, ngaySinh, ngayVaoLam, dienThoai, email, diaChi);
        }

        private bool UpdateEmployeeToDatabase()
        {
            string maNV = txtEmployeeID.Text;
            string hoTenNV = txtEmployeeName.Text;
            DateTime ngaySinh = dtpDate.Value;
            DateTime ngayVaoLam = dtpStartWork.Value;
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

            return EmployeeDAO.Instance.UpdateEmployee(maNV, hoTenNV, gioiTinh, ngaySinh, ngayVaoLam, dienThoai, email, diaChi);
        }
        #endregion

        #region Events
        private void fAddEditEmloyee_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (InsertEmployeeToDatabase())
            {
                fEmployee f = Application.OpenForms.OfType<fEmployee>().FirstOrDefault();
                if (f != null)
                {
                    f.LoadEmployeeList();
                }
                MessageBox.Show("Đã thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm nhân viên vào CSDL.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (UpdateEmployeeToDatabase())
            {
                fEmployee f = Application.OpenForms.OfType<fEmployee>().FirstOrDefault();
                if (f != null)
                {
                    f.LoadEmployeeList();
                }
                MessageBox.Show("Đã chỉnh sửa thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi chỉnh sửa thông tin nhân viên.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
