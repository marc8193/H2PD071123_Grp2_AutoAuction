using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class HomeScreenUserControl : UserControl
{
    HomeScreenUserControlViewModel HomeScreenVM { get; set; }

    public HomeScreenUserControl()
    {
        this.HomeScreenVM = new HomeScreenUserControlViewModel();

        var db = Database.Instance;
        
        this.HomeScreenVM.AddDataToAuctions(db.SelectAuctions());    
        this.HomeScreenVM.AddDataToYourAuctions(db.SelectYourAuctions(10));    
        
        this.DataContext = this.HomeScreenVM;
        
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
}