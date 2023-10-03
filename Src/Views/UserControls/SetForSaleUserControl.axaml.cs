using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Src.ViewModels;
using System;
using System.Diagnostics;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SetForSaleUserControl : UserControl
{
    public SellerOfAuctionUserControl? SellerOfAuctionUC {  get; set; }
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public SetForSaleUserControl()
    {
        InitializeComponent();

        DataContext = new SetForSaleUserControlViewModel();
            
    }
    public SetForSaleUserControl(HomeScreenUserControl homeScreenUC, SellerOfAuctionUserControl sellerOfAuctionUC)
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