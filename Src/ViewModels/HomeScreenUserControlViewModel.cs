using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    public class HomeScreenUserControlViewModel : ViewModelBase
    {
        public HomeScreenUserControlViewModel()
        {
            this.Auctions = new ObservableCollection<DisplayAuction>();
            this.YourAuctions = new ObservableCollection<DisplayAuction>();
        }

        public void AddDataToAuctions(List<DisplayAuction> list)
        {
            foreach (var item in list)
            {
                this.Auctions.Add(item);
            }
        }

        public void AddDataToYourAuctions(List<DisplayAuction> list)
        {
            foreach (var item in list)
            {
                this.YourAuctions.Add(item);
            }
        }

        public ObservableCollection<DisplayAuction> Auctions { get; set; }
        public ObservableCollection<DisplayAuction> YourAuctions { get; set; }

        public class DisplayAuction
        {
            public DisplayAuction(int id, string vehicleName, decimal standingPrice, DateTime endDate)
            {
                this.Id = id;
                this.VehicleName = vehicleName;
                this.StandingPrice = standingPrice;
                this.EndDate = endDate;
            }

            public int Id { get; set; }
            public string VehicleName { get; set; }
            public decimal StandingPrice { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}
