using Avalonia.Controls;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(); //bind to mainviewmodel
        ContentAreaUserControl.Navigate(new LoginUserControl());
    }
}