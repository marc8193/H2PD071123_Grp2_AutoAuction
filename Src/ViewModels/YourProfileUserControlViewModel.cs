using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    public class YourProfileUserControlViewModel : ViewModelBase
    {
        public YourProfileUserControlViewModel(string username, decimal balance)
        {
            this.Username = username;
            this.Balance = balance;
        }

        public string Username { get; set; }
        public decimal Balance { get; set; }
        
    }
}
