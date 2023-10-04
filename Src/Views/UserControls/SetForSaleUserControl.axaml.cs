using AutoAuctionProjekt.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Diagnostics;
using static AutoAuctionProjekt.Models.Vehicle;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class SetForSaleUserControl : UserControl
{
    public SellerOfAuctionUserControl? SellerOfAuctionUC { get; set; }
    public HomeScreenUserControl? HomeScreenUC { get; set; }
    public SetForSaleUserControl()
    {
        InitializeComponent();

        DataContext = new SetForSaleUserControlViewModel();

    }
    public SetForSaleUserControl(HomeScreenUserControl homeScreenUC, SellerOfAuctionUserControl sellerOfAuctionUC)
    {
        InitializeComponent();
        this.HomeScreenUC = homeScreenUC;
        this.SellerOfAuctionUC = sellerOfAuctionUC;
    }



    void CancelBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new HomeScreenUserControl());
    }

    void CreateAuctionBTN(object sender, RoutedEventArgs e)
    {
        var VehicleType = this.Find<ComboBox>("VehicleType");
        var selectedV = VehicleType?.SelectedIndex;

        var nameBox = this.Find<TextBox>("nameBox")?.Text;
        var kmBox = this.Find<TextBox>("kmBox")?.Text;
        var regBox = this.Find<TextBox>("regBox")?.Text;
        var minBidBox = this.Find<TextBox>("minBidBox")?.Text;

        var db = Database.Instance;

        // Bus, Truck, Private Car, Business Car
        if (selectedV == 0)
        {

        }
        else if (selectedV == 1)
        {

        }
        else if (selectedV == 2)
        {
            var privateCar = new PrivatePersonalCar(
                nameBox,
                Convert.ToDouble(kmBox),
                regBox,
                Convert.ToInt32(2011),
                Convert.ToDecimal(minBidBox),
                Convert.ToBoolean(0),
                Convert.ToDouble(1.2),
                Convert.ToDouble(1.2),
                FuelType.Diesel,
                Convert.ToUInt32(5),
                Convert.ToDouble(1.2),
                Convert.ToDouble(1.2),
                Convert.ToDouble(1.2),
                Convert.ToBoolean(0)

            );
            int vhId = db.InsertPrivatePersonalCar(privateCar);
            db.SetForSale(vhId, 1, Convert.ToDecimal(minBidBox));
        }
        else if (selectedV == 3)
        {

        }

        ContentAreaUserControl.Navigate(new HomeScreenUserControl());

        // ContentAreaUserControl.Navigate(this.SellerOfAuctionUC!);

    }
}