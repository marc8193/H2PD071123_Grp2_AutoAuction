using Avalonia.Controls;
using AutoAuctionProjekt;
using AutoAuctionProjekt.Models;
using System;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var truck = new Truck("Volvo FH12", 1200, "12345", DateTime.Now.Year, 100, false, 6, 2, Vehicle.FuelType.Diesel, 2, 10, 10, 10, 20);

        AuctionHouse.SetForSale(truck);
    }
}