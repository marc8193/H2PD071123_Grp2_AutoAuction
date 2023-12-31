using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using H2PD071123_Grp2_AutoAuction.Views;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class LoginUserControl : UserControl
{
    public LoginUserControl()
    {
        InitializeComponent();

        this.LoginVM = new LoginUserControlViewModel();

        this.DataContext = this.LoginVM;
    }

    public LoginUserControlViewModel LoginVM { get; set; }
    
    void CreateUserBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new RegisterUserControl(this));       
    }
    void LoginBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new HomeScreenUserControl());
    }

}