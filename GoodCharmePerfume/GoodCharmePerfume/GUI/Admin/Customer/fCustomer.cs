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
    public partial class fCustomer : Form
    {
        public fCustomer()
        {
            InitializeComponent();
        }

        #region Methods
        public void LoadCustomerList()
        {
            dgvCustomer.DataSource = CustomerDAO.Instance.GetCustomerList();
        }

        private void CustomizeDataGridView()
        {
            DataGridViewImageColumn editImageColumn = new DataGridViewImageColumn();
            editImageColumn.Name = "EditColumn";
            editImageColumn.HeaderText = "Chỉnh sửa";
            editImageColumn.Image = Properties.Resources.edit;
            dgvCustomer.Columns.Add(editImageColumn);

            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "DeleteColumn";
            deleteImageColumn.HeaderText = "Xóa";
            deleteImageColumn.Image = Properties.Resources.delete;
            dgvCustomer.Columns.Add(deleteImageColumn);

            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCustomer.RowTemplate.Height = 40;

            dgvCustomer.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvCustomer.Columns["HoTenKH"].HeaderText = "Họ tên";
            dgvCustomer.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvCustomer.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvCustomer.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvCustomer.Columns["Email"].HeaderText = "Email";

            dgvCustomer.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCustomer.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["GioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["DienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCustomer.Columns["DiaChi"].Visible = false;
            dgvCustomer.Columns["Phuong"].Visible = false;
            dgvCustomer.Columns["Quan"].Visible = false;
            dgvCustomer.Columns["ThanhPho"].Visible = false;
            dgvCustomer.Columns["MaTK"].Visible = false;
            dgvCustomer.Columns["HinhAnh"].Visible = false;
        }

        private void SetColumnWidthsInPercentage()
        {
            int totalWidth = dgvCustomer.Width;

            dgvCustomer.Columns["MaKH"].Width = (int)(0.1 * totalWidth);
            dgvCustomer.Columns["HoTenKH"].Width = (int)(0.25 * totalWidth);
            dgvCustomer.Columns["GioiTinh"].Width = (int)(0.1 * totalWidth);
            dgvCustomer.Columns["NgaySinh"].Width = (int)(0.1 * totalWidth);
            dgvCustomer.Columns["DienThoai"].Width = (int)(0.15 * totalWidth);
            dgvCustomer.Columns["Email"].Width = (int)(0.2 * totalWidth);
            dgvCustomer.Columns["EditColumn"].Width = (int)(0.05 * totalWidth);
            dgvCustomer.Columns["DeleteColumn"].Width = (int)(0.05 * totalWidth);

            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "J1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã khách hàng";
            cl1.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Họ tên khách hàng";
            cl2.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Giới tính";
            cl3.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Ngày sinh";
            cl4.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Điện thoại";
            cl5.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Email";
            cl6.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Địa chỉ";
            cl7.ColumnWidth = 25;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Phường/ Xã";
            cl8.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Quận/ Huyện";
            cl9.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Tỉnh/Thành phố";
            cl10.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "J3");
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
            oSheet.get_Range(c0, cN).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c00 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart];
            Microsoft.Office.Interop.Excel.Range cN0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart];
            oSheet.get_Range(c00, cN0).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c02 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 2];
            Microsoft.Office.Interop.Excel.Range cN2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 2];
            oSheet.get_Range(c02, cN2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c03 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 3];
            Microsoft.Office.Interop.Excel.Range cN3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 3];
            oSheet.get_Range(c03, cN3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c04 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 4];
            Microsoft.Office.Interop.Excel.Range cN4 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 4];
            oSheet.get_Range(c04, cN4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        #endregion

        #region Events
        private void fCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
            CustomizeDataGridView();
            this.SizeChanged += fCustomer_SizeChanged;
            SetColumnWidthsInPercentage();
        }

        private void fCustomer_SizeChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.Columns.Count > 0)
            {
                SetColumnWidthsInPercentage();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == dgvCustomer.Columns["EditColumn"].Index)
            {
                fAddEditCustoner f = new fAddEditCustoner();
                f.Text = "Thông tin khách hàng";
                f.LoadData(dgvCustomer.Rows[e.RowIndex]);
                f.ShowDialog();
            }

            if (e.ColumnIndex == dgvCustomer.Columns["DeleteColumn"].Index)
            {
                if (MessageBox.Show("Bạn muốn xóa khách hàng này? Tất cả thông tin liên quan cũng sẽ bị xóa.\r\n\r\nBạn có thực sự muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string maKH = dgvCustomer.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                    if (CustomerDAO.Instance.DeleteCustomer(maKH))
                    {
                        MessageBox.Show("Đã xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK);
                        LoadCustomerList();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa khách hàng.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (e.RowIndex == -1 || columnName == "EditColumn" || columnName == "DeleteColumn")
            {
                return;
            }
            DataGridViewRow selectedRow = dgvCustomer.CurrentRow;
            fAddEditCustoner f = new fAddEditCustoner();
            f.Text = "Thông tin khách hàng";
            f.LoadData(selectedRow);
            f.ShowDialog();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomerList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (rdoCustomerID.Checked)
                {
                    dgvCustomer.DataSource = CustomerDAO.Instance.GetCustomerListByCustomerId(txtSearch.Text);
                }
                else
                {
                    dgvCustomer.DataSource = CustomerDAO.Instance.GetCustomerListByCustomerName(txtSearch.Text);
                }
            }
            else
            {
                LoadCustomerList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddEditCustoner f = new fAddEditCustoner();
            f.Text = "Thêm khách hàng mới";
            f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaKH");
            DataColumn col2 = new DataColumn("HoTenKH");
            DataColumn col3 = new DataColumn("GioiTinh");
            DataColumn col4 = new DataColumn("NgaySinh");
            DataColumn col5 = new DataColumn("DienThoai");
            DataColumn col6 = new DataColumn("Email");
            DataColumn col7 = new DataColumn("DiaChi");
            DataColumn col8 = new DataColumn("Phuong");
            DataColumn col9 = new DataColumn("Quan");
            DataColumn col10 = new DataColumn("ThanhPho");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);
            dataTable.Columns.Add(col10);

            foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaKH"].Value;
                row[1] = dgvRow.Cells["HoTenKH"].Value;
                row[2] = dgvRow.Cells["GioiTinh"].Value;
                row[3] = ((DateTime)dgvRow.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                row[4] = dgvRow.Cells["DienThoai"].Value;
                row[5] = dgvRow.Cells["Email"].Value;
                row[6] = dgvRow.Cells["DiaChi"].Value;
                row[7] = dgvRow.Cells["Phuong"].Value;
                row[8] = dgvRow.Cells["Quan"].Value;
                row[9] = dgvRow.Cells["ThanhPho"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFile(dataTable, "Khách hàng", "DANH SÁCH KHÁCH HÀNG");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //List<CustomerDTO> list = CustomerDAO.Instance.GetListCustomer();
            //rptCustomer r = new rptCustomer();
            //r.SetDataSource(list);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }
        #endregion
    }
}
