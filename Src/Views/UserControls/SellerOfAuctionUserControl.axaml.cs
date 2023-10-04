using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using Splat;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SellerOfAuctionUserControl : UserControl
{
    HomeScreenUserControl? HomeScreenUC { get; set; }
    public SellerOfAuctionUserControl()
    {
        InitializeComponent();
    }
    public SellerOfAuctionUserControl(int id)
    {
        this.DataContext = new SellerOfAuctionUserControlViewModel(id);

        InitializeComponent();
    }

    void AcceptBtn(object sender, RoutedEventArgs e)
    {

    }
    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new HomeScreenUserControl());
    }



}