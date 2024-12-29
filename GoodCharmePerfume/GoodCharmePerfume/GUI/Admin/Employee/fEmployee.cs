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

namespace GoodCharmePerfume.GUI.Admin.Employee
{
    public partial class fEmployee : Form
    {
        public fEmployee()
        {
            InitializeComponent();
        }

        #region Methods
        public void LoadEmployeeList()
        {
            dgvEmloyee.DataSource = EmployeeDAO.Instance.GetEmployeeList();
        }

        private void CustomizeDataGridView()
        {
            DataGridViewImageColumn editImageColumn = new DataGridViewImageColumn();
            editImageColumn.Name = "EditColumn";
            editImageColumn.HeaderText = "Chỉnh sửa";
            editImageColumn.Image = Properties.Resources.edit;
            dgvEmloyee.Columns.Add(editImageColumn);

            DataGridViewImageColumn deleteImageColumn = new DataGridViewImageColumn();
            deleteImageColumn.Name = "DeleteColumn";
            deleteImageColumn.HeaderText = "Xóa";
            deleteImageColumn.Image = Properties.Resources.delete;
            dgvEmloyee.Columns.Add(deleteImageColumn);

            dgvEmloyee.EnableHeadersVisualStyles = false;
            dgvEmloyee.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 49);
            dgvEmloyee.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmloyee.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEmloyee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmloyee.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvEmloyee.RowTemplate.Height = 40;

            dgvEmloyee.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvEmloyee.Columns["HoTenNV"].HeaderText = "Họ tên";
            dgvEmloyee.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvEmloyee.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvEmloyee.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            dgvEmloyee.Columns["DienThoai"].HeaderText = "Điện thoại";

