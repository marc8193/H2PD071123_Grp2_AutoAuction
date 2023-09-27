using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class HomeScreenUserControl : UserControl
{
    SetForSaleUserControl SetforSaleUC;
    static HomeScreenUserControl? Instance;
    public HomeScreenUserControl()
    {
        this.SetforSaleUC = new SetForSaleUserControl(this); // constractor property
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
}