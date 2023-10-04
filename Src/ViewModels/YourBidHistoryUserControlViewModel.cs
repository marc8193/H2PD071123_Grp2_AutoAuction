using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    public class YourBidHistoryUserControlViewModel : ViewModelBase
    {
        public YourBidHistoryUserControlViewModel()
        {
            this.Bids = new ObservableCollection<DisplayBids>();
        }

        public void AddDataToYourBids(List<DisplayBids> list)
        {
            foreach (var item in list)
            {
                this.Bids.Add(item);
            }
        }

        public ObservableCollection<DisplayBids> _bids; 
        public ObservableCollection<DisplayBids> Bids { get { return _bids; } set => this.RaiseAndSetIfChanged(ref _bids, value); }
        public class DisplayBids
        {
            public DisplayBids(decimal amount, DateTime date)
            {
                this.Amount = amount;
                this.Date = date;
            }

            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }
    }

}
