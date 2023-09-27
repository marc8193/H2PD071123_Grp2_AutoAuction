using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SetForSaleUserControl : UserControl
{
    
    public HomeScreenUserControl HomeScreenUC { get; set; }
    public SetForSaleUserControl()
    {
        InitializeComponent();
    }
    public SetForSaleUserControl(HomeScreenUserControl homeScreenUC)
    {
        InitializeComponent();
        this.HomeScreenUC=homeScreenUC;
    }
  

    void CancelBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC);
    }

    void CreateAuctionBTN(object sender, RoutedEventArgs e)
    {

    }
}