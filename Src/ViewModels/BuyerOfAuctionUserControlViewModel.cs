using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static H2PD071123_Grp2_AutoAuction.Database;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    internal class BuyerOfAuctionUserControlViewModel : ViewModelBase
    {
        public BuyerOfAuctionUserControlViewModel()
        {
        }

        public BuyerOfAuctionUserControlViewModel(int id)
        {
            var db = Database.Instance;
            this.Seller = db.SelecThisAuction(id);
        }

        public SelectedAuction Seller { get; set; }
    }
}
