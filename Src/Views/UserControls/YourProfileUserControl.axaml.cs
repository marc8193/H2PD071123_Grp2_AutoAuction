using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Reflection.Emit;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class YourProfileUserControl : UserControl
{
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public YourProfileUserControl()
    {
        InitializeComponent();
    }
    public YourProfileUserControl(HomeScreenUserControl homeScreenUC)
    {
        InitializeComponent();
        this.HomeScreenUC= homeScreenUC;
    }
    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }
}