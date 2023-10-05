using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using static H2PD071123_Grp2_AutoAuction.ViewModels.HomeScreenUserControlViewModel;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class HomeScreenUserControl : UserControl
{
    HomeScreenUserControlViewModel HomeScreenVM { get; set; }
    public int UserId { get; set; }

    public HomeScreenUserControl(int userId = -1)
    {
        this.HomeScreenVM = new HomeScreenUserControlViewModel();

        var db = Database.Instance;

        this.HomeScreenVM.AddDataToAuctions(db.SelectAuctions());
        this.HomeScreenVM.AddDataToYourAuctions(db.SelectYourAuctions(10));

        this.DataContext = this.HomeScreenVM;

        this.UserId = userId;

        InitializeComponent();
    }

    void SetForSaleBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new SetForSaleUserControl(this, new SellerOfAuctionUserControl()));
    }
    void UserProfileBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new YourProfileUserControl(this));
    }
    void BidHistoryBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new YourBidHistoryUserControl(this));
    }

    void CurrentClick(object sender, SelectionChangedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new BuyerOfAuctionUserControl(((DisplayAuction)e.AddedItems[0]!).VhId, ((DisplayAuction)e.AddedItems[0]!).AucID));
    }

    void YourAuctionClick(object sender, SelectionChangedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new SellerOfAuctionUserControl(((DisplayAuction)e.AddedItems[0]!).AucID));
    }
}