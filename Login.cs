﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            label8.BackColor = Color.Transparent;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
        }
    }
}