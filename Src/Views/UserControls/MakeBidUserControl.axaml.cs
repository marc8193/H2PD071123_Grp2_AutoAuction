using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class MakeBidUserControl : UserControl
{
    public MakeBidUserControl()
    {
        InitializeComponent();
        bidAccept.Click += BidAccept_Click;
        cancelButton.Click += CancelButton_Click;
    }

    public string BidTextValue
    {
        get { return bidText.Text; }
        set { bidText.Text = value; }
    }

    private void BidAccept_Click(object sender, RoutedEventArgs e)
    {
        BidAccepted?.Invoke(this, EventArgs.Empty);
    }
    public event EventHandler BidAccepted;

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        CancelClicked?.Invoke(this, EventArgs.Empty);
    }
    public event EventHandler CancelClicked;

    private void Plus_Click(object sender, RoutedEventArgs e)
    {
        UpdateBidText(1);
    }

    private void Minus_Click(object sender, RoutedEventArgs e)
    {
        UpdateBidText(-1);
    }

    private void Empty_Click(object sender, RoutedEventArgs e)
    {
        bidText.Text = "";
    }

    private void UpdateBidText(int valueToAdd)
    {
        if (int.TryParse(bidText.Text, out int currentBid))
        {
            currentBid += valueToAdd;
            bidText.Text = currentBid.ToString();
        }
        else
        {
            bidText.Text = valueToAdd.ToString();
        }
    }

}