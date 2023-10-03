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

        User user = new PrivateUser("Testttt", "group2", 9000, 1234567890);
        
        var db = Database.Instance;
        user.DbId = db.InsertUser(user);

        var privatePersonalCar = new PrivatePersonalCar("Skoda Octavia", 1200, "56", DateTime.Now.Year, 87666, true, 2.0, 21, Vehicle.FuelType.Diesel, 5, 1.8, 2, 2.5, false);
        AuctionHouse.SetForSale(privatePersonalCar, user.DbId, 1000);        
    }
}