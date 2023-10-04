using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using H2PD071123_Grp2_AutoAuction.Views;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class BuyerOfAuctionUserControl : UserControl
{
    public BuyerOfAuctionUserControl()
    {
        InitializeComponent();
    }

    public BuyerOfAuctionUserControl(int id)
    {
        this.DataContext = new BuyerOfAuctionUserControlViewModel(id);

        InitializeComponent();
    }
    void MakeBidBtn(object sender, RoutedEventArgs e)
    {
        makeBidControl.IsVisible = true;
    }

    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new HomeScreenUserControl());
    }

    private void MakeBidControl_BidAccepted(object sender, EventArgs e)
    {

        //NEED TO GET USER ID AND AUCTION ID
        string bidValue = makeBidControl.BidTextValue;

        var db = Database.Instance;
        db.CreateBid(1, 1, Convert.ToDecimal(bidValue));
        makeBidControl.BidTextValue = "";
    }

    private void MakeBidControl_CancelClicked(object sender, EventArgs e)
    {

        makeBidControl.IsVisible = false;
        makeBidControl.BidTextValue = "";
    }
}