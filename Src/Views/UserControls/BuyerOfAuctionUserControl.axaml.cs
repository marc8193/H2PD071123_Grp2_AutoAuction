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

    public BuyerOfAuctionUserControl(int aucId, int vehId)
    {
        this.DataContext = new BuyerOfAuctionUserControlViewModel(vehId);
        this.AucId = aucId;
        InitializeComponent();
    }

    public int AucId { get; set; }
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

        var minBid = this.Find<LabelUserControl>("bidsText")?.Content;

        int minimumbid = Convert.ToInt32(minBid);
        int bid = Convert.ToInt32(makeBidControl.BidTextValue);
        //NEED TO GET USER ID AND AUCTION ID
        if (minimumbid >= bid)
        {
            makeBidControl.BidTextValue = "To Low";
            return;
        }

        string bidValue = makeBidControl.BidTextValue;

        var db = Database.Instance;
        db.CreateBid(1, Convert.ToInt32(AucId), Convert.ToDecimal(bidValue));
        makeBidControl.IsVisible = false;
        makeBidControl.BidTextValue = "";
    }

    private void MakeBidControl_CancelClicked(object sender, EventArgs e)
    {

        makeBidControl.IsVisible = false;
        makeBidControl.BidTextValue = "";
    }
}