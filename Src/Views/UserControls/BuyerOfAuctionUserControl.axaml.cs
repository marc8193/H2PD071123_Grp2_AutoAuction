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

    public BuyerOfAuctionUserControl(int aucId, int vehId, int userId)
    {
        this.DataContext = new BuyerOfAuctionUserControlViewModel(vehId);
        this.AucId = aucId;
        this.UserId = userId;
        InitializeComponent();
    }

    public int AucId { get; set; }
    public int UserId { get; set; }
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

        //NEED TO GET USER ID AND AUCTION ID
        if (Convert.ToInt32(minBid) <= Convert.ToInt32(makeBidControl.BidTextValue))
        {
            return;
        }

        string bidValue = makeBidControl.BidTextValue;

        var db = Database.Instance;
        db.CreateBid(this.UserId, Convert.ToInt32(AucId), Convert.ToDecimal(bidValue));
        makeBidControl.IsVisible = false;
        makeBidControl.BidTextValue = "";
    }

    private void MakeBidControl_CancelClicked(object sender, EventArgs e)
    {

        makeBidControl.IsVisible = false;
        makeBidControl.BidTextValue = "";
    }
}