using GoodCharmePerfume.DAO;
using GoodCharmePerfume.DTO;
using GoodCharmePerfume.GUI.Admin.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Admin.Order
{
    public partial class fEditOrder : Form
    {
        public fEditOrder()
        {
            InitializeComponent();

            btnSave.Visible = false;
            btnAdd.Location = new Point(636, 248);
            LoadOrderStatusList();
            LoadPaymentMethodsList();
        }

        #region Methods

        public void LoadOrderStatusList()
        {
            cboStatus.Items.Clear();
            List<OrderStatusDTO> list = OrderStatusDAO.Instance.GetOrderStatusList();
            cboStatus.DataSource = list;
            cboStatus.DisplayMember = "TinhTrang";
            cboStatus.ValueMember = "MaTT";
        }

        public void LoadPaymentMethodsList()
        {
            cboPayment.Items.Clear();
            List<PaymentMethodsDTO> list = PaymentMethodsDAO.Instance.GetOrderStatusList();
            cboPayment.DataSource = list;
            cboPayment.DisplayMember = "TenPTTT";
            cboPayment.ValueMember = "MaPTTT";
        }

        string maKH = "";
        string maNV = "";

        public void LoadData(DataGridViewRow selectedRow)
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            string maHD = selectedRow.Cells["MaDH"].Value?.ToString();
            txtOrderID.Text = maHD;
            maKH = selectedRow.Cells["MaKH"].Value?.ToString(); ;
            txtCustomerID.Text = maKH;
            txtCustomerName.Text = selectedRow.Cells["HoTenKH"].Value?.ToString();
            maNV = selectedRow.Cells["MaNV"].Value?.ToString();
            txtEmployeeID.Text = maNV;
            txtEmployeeName.Text = selectedRow.Cells["HoTenNV"].Value?.ToString();
            dtpDate.Value = DateTime.Parse(selectedRow.Cells["NgayDat"].Value?.ToString());
            string selectedStatusId = selectedRow.Cells["MaTT"].Value?.ToString();
            if (!string.IsNullOrEmpty(selectedStatusId))
            {
                cboStatus.SelectedValue = selectedStatusId;
            }
            string selectedPaymentId = selectedRow.Cells["MaPTTT"].Value?.ToString();
            if (!string.IsNullOrEmpty(selectedPaymentId))
            {
                cboPayment.SelectedValue = selectedPaymentId;
            }
            LoadOrderDetai(maHD);
            CustomizeDataGridView();
            SetColumnWidthsInPercentage();
        }

        public void LoadOrderDetai(string orderId)
        {
            dgvOrderDetail.DataSource = OrderDetailDAO.Instance.GetOrderDetailListByOrderID(orderId);
        }

        private void CustomizeDataGridView()
        {
            dgvOrderDetail.EnableHeadersVisualStyles = false;
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvOrderDetail.RowTemplate.Height = 30;

            dgvOrderDetail.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvOrderDetail.Columns["TenSP"].HeaderText = "Sản phẩm";
            dgvOrderDetail.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvOrderDetail.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvOrderDetail.Columns["ThanhTien"].HeaderText = "Thành tiền";

            dgvOrderDetail.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrderDetail.Columns["MaDH"].Visible = false;
        }

        private void SetColumnWidthsInPercentage()
        {
            int totalWidth = dgvOrderDetail.Width;

            dgvOrderDetail.Columns["MaSP"].Width = (int)(0.15 * totalWidth);
            dgvOrderDetail.Columns["TenSP"].Width = (int)(0.3 * totalWidth);
            dgvOrderDetail.Columns["GiaBan"].Width = (int)(0.2 * totalWidth);
            dgvOrderDetail.Columns["SoLuong"].Width = (int)(0.15 * totalWidth);
            dgvOrderDetail.Columns["ThanhTien"].Width = (int)(0.2 * totalWidth);

            dgvOrderDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerID.Focus();
                return false;
            }
            return true;
        }

        private bool UpdateOrderToDatabase()
        {
            string maDH = txtOrderID.Text;
            string maTT = cboStatus.SelectedValue.ToString();
            string maPTTT = cboPayment.SelectedValue.ToString();
            DateTime ngayDat = dtpDate.Value;

            return OrderDAO.Instance.UpdateOrder(maDH, maKH, maNV, maTT, maPTTT, ngayDat);
        }
        #endregion

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (UpdateOrderToDatabase())
            {
                fOrder f = Application.OpenForms.OfType<fOrder>().FirstOrDefault();
                if (f != null)
                {
                    f.LoadOrdersInfoList();
                }
                MessageBox.Show("Đã chỉnh sửa thông tin đơn hàng thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi chỉnh sửa thông tin đơn hàng.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            string customerId = txtCustomerID.Text.Trim();
            if (!string.IsNullOrEmpty(customerId))
            {
                List<CustomerDTO> list = CustomerDAO.Instance.GetCustomerListById(customerId);
                if (list != null && list.Count > 0)
                {
                    maKH = list[0].MaKH.ToString();
                    txtCustomerName.Text = list[0].HoTenKH.ToString();
                }
                else
                {
                    maKH = "";
                    txtCustomerName.Text = "";
                }
            }
            else
            {
                maKH = "";
                txtCustomerName.Text = "";
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            string employeeId = txtEmployeeID.Text.Trim();
            if (!string.IsNullOrEmpty(employeeId))
            {
                List<EmployeeDTO> list = EmployeeDAO.Instance.GetEmployeeListById(employeeId);
                if (list != null && list.Count > 0)
                {
                    maNV = list[0].MaNV.ToString();
                    txtEmployeeName.Text = list[0].HoTenNV.ToString();
                }
                else
                {
                    maNV = "";
                    txtEmployeeName.Text = "Online";
                }
            }
            else
            {
                maNV = "";
                txtEmployeeName.Text = "Online";
            }
        }
        #endregion
    }
}
