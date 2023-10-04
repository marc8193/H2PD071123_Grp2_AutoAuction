using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Views;
using System.Drawing.Text;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class RegisterUserControl : UserControl  
{
    public LoginUserControlView? LoginUC { get; set; }
    public RegisterUserControl()
    {
        InitializeComponent();
    }
    public RegisterUserControl(LoginUserControlView loginUC)
    {
        InitializeComponent();
        this.LoginUC = loginUC;
    }


    void RegisterBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.LoginUC!);
    }

}