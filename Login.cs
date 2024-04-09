using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;

namespace Lab1_WeChat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Load += Login_Load;
            this.ControlBox = false;

        }
        private void Login_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            //label8.BackColor = Color.Transparent;
            labelLogin.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form Đăng ký tài khoản (RegisterForm)
            Register registerForm = new Register();

            // Hiển thị form Đăng ký tài khoản
            registerForm.ShowDialog();

        }

        /*private void label8_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Kiểm tra thông tin đăng nhập
            if (IsValidLogin(username, password))
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!");
                // Chuyển hướng đến form chính hoặc form khác
                MainChat mainForm = new MainChat();
                mainForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!");
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            // Thực hiện kiểm tra thông tin đăng nhập, ví dụ kiểm tra với tài khoản mặc định
            return (username == "NguyenTanLoc" && password == "20521548");
        }*/

        private void labelLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đăng nhập!");
            }
            else
            {
                string query = "SELECT * FROM people WHERE username= @user ";
                string connectionString = "Data Source=SQLiteData.db;Version=3;";

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                    DataTable dt = new DataTable();
                    cmd.Parameters.AddWithValue("@username", username);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string password = textBox2.Text;
                        string savedPassword = dt.Rows[0]["password"].ToString();
                        string email = dt.Rows[0]["email"].ToString();
                        // Kiểm tra mật khẩu
                        if (password == savedPassword)
                        {
                            MessageBox.Show("Đăng nhập thành công.");
                            // Chuyển hướng đến form chính hoặc form khác
                            MainChat mainForm = new MainChat();
                            mainForm.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác.");
                            SendPasswordByEmail(username, savedPassword, email);
                        }
                    }
                   
                    else
                    {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!");
                    }
                }
            }
        }
        private void SendPasswordByEmail(string username, string password, string email)
        {
            try
            {
                // Thiết lập thông tin email
                string senderEmail = "nguyentanlockbang12345@gmail.com"; // Địa chỉ email của người gửi
                string senderPassword = "07032002826562"; // Mật khẩu email của người gửi
                //string subject = "Password Recovery"; // Tiêu đề email
                string body = $"Your password is: {password}"; // Nội dung email

                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage(senderEmail, email);
                mail.Subject = "Password Recovery"; // Tiêu đề email
                mail.Body = $"Your password is: {password}"; // Nội dung email

                // Tạo đối tượng SmtpClient và thiết lập thông tin SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                // Gửi email
                smtpClient.Send(mail);

                MessageBox.Show("Mật khẩu đã được gửi lại qua email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                string connectionString = "Data Source=SQLiteData.db;Version=3;";
                string query = "SELECT password, email FROM people WHERE username=@username";

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                string savedPassword = dt.Rows[0]["password"].ToString();
                                string email = dt.Rows[0]["email"].ToString();

                                if (password == savedPassword)
                                {
                                    MessageBox.Show("Đăng nhập thành công.");
                                }
                                else
                                {
                                
                                    // Gọi phương thức SendPasswordByEmail để gửi lại mật khẩu qua email
                                    SendPasswordByEmail(username, savedPassword, email);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tên người dùng không tồn tại.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
