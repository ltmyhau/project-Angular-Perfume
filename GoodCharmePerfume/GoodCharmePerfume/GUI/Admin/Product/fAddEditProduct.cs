using GoodCharmePerfume.DAO;
using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodCharmePerfume.GUI.Admin.Product
{
    public partial class fAddEditProduct : Form
    {
        public fAddEditProduct()
        {
            InitializeComponent();

            txtProductId.Text = ProductDAO.Instance.GetNextMaSP();
            btnSave.Visible = false;
            btnAdd.Location = new Point(572, 385);
            LoadProductTypeList();
        }

        #region Methods

        public void LoadProductTypeList()
        {
            cboProductType.Items.Clear();
            List<ProductTypeDTO> list = ProductTypeDAO.Instance.GetProductTypeList();
            cboProductType.DataSource = list;
            cboProductType.DisplayMember = "TenLoaiSP";
            cboProductType.ValueMember = "MaLoaiSP";
        }

        public void LoadData(DataGridViewRow selectedRow)
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            string maSP = selectedRow.Cells["MaSP"].Value?.ToString();
            txtProductId.Text = maSP;
            txtProductName.Text = selectedRow.Cells["TenSP"].Value?.ToString();
            txtPrice.Text = selectedRow.Cells["GiaBan"].Value?.ToString();
            txtCapacity.Text = selectedRow.Cells["DungTich"].Value?.ToString();
            txtStockQuantity.Text = selectedRow.Cells["SoLuongTon"].Value?.ToString();
            txtDescription.Text = selectedRow.Cells["MoTa"].Value?.ToString();
            dtpAddedDate.Value = DateTime.Parse(selectedRow.Cells["NgayThem"].Value?.ToString());

            string selectedProductTypeId = selectedRow.Cells["MaLoaiSP"].Value?.ToString();
            if (!string.IsNullOrEmpty(selectedProductTypeId))
            {
                cboProductType.SelectedValue = selectedProductTypeId;
            }

            //if (selectedRow.Cells["HinhSP"].Value != null)
            //{
            //    byte[] productImgData = (byte[])selectedRow.Cells["HinhSP"].Value;
            //    using (MemoryStream ms = new MemoryStream(productImgData))
            //    {
            //        picProductImg.Image = System.Drawing.Image.FromStream(ms);
            //    }
            //}
            if (selectedRow.Cells["HinhSP"].Value != null)
            {
                string base64String = selectedRow.Cells["HinhSP"].Value.ToString();
                if (base64String.StartsWith("data:image"))
                {
                    int base64Index = base64String.IndexOf("base64,") + "base64,".Length;
                    base64String = base64String.Substring(base64Index);
                }

                try
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picProductImg.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Hình ảnh không hợp lệ hoặc bị lỗi: " + ex.Message);
                }
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return false;
            }
            if (!int.TryParse(txtPrice.Text, out int giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }
            if (!int.TryParse(txtStockQuantity.Text, out int soLuongTon) || giaBan <= 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockQuantity.Focus();
                return false;
            }
            return true;
        }

        private bool InsertProductToDatabase()
        {
            string tenSP = txtProductName.Text.Trim();
            string maLoaiSP = cboProductType.SelectedValue.ToString();
            int giaBan = int.Parse(txtPrice.Text);
            int dungTich = !string.IsNullOrEmpty(txtCapacity.Text.Trim()) ? int.Parse(txtCapacity.Text) : 0;
            int soLuongTon = int.Parse(txtStockQuantity.Text);
            DateTime ngayThem = dtpAddedDate.Value;
            string moTa = !string.IsNullOrEmpty(txtDescription.Text.Trim()) ? txtDescription.Text.Trim() : null;
            string hinhSP = GetProductImgData();

            return ProductDAO.Instance.InsertProduct(maLoaiSP, tenSP, giaBan, dungTich, soLuongTon, hinhSP, ngayThem, moTa);
        }

        private string GetProductImgData()
        {
            if (picProductImg.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    if (picProductImg.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        picProductImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                    else
                    {
                        picProductImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            else
            {
                return null;
            }
        }

        private bool UpdateProductToDatabase()
        {
            string maSP = txtProductId.Text.Trim();
            string tenSP = txtProductName.Text.Trim();
            string maLoaiSP = cboProductType.SelectedValue.ToString();
            int giaBan = int.Parse(txtPrice.Text);
            int dungTich = !string.IsNullOrEmpty(txtCapacity.Text.Trim()) ? int.Parse(txtCapacity.Text) : 0;
            int soLuongTon = int.Parse(txtStockQuantity.Text);
            DateTime ngayThem = dtpAddedDate.Value;
            string moTa = !string.IsNullOrEmpty(txtDescription.Text.Trim()) ? txtDescription.Text.Trim() : null;
            string hinhSP = string.IsNullOrEmpty(image) ? GetCurrentProductImg(maSP) : GetProductImgData();

            return ProductDAO.Instance.UpdateProduct(maSP, maLoaiSP, tenSP, giaBan, dungTich, soLuongTon, hinhSP, ngayThem, moTa);
        }

        private string GetCurrentProductImg(string maSP)
        {
            string productImg = ProductDAO.Instance.GetProductImgByProductID(maSP);
            return productImg ?? "";
        }
        #endregion

        #region Events
        OpenFileDialog ofd = new OpenFileDialog();
        string image = "";

        private void btnUpLoadImg_Click(object sender, EventArgs e)
        {
            //ofd.InitialDirectory = @"D:\";
            ofd.InitialDirectory = @"D:\Downloads\products"; 
            ofd.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = ofd.FileName.ToString();
                picProductImg.ImageLocation = image;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (InsertProductToDatabase())
            {
                fProduct fProduct = Application.OpenForms.OfType<fProduct>().FirstOrDefault();
                if (fProduct != null)
                {
                    fProduct.LoadProductList();
                }
                MessageBox.Show("Đã thêm sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm sản phẩm vào CSDL.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (UpdateProductToDatabase())
            {
                fProduct fProduct = Application.OpenForms.OfType<fProduct>().FirstOrDefault();
                if (fProduct != null)
                {
                    fProduct.LoadProductList();
                }
                MessageBox.Show("Đã chỉnh sửa thông tin sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi chỉnh sửa thông tin sản phẩm.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
