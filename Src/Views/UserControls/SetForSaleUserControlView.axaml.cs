using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Src.ViewModels;
using System;
using System.Diagnostics;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SetForSaleUserControlView : UserControl
{
    public SellerOfAuctionUserControl? SellerOfAuctionUC {  get; set; }
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public SetForSaleUserControlView()
    {
        InitializeComponent();
        DataContext = new SetForSaleUserControlViewModel();
    }
    public SetForSaleUserControlView(HomeScreenUserControl homeScreenUC, SellerOfAuctionUserControl sellerOfAuctionUC)
    {
        InitializeComponent();
        this.HomeScreenUC=homeScreenUC;
       this.SellerOfAuctionUC=sellerOfAuctionUC;
    }


    void CancelBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }

    void CreateAuctionBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.SellerOfAuctionUC!);

    }
}