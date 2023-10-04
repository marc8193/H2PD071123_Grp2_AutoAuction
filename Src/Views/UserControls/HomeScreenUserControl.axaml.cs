using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.Src.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class HomeScreenUserControl : UserControl
{
    SellerOfAuctionUserControl SellerOfAuctionUC = new SellerOfAuctionUserControl(); 
    YourBidHistoryUserControl YourBidHistoryUC;
    YourProfileUserControl YourProfileUC;
    SetForSaleUserControlView SetforSaleUC;
    static HomeScreenUserControl? Instance;
    public HomeScreenUserControl()
    {
        this.SellerOfAuctionUC=new SellerOfAuctionUserControl(this);
        this.YourBidHistoryUC=new YourBidHistoryUserControl(this);
        this.YourProfileUC= new YourProfileUserControl(this);
        this.SetforSaleUC = new SetForSaleUserControlView(this,SellerOfAuctionUC) ; // constractor property
        SetforSaleUC.DataContext = new SetForSaleUserControlViewModel();
        InitializeComponent();
        if (Instance == null) { Instance = this; }
    }
    public HomeScreenUserControl GetInstanse()
    {
        return Instance == null ? new() : Instance;
    }
    void SetForSaleBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.SetforSaleUC);

    }
    void UserProfileBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.YourProfileUC);
    }
    void BidHistoryBtn (object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.YourBidHistoryUC);
    }
}   