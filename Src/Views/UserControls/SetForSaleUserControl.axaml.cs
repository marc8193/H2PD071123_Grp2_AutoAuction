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


    private void VehicleTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem item = VehicleType.SelectedItem as ComboBoxItem;
        string value = item.Content.ToString();

        // set all to falls
        //HeavyVehicle
        heavyHeightText.IsVisible = false;
        heavyHeightTextBox.IsVisible = false;
        heavyWidthText.IsVisible = false;
        heavyWidthTextBox.IsVisible = false;
        heavyLengthText.IsVisible = false;
        heavyLengthTextBox.IsVisible = false;

        // Bus
        seatsText.IsVisible = false;
        seatsTextBox.IsVisible = false;
        sleepText.IsVisible = false;
        sleepTextBox.IsVisible = false;
        toiletText.IsVisible = false;
        toiletTextBox.IsVisible = false;

        // Truck
        loadCapacityText.IsVisible = false;
        loadCapacityTextBox.IsVisible = false;

        //light vehicle
        lightSeatsText.IsVisible = false;
        lightSeatsTextBox.IsVisible = false;
        lightHeightText.IsVisible = false;
        lightHeightTextBox.IsVisible = false;
        lightWidthText.IsVisible = false;
        lightWidthTextBox.IsVisible = false;
        lightLengthText.IsVisible = false;
        lightLengthTextBox.IsVisible = false;

        //PersonalCar
        isoFixText.IsVisible = false;
        isoFixTextBox.IsVisible = false;

        //BusinessCar
        safetyBarText.IsVisible = false;
        safetyBarTextBox.IsVisible = false;
        perCapacityText.IsVisible = false;
        perCapacityTextBox.IsVisible = false;

        if (value == "Bus")
        {
            //HeavyVehicle
            heavyHeightText.IsVisible = true;
            heavyHeightTextBox.IsVisible = true;
            heavyWidthText.IsVisible = true;
            heavyWidthTextBox.IsVisible = true;
            heavyLengthText.IsVisible = true;
            heavyLengthTextBox.IsVisible = true;

            // Bus
            seatsText.IsVisible = true;
            seatsTextBox.IsVisible = true;
            sleepText.IsVisible = true;
            sleepTextBox.IsVisible = true;
            toiletText.IsVisible = true;
            toiletTextBox.IsVisible = true;
        }
        else if (value == "Truck")
        {
            //HeavyVehicle
            heavyHeightText.IsVisible = true;
            heavyHeightTextBox.IsVisible = true;
            heavyWidthText.IsVisible = true;
            heavyWidthTextBox.IsVisible = true;
            heavyLengthText.IsVisible = true;
            heavyLengthTextBox.IsVisible = true;

            // Truck
            loadCapacityText.IsVisible = true;
            loadCapacityTextBox.IsVisible = true;
        }
        else if (value == "Private Car")
        {
            // light vehicle
            lightSeatsText.IsVisible = true;
            lightSeatsTextBox.IsVisible = true;
            lightHeightText.IsVisible = true;
            lightHeightTextBox.IsVisible = true;
            lightWidthText.IsVisible = true;
            lightWidthTextBox.IsVisible = true;
            lightLengthText.IsVisible = true;
            lightLengthTextBox.IsVisible = true;

            //PersonalCar
            isoFixText.IsVisible = true;
            isoFixTextBox.IsVisible = true;
        }
        else if (value == "Business Car")
        {
            // light vehicle
            lightSeatsText.IsVisible = true;
            lightSeatsTextBox.IsVisible = true;
            lightHeightText.IsVisible = true;
            lightHeightTextBox.IsVisible = true;
            lightWidthText.IsVisible = true;
            lightWidthTextBox.IsVisible = true;
            lightLengthText.IsVisible = true;
            lightLengthTextBox.IsVisible = true;

            //BusinessCar
            safetyBarText.IsVisible = true;
            safetyBarTextBox.IsVisible = true;
            perCapacityText.IsVisible = true;
            perCapacityTextBox.IsVisible = true;
        }
    }

    void CancelBTN(object sender, RoutedEventArgs e)
    {
        ContentAreaUserControl.Navigate(new HomeScreenUserControl());
    }

    void CreateAuctionBTN(object sender, RoutedEventArgs e)
    {
        var VehicleType = this.Find<ComboBox>("VehicleType");
        var selectedV = VehicleType?.SelectedIndex;

        ComboBoxItem item = Year.SelectedItem as ComboBoxItem;
        string year = item.Content.ToString();

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
                Convert.ToInt32(year),
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