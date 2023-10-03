using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class YourBidHistoryUserControl : UserControl
{
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public YourBidHistoryUserControl()
    {
        InitializeComponent();
    }
    public YourBidHistoryUserControl(HomeScreenUserControl homeScreenUC)
    {
        InitializeComponent();
       this.HomeScreenUC = homeScreenUC;
    }

    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }
}