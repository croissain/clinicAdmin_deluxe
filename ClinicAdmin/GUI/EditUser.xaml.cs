﻿using ClinicAdmin.BUS;
using System.Windows;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private EditUserBUS _editUserBUS;
        public EditUser(int userId)
        {
            InitializeComponent();
            _editUserBUS = EditUserBUS.getInstance();
            _editUserBUS.UserId = userId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _editUserBUS.BUSLayer_Loaded();
            txbUsername.Text = _editUserBUS.User.Username;
            txbFullname.Text = _editUserBUS.User.Fullname;
            txbEmail.Text = _editUserBUS.User.Email;
            txbAddress.Text = _editUserBUS.User.Address;
            txbPhone.Text = _editUserBUS.User.Phone;
            txbRole.Text = _editUserBUS.User.Role.Name;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string username = txbUsername.Text;
            string fulname = txbFullname.Text;
            string address = txbAddress.Text;
            string email = txbEmail.Text;
            string phone = txbPhone.Text;

            _editUserBUS.UpdateAccount(username, fulname, address, email, phone);
            this.Close();
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
