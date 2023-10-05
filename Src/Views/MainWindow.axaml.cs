using Avalonia.Controls;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using AutoAuctionProjekt;
using AutoAuctionProjekt.Models;
using System;
using Avalonia.Interactivity;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = new MainWindowViewModel();
        ContentAreaUserControl.Navigate(new LoginUserControl());
    }
  
}