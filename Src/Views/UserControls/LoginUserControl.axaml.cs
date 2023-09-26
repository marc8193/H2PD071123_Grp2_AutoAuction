using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Views;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class LoginUserControl : UserControl
{
    public RegisterUserControl RegisterUC{ get; set; } 
    static LoginUserControl? Instance;
    public LoginUserControl()
    {

        this.RegisterUC = new RegisterUserControl(this); // constractor for RegisterUserControl property
        InitializeComponent();
        if(Instance == null) { Instance = this; }
    }
    public LoginUserControl GetInstanse()
    {
        return Instance == null ? new() : Instance;
    }
    void CreateUserBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.RegisterUC);       
    }
 
}