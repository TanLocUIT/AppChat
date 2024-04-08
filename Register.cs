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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckData();
            }
        }
    }
}
