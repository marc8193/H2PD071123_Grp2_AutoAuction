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
    public LoginUserControl? LoginUC { get; set; }
    public RegisterUserControl()
    {
        InitializeComponent();
    }
    public RegisterUserControl(LoginUserControl loginUC)
    {
        InitializeComponent();
        this.LoginUC = loginUC;
    }


    void RegisterBtn(object sender, RoutedEventArgs e)
    {
        var db = Database.Instance;

        //IF PRIVATE
        // string userName, string password, uint zipCode, uint cprNummer
        db.InsertUser(new PrivateUser("hey", "hey", 1234, 1234));

        //IF CORPORATE
        // (string userName, string password, uint zipCode, uint cvrNummer, decimal credit
        db.InsertUser(new CorporateUser("hey", "hey", 1234, 1234, 200));


        ContentAreaUserControl.Navigate(this.LoginUC!);
    }

}