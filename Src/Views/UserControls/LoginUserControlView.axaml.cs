using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Views;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class LoginUserControlView : UserControl
{
    public HomeScreenUserControl HomeScreenUC { get; set; }
    public RegisterUserControl RegisterUC{ get; set; } 
    static LoginUserControlView? Instance;
    public LoginUserControlView()
    {
        this.HomeScreenUC = new HomeScreenUserControl();
        this.RegisterUC = new RegisterUserControl(this); // constractor for RegisterUserControl property
        InitializeComponent();
        if(Instance == null) { Instance = this; }
    }
    public LoginUserControlView GetInstanse()
    {
        return Instance == null ? new() : Instance;
    }
    void CreateUserBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.RegisterUC);       
    }
    void LoginBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC);
    }

}