using H2PD071123_Grp2_AutoAuction.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2PD071123_Grp2_AutoAuction.Views;

namespace H2PD071123_Grp2_AutoAuction.Src.ViewModels
{
    public class SetForSaleUserControlViewModel : ViewModelBase
    {
		private int _selectedCarIndex = 0;

		public int SelectedCarIndex
		{
			get => _selectedCarIndex;
			set
			{
				this.RaiseAndSetIfChanged(ref _selectedCarIndex, value);
				
			}
		}
		


	}
}
