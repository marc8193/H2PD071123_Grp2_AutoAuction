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
        ContentAreaUserControl.Navigate(new HomeScreenUserControl(this.UserId));
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

        Console.WriteLine("dasdasd");

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