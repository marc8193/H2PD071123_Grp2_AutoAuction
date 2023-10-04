using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class YourBidHistoryUserControl : UserControl
{
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public YourBidHistoryUserControlViewModel? BidHistoryVM { get; set; }

    public YourBidHistoryUserControl()
    {
        InitializeComponent();
    }
    public YourBidHistoryUserControl(HomeScreenUserControl homeScreenUC)
    {
        InitializeComponent();
        this.HomeScreenUC = homeScreenUC;

        this.BidHistoryVM = new YourBidHistoryUserControlViewModel();
        var db = Database.Instance;

        this.BidHistoryVM!.AddDataToYourBids(db.SelectYourBids(1));

        this.DataContext = this.BidHistoryVM;
    }

    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }
}