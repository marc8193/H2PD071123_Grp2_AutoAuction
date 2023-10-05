using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Reflection.Emit;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class YourProfileUserControl : UserControl
{
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public int UserId { get; set; }

    public YourProfileUserControl()
    {
        InitializeComponent();
    }
    public YourProfileUserControl(HomeScreenUserControl homeScreenUC, int userId)
    {
        InitializeComponent();
        this.HomeScreenUC = homeScreenUC;
        this.UserId = userId;
    }
    void BackBtn(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(this.HomeScreenUC!);
    }
}