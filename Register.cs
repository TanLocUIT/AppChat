using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1_WeChat
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            textBox2.PasswordChar = '*';
        }
        private void CheckData()
        {
            // Lấy thông tin từ các TextBox
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            // Và các thông tin khác cần thiết

            // Kiểm tra tính hợp lệ của thông tin
            if (IsValidInput(username, password, email))
            {
                // Thực hiện thêm tài khoản mới vào cơ sở dữ liệu hoặc nguồn dữ liệu khác
                if (AddNewAccount(username, password, email))
                {
                    // Thêm tài khoản thành công
                    MessageBox.Show("Thêm tài khoản thành công!");
                    // Đóng form đăng ký sau khi thêm tài khoản
                    this.Close();
                }
                else
                {
                    // Thêm tài khoản không thành công
                    MessageBox.Show("Thêm tài khoản không thành công!");
                }
            }
            else
            {
                // Hiển thị thông báo lỗi nếu thông tin không hợp lệ
                MessageBox.Show("Thông tin không hợp lệ. Vui lòng kiểm tra lại!");
            }
        }

        private bool AddNewAccount(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        private bool IsValidInput(string username, string password, string email)
        {
            // Kiểm tra các trường thông tin có được nhập không rỗng
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Kiểm tra độ dài mật khẩu (ví dụ: ít nhất 6 ký tự)
            if (password.Length < 6)
            {
                return false;
            }

            // Kiểm tra định dạng email sử dụng Regular Expression
            if (!IsValidEmail(email))
            {
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Kiểm tra định dạng email sử dụng Regular Expression
            // Đây chỉ là một ví dụ đơn giản, bạn có thể sử dụng mẫu Regular Expression phức tạp hơn để kiểm tra định dạng email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }


        /*private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // Lấy đối tượng Graphics từ sự kiện Paint
            Graphics g = e.Graphics;

            // Lấy kích thước của Panel
            int diameter = Math.Min(((Panel)sender).Width, ((Panel)sender).Height);

            // Vẽ một hình tròn bên trong Panel
            g.FillEllipse(Brushes.Red, 0, 0, diameter, diameter);
        }*/
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckData();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
            this.Hide(); // Ẩn form đăng ky
        }

        private void pannel4_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.png; *.gif)|*.bmp;*.jpg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của hình ảnh đã chọn
                string imagePath = openFileDialog.FileName;

                // Hiển thị hình ảnh trong PictureBox
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = ((Panel)sender).Size; // Đảm bảo PictureBox có cùng kích thước với Panel
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(imagePath);

                // Xóa tất cả các controls hiện có trong Panel trước khi thêm PictureBox mới
                ((Panel)sender).Controls.Clear();

                // Thêm PictureBox mới vào Panel
                ((Panel)sender).Controls.Add(pictureBox);
            }
        }
    }
}
