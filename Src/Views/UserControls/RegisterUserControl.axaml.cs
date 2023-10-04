using AutoAuctionProjekt.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Views;
using System;
using System.Diagnostics;
using System.Drawing.Text;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class RegisterUserControl : UserControl
{
    // private TextBox CreditTextBox;
    public LoginUserControl? LoginUC { get; set; }
    public RegisterUserControl()
    {
        InitializeComponent();
    }
    public RegisterUserControl(LoginUserControl loginUC)
    {
        InitializeComponent();
        this.LoginUC = loginUC;

        // CreditTextBox = this.FindControl<TextBox>("CreditTextBox");
    }

    private void CorporateRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        // Show the CreditTextBox when CorporateRadioButton is checked
        CreditTextBox.IsVisible = true;
        CvrTextBox.IsVisible = true;

        zipCodeTextBox.IsVisible = false;
        CprTextBox.IsVisible = false;
    }

    private void CorporateRadioButton_Unchecked(object sender, RoutedEventArgs e)
    {
        // Hide the CreditTextBox when CorporateRadioButton is unchecked
        CreditTextBox.IsVisible = false;
        CvrTextBox.IsVisible = false;

        zipCodeTextBox.IsVisible = true;
        CprTextBox.IsVisible = true;

    }


    void RegisterBtn(object sender, RoutedEventArgs e)
    {
        var db = Database.Instance;

        string userName = UserNameTextBox.Text;
        string password = PasswordTextBox.Text;
        string passwordAgin = PasswordTextBoxAgain.Text;

        string zipCode = zipCodeTextBox.Text;
        string cvrNumber = CvrTextBox.Text;
        string credit = CreditTextBox.Text;
        string cprNumber = CprTextBox.Text;

        // Check which RadioButton is selected
        bool isCorporate = CorporateRadioButton.IsChecked == true;
        bool isPrivat = PrivateRadioButton.IsChecked == true;

        //Check for password match
        if (password != passwordAgin)
        {
            Debug.WriteLine("Passwords do not match");
            return;
        }

        if (userName == "" || password == "" || passwordAgin == "")
        {
            Debug.WriteLine("Field is empty");
            return;
        }

        if (isCorporate)
        {
            if (cvrNumber == "" || credit == "")
            {
                Debug.WriteLine("Field is empty");
                return;
            }
            // Get the credit value if Corporate is selected
            db.InsertUser(new CorporateUser(userName, password, Convert.ToUInt32(zipCode), Convert.ToUInt32(cvrNumber), Convert.ToDecimal(credit)));
        }
        else if (isPrivat)
        {
            if (zipCode == "" || cprNumber == "")
            {
                Debug.WriteLine("Field is empty");
                return;
            }
            db.InsertUser(new PrivateUser(userName, password, Convert.ToUInt32(zipCode), Convert.ToUInt32(cprNumber)));
        }

        // Navigate back to the LoginUserControl
        ContentAreaUserControl.Navigate(this.LoginUC!);
    }

    void CnclBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.LoginUC!);
    }
}