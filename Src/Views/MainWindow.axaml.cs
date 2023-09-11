using Avalonia.Controls;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ContentAreaUserControl.Navigate(new LoginUserControl());
    }
}