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
            public DisplayAuction(int aucID, int vhId, string vehicleName, decimal standingPrice, DateTime endDate)
            {
                this.AucID = aucID;
                this.VhId = vhId;
                this.VehicleName = vehicleName;
                this.StandingPrice = standingPrice;
                this.EndDate = endDate;
            }

            public int AucID { get; set; }
            public int VhId { get; set; }
            public string VehicleName { get; set; }
            public decimal StandingPrice { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}
