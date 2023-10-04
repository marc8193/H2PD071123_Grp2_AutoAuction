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
}