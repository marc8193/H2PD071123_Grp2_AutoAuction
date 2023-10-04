using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static H2PD071123_Grp2_AutoAuction.Database;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    internal class SellerOfAuctionUserControlViewModel : ViewModelBase
    {

        public SellerOfAuctionUserControlViewModel()
        {
        }

        public SellerOfAuctionUserControlViewModel(int id)
        {
            this.Id = id;
            var db = Database.Instance;
            this.Seller = db.SelecThisAuction(id);
        }

        public List<SelectedAuction> Sellers { get; set; }

        public int Id { get; set; }

        public SelectedAuction Seller { get; set; }

    }
}
