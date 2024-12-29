using GoodCharmePerfume.DAO;
using GoodCharmePerfume.DTO;
using GoodCharmePerfume.GUI.Admin.Product;
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
    public partial class fOrder : Form
    {
        public fOrder()
        {
            InitializeComponent();
        }

        #region Methods
        public void LoadOrdersInfoList()
        {
            dgvOrder.DataSource = OrdersInfoDAO.Instance.GetOrdersInfoList();
        }

        public void LoadOrderStatusList()
        {
            cboStatus.Items.Clear();
            List<OrderStatusDTO> list = OrderStatusDAO.Instance.GetOrderStatusList();
            OrderStatusDTO allItem = new OrderStatusDTO { MaTT = "", TinhTrang = "Tất cả" };
            list.Insert(0, allItem);
            cboStatus.DataSource = list;
            cboStatus.DisplayMember = "TinhTrang";
            cboStatus.ValueMember = "MaTT";
            cboStatus.SelectedIndex = 0;
        }

        public void LoadPaymentMethodsList()
        {
            cboPayment.Items.Clear();
            List<PaymentMethodsDTO> list = PaymentMethodsDAO.Instance.GetOrderStatusList();
            PaymentMethodsDTO allItem = new PaymentMethodsDTO { MaPTTT = "", TenPTTT = "Tất cả" };
            list.Insert(0, allItem);
            cboPayment.DataSource = list;
            cboPayment.DisplayMember = "TenPTTT";
            cboPayment.ValueMember = "MaPTTT";
            cboPayment.SelectedIndex = 0;
        }

        private void CustomizeDataGridView()
        {
            DataGridViewImageColumn editImageColumn = new DataGridViewImageColumn();
            editImageColumn.Name = "EditColumn";
            editImageColumn.HeaderText = "Chỉnh sửa";
            editImageColumn.Image = Properties.Resources.edit;
            dgvOrder.Columns.Add(editImageColumn);

            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "DeleteColumn";
            deleteImageColumn.HeaderText = "Xóa";
            deleteImageColumn.Image = Properties.Resources.delete;
            dgvOrder.Columns.Add(deleteImageColumn);

            dgvOrder.EnableHeadersVisualStyles = false;
            dgvOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvOrder.RowTemplate.Height = 40;

            dgvOrder.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            dgvOrder.Columns["HoTenKH"].HeaderText = "Khách hàng";
            dgvOrder.Columns["HoTenNV"].HeaderText = "Nhân viên";
            dgvOrder.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvOrder.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgvOrder.Columns["TenPTTT"].HeaderText = "Phương thức thanh toán";

            dgvOrder.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvOrder.Columns["MaDH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns["NgayDat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns["TinhTrang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns["TenPTTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrder.Columns["MaKH"].Visible = false;
            dgvOrder.Columns["MaNV"].Visible = false;
            dgvOrder.Columns["MATT"].Visible = false;
            dgvOrder.Columns["MAPTTT"].Visible = false;
        }

        private void SetColumnWidthsInPercentage()
        {
            int totalWidth = dgvOrder.Width;

            dgvOrder.Columns["MaDH"].Width = (int)(0.1 * totalWidth);
            dgvOrder.Columns["HoTenKH"].Width = (int)(0.2 * totalWidth);
            dgvOrder.Columns["HoTenNV"].Width = (int)(0.2 * totalWidth);
            dgvOrder.Columns["NgayDat"].Width = (int)(0.13 * totalWidth);
            dgvOrder.Columns["TinhTrang"].Width = (int)(0.13 * totalWidth);
            dgvOrder.Columns["TenPTTT"].Width = (int)(0.13 * totalWidth);
            dgvOrder.Columns["EditColumn"].Width = (int)(0.05 * totalWidth);
            dgvOrder.Columns["DeleteColumn"].Width = (int)(0.05 * totalWidth);

            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = oExcel.Workbooks.Add(Type.Missing);
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã đơn hàng";
            cl1.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Mã khách hàng";
            cl2.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Họ tên khách hàng";
            cl3.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Mã nhân viên";
            cl4.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Họ tên nhân viên";
            cl5.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Ngày đặt";
            cl6.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Tình trạng";
            cl7.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Phương thức thanh toán";
            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowHead.Font.Name = "Times New Roman";
            rowHead.Font.Size = "11";

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            int rowStart = 4;
            int colStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int colEnd = dataTable.Columns.Count;
            Microsoft.Office.Interop.Excel.Range c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart];
            Microsoft.Office.Interop.Excel.Range cN = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd];
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c0, cN);
            range.Value2 = arr;
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            oSheet.get_Range(c0, cN).Font.Name = "Times New Roman";
            oSheet.get_Range(c0, cN).Font.Size = "11";
            oSheet.get_Range(c0, cN).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c03 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 2];
            Microsoft.Office.Interop.Excel.Range cN3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 2];
            oSheet.get_Range(c03, cN3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Microsoft.Office.Interop.Excel.Range c05 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 4];
            Microsoft.Office.Interop.Excel.Range cN5 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 4];
            oSheet.get_Range(c05, cN5).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
        }
        #endregion

        #region Events
        private void fOrder_Load(object sender, EventArgs e)
        {
            LoadOrdersInfoList();
            LoadOrderStatusList();
            LoadPaymentMethodsList();
            CustomizeDataGridView();
            this.SizeChanged += fOrder_SizeChanged;
            SetColumnWidthsInPercentage();
        }

        private void fOrder_SizeChanged(object sender, EventArgs e)
        {
            if (dgvOrder.Columns.Count > 0)
            {
                SetColumnWidthsInPercentage();
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == dgvOrder.Columns["EditColumn"].Index)
            {
                fAddEditOrder f = new fAddEditOrder();
                f.Text = "Chỉnh sửa thông tin đơn hàng";
                f.LoadData(dgvOrder.Rows[e.RowIndex]);
                f.ShowDialog();
            }

            if (e.ColumnIndex == dgvOrder.Columns["DeleteColumn"].Index)
            {
                if (MessageBox.Show("Bạn muốn xóa đơn hàng này? Tất cả thông tin liên quan cũng sẽ bị xóa.\r\n\r\nBạn có thực sự muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string maDH = dgvOrder.Rows[e.RowIndex].Cells["MaDH"].Value.ToString();
                    if (OrderDAO.Instance.DeleteOrder(maDH))
                    {
                        MessageBox.Show("Đã xóa đơn hàng thành công.", "Thông báo", MessageBoxButtons.OK);
                        LoadOrdersInfoList();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa đơn hàng.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvOrder.Columns[e.ColumnIndex].Name;
            if (e.RowIndex == -1 || columnName == "EditColumn" || columnName == "DeleteColumn")
            {
                return;
            }
            DataGridViewRow selectedRow = dgvOrder.CurrentRow;
            fAddEditOrder f = new fAddEditOrder();
            f.Text = "Chỉnh sửa thông tin đơn hàng";
            f.LoadData(selectedRow);
            f.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoOrderId.Checked)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    dgvOrder.DataSource = OrdersInfoDAO.Instance.GetOrdersInfoListByOrderId(txtSearch.Text);
                }
                else
                {
                    LoadOrdersInfoList();
                }
            }
            else if (rdoStatus.Checked)
            {
                if (cboStatus.SelectedValue != null)
                {
                    string selectedValue = cboStatus.SelectedValue.ToString();

                    if (string.IsNullOrEmpty(selectedValue))
                    {
                        LoadOrdersInfoList();
                    }
                    else
                    {
                        dgvOrder.DataSource = OrdersInfoDAO.Instance.GetOrdersInfoListByStatusId(selectedValue);
                    }
                }
            }
            else
            {
                if (cboPayment.SelectedValue != null)
                {
                    string selectedValue = cboPayment.SelectedValue.ToString();

                    if (string.IsNullOrEmpty(selectedValue))
                    {
                        LoadOrdersInfoList();
                    }
                    else
                    {
                        dgvOrder.DataSource = OrdersInfoDAO.Instance.GetOrdersInfoListByPaymentId(selectedValue);
                    }
                }
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            cboPayment.SelectedIndex = 0;
            LoadOrdersInfoList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //fAddEditOrder f = new fAddEditOrder();
            //f.Text = "Thêm hoá đơn mới";
            //f.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //List<MovieDetailDTO> list = MovieDetailDAO.Instance.GetListMoiveDetail();
            //rptMovie r = new rptMovie();
            //r.SetDataSource(list);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaDH");
            DataColumn col2 = new DataColumn("MaKH");
            DataColumn col3 = new DataColumn("HoTenKH");
            DataColumn col4 = new DataColumn("MaNV");
            DataColumn col5 = new DataColumn("HoTenNV");
            DataColumn col6 = new DataColumn("NgayDat");
            DataColumn col7 = new DataColumn("TinhTrang");
            DataColumn col8 = new DataColumn("TenPTTT");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);

            foreach (DataGridViewRow dgvRow in dgvOrder.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaDH"].Value;
                row[1] = dgvRow.Cells["MaKH"].Value;
                row[2] = dgvRow.Cells["HoTenKH"].Value;
                row[3] = dgvRow.Cells["MaNV"].Value;
                row[4] = dgvRow.Cells["HoTenNV"].Value;
                row[5] = ((DateTime)dgvRow.Cells["NgayDat"].Value).ToString("dd/MM/yyyy");
                row[6] = dgvRow.Cells["TinhTrang"].Value;
                row[7] = dgvRow.Cells["TenPTTT"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFile(dataTable, "Đơn hàng", "DANH SÁCH ĐƠN HÀNG");
        }
        #endregion
    }
}
