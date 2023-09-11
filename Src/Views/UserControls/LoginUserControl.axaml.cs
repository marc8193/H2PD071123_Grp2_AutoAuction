using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Src.Views.UserControls;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class LoginUserControl : UserControl
{
    RegisterUserControl registerUC = new RegisterUserControl();
    public LoginUserControl()
    {
        InitializeComponent();
        
    }
     void LoginBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(registerUC.GetInstanse());       
    }
 
}