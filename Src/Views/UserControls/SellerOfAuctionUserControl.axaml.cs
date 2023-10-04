using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Splat;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SellerOfAuctionUserControl : UserControl
{
    HomeScreenUserControl? HomeScreenUC { get; set; }
    public SellerOfAuctionUserControl()
    {
        InitializeComponent();

    }
    public SellerOfAuctionUserControl(HomeScreenUserControl homeScreenUC)
    {
        InitializeComponent();
        this.HomeScreenUC = homeScreenUC;
    }

    void AcceptBtn(object sender, RoutedEventArgs e)
    {

    }
    void BackBtn (object sender, RoutedEventArgs e) 
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }
   
}