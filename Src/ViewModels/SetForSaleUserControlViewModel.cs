using H2PD071123_Grp2_AutoAuction.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2PD071123_Grp2_AutoAuction.Views;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using System.ComponentModel;

namespace H2PD071123_Grp2_AutoAuction.Src.ViewModels
{
    public class SetForSaleUserControlViewModel : ViewModelBase  
    {
        public ObservableCollection<string> TruckTypes { get; } = new ObservableCollection<string> { "PrivateCar", "ProfessionalCar", "Bus", "Truck" };
        private string selectedTruckType;

        public string SelectedTruckType
        {
            get { return selectedTruckType; }
            set
            {
                selectedTruckType = value;
                OnPropertyChanged(nameof(SelectedTruckType));
                SelectedTruckUserControl = CreateTruckUserControl(value);
            }
        }
        private UserControl selectedTruckUserControl;

        public UserControl SelectedTruckUserControl
        {
            get { return selectedTruckUserControl; }
            set
            {
                selectedTruckUserControl = value;
                OnPropertyChanged(nameof(SelectedTruckUserControl));
            }
        }
        private UserControl CreateTruckUserControl(string truckType)
        {
            switch (truckType)
            {
                case "PrivateCar":
                    return new PrivateCarUserControl();
                case "ProfessionalCar":
                    return new ProfessionallCarUserControl();
                case "Bus":
                    return new BusUserControl();
                case "Truck":
                    return new TruckUserControl();
                default:
                    return null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private int _selectedCarIndex = 0;

        //public int SelectedCarIndex
        //{
        //	get => _selectedCarIndex;
        //	set
        //	{
        //		this.RaiseAndSetIfChanged(ref _selectedCarIndex, value);

        //	}
        //}

        //ViewModelBase activeView;

        //public ViewModelBase ActivView 
        //{
        //	get => activeView; 
        //	set => this.RaiseAndSetIfChanged(ref activeView, value); 
        //}

        //private void getVehicleType()
        //{
        //	switch (SelectedCarIndex)
        //	{
        //              case 0:
        //                  ActivView = new TruckUserControlViewModel();
        //                  break;
        //              case 1:
        //                  ActivView = new BusUserControlViewModel();
        //                  break;
        //              case 2:
        //                  ActivView = new PrivateCarUserControlViewModel();
        //                  break;
        //              case 3:
        //                  ActivView = new ProfessionalUserControlViewModel();
        //                  break;

        //          }

        //}
    }
}