            dgvEmloyee.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEmloyee.Columns["NgayVaoLam"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvEmloyee.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmloyee.Columns["GioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmloyee.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmloyee.Columns["NgayVaoLam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmloyee.Columns["DienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmloyee.Columns["Email"].Visible = false;
            dgvEmloyee.Columns["DiaChi"].Visible = false;
            dgvEmloyee.Columns["HinhAnh"].Visible = false;
            dgvEmloyee.Columns["MaTK"].Visible = false;
        }

        private void SetColumnWidthsInPercentage()
        {
            int totalWidth = dgvEmloyee.Width;

            dgvEmloyee.Columns["MaNV"].Width = (int)(0.1 * totalWidth);
            dgvEmloyee.Columns["HoTenNV"].Width = (int)(0.25 * totalWidth);
            dgvEmloyee.Columns["GioiTinh"].Width = (int)(0.1 * totalWidth);
            dgvEmloyee.Columns["NgaySinh"].Width = (int)(0.15 * totalWidth);
            dgvEmloyee.Columns["NgayVaoLam"].Width = (int)(0.15 * totalWidth);
            dgvEmloyee.Columns["DienThoai"].Width = (int)(0.15 * totalWidth);
            dgvEmloyee.Columns["EditColumn"].Width = (int)(0.05 * totalWidth);
            dgvEmloyee.Columns["DeleteColumn"].Width = (int)(0.05 * totalWidth);

            dgvEmloyee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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
            cl1.Value2 = "Mã nhân viên";
            cl1.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Họ tên nhân viên";
            cl2.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Giới tính";
            cl3.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Ngày sinh";
            cl4.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Ngày vào làm";
            cl5.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Điện thoại";
            cl6.ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Email";
            cl7.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Địa chỉ";
            cl8.ColumnWidth = 50;

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

            Microsoft.Office.Interop.Excel.Range c02 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart + 1];
            Microsoft.Office.Interop.Excel.Range cN2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colStart + 1];
            oSheet.get_Range(c02, cN2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Microsoft.Office.Interop.Excel.Range c0N1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colEnd - 1];
            Microsoft.Office.Interop.Excel.Range cNN1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd - 1];
            oSheet.get_Range(c0N1, cNN1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Microsoft.Office.Interop.Excel.Range c0N = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colEnd];
            Microsoft.Office.Interop.Excel.Range cNN = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd];
            oSheet.get_Range(c0N, cNN).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
        }
        #endregion

        #region Events
        private void fEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
            CustomizeDataGridView();
            this.SizeChanged += fEmployee_SizeChanged;
            SetColumnWidthsInPercentage();
        }

        private void fEmployee_SizeChanged(object sender, EventArgs e)
        {
            if (dgvEmloyee.Columns.Count > 0)
            {
                SetColumnWidthsInPercentage();
            }
        }

        private void dgvEmloyee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == dgvEmloyee.Columns["EditColumn"].Index)
            {
                fAddEditEmloyee f = new fAddEditEmloyee();
                f.Text = "Thông tin nhân viên";
                f.LoadData(dgvEmloyee.Rows[e.RowIndex]);
                f.ShowDialog();
            }

            if (e.ColumnIndex == dgvEmloyee.Columns["DeleteColumn"].Index)
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này? Tất cả thông tin liên quan cũng sẽ bị xóa.\r\n\r\nBạn có thực sự muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string maNV = dgvEmloyee.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                    if (EmployeeDAO.Instance.DeleteEmployee(maNV))
                    {
                        MessageBox.Show("Đã xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK);
                        LoadEmployeeList();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvEmloyee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvEmloyee.Columns[e.ColumnIndex].Name;
            if (e.RowIndex == -1 || columnName == "EditColumn" || columnName == "DeleteColumn")
            {
                return;
            }
            DataGridViewRow selectedRow = dgvEmloyee.CurrentRow;
            fAddEditEmloyee f = new fAddEditEmloyee();
            f.Text = "Thông tin nhân viên";
            f.LoadData(selectedRow);
            f.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (rdoEmployeeID.Checked)
                {
                    dgvEmloyee.DataSource = EmployeeDAO.Instance.GetEmployeeListByEmployeeId(txtSearch.Text);
                }
                else
                {
                    dgvEmloyee.DataSource = EmployeeDAO.Instance.GetEmployeeListByEmployeeName(txtSearch.Text);
                }
            }
            else
            {
                LoadEmployeeList();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadEmployeeList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddEditEmloyee f = new fAddEditEmloyee();
            f.Text = "Thêm nhân viên mới";
            f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MaNV");
            DataColumn col2 = new DataColumn("HoTenNV");
            DataColumn col3 = new DataColumn("GioiTinh");
            DataColumn col4 = new DataColumn("NgaySinh");
            DataColumn col5 = new DataColumn("NgayVaoLam");
            DataColumn col6 = new DataColumn("DienThoai");
            DataColumn col7 = new DataColumn("Email");
            DataColumn col8 = new DataColumn("DiaChi");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);

            foreach (DataGridViewRow dgvRow in dgvEmloyee.Rows)
            {
                DataRow row = dataTable.NewRow();

                row[0] = dgvRow.Cells["MaNV"].Value;
                row[1] = dgvRow.Cells["HoTenNV"].Value;
                row[2] = dgvRow.Cells["GioiTinh"].Value;
                row[3] = ((DateTime)dgvRow.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                row[4] = ((DateTime)dgvRow.Cells["NgayVaoLam"].Value).ToString("dd/MM/yyyy");
                row[5] = dgvRow.Cells["DienThoai"].Value;
                row[6] = dgvRow.Cells["Email"].Value;
                row[7] = dgvRow.Cells["DiaChi"].Value;

                dataTable.Rows.Add(row);
            }

            ExportFile(dataTable, "Nhân viên", "DANH SÁCH NHÂN VIÊN");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //List<EmployeeDTO> list = EmployeeDAO.Instance.GetListEmployee();
            //rptEmployee r = new rptEmployee();
            //r.SetDataSource(list);
            //fReport f = new fReport();
            //f.crvReport.ReportSource = r;
            //f.ShowDialog();
        }

        #endregion
    }
}
