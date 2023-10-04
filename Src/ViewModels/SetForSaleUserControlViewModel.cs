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
using System.Diagnostics;

namespace H2PD071123_Grp2_AutoAuction.Src.ViewModels
{
    public class SetForSaleUserControlViewModel : ViewModelBase
    {
        private string fuelType;

        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string milage;
        public string Milage
        {
            get { return milage; }
            set { milage = value; }
        }

        private string regNum;
        public string RegNum
        {
            get { return regNum; }
            set { regNum = value; }
        }

        private string engineSize;

        public string EngineSize
        {
            get { return engineSize; }
            set { engineSize = value; }
        }


        private string startingBid;
        public string StartingBid
        {
            get { return startingBid; }
            set { startingBid = value; }
        }

        private string closeAuction;
        public string CloseAuction
        {
            get { return closeAuction; }
            set { closeAuction = value; }
        }

        private string vehicleType;
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        private List<int> yearList = new List<int>();
        public List<int> YearList
        {
            get { return yearList; } set { yearList = value; }
        }

        void YearsCB()
        {
            for (int year = 1886; year <= 2024; year++)
            {
                YearList.Add(year);
            }

        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }

        }

        private bool towBar;

        public bool TowBar
        {
            get { return towBar; }
            set { towBar = value; }
        }

        public SetForSaleUserControlViewModel()
        {
            YearsCB();
        }


        public ObservableCollection<string> TruckTypes { get; } = new ObservableCollection<string> {"Truck Type", "Bus", "Truck", "PrivateCar" ,"ProfessionalCar" };
        public ObservableCollection<string> FuelTypeCB { get; } = new ObservableCollection<string> { "Diesel","Petrol","Electric","Hydrogen" };

        private ViewModelBase? selectedTruckUserControl;

        public ViewModelBase SelectedTruckUserControl
        {
            get { return selectedTruckUserControl; }
            set
            {
                selectedTruckUserControl = value;
                OnPropertyChanged(nameof(SelectedTruckUserControl));
            }
        }
        private int _selectedCarIndex = 0;

        public int SelectedCarIndex
        {
            get => _selectedCarIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCarIndex, value);
                getVehicleType();

            }
        }
        PrivateCarUserControlViewModel _privateCarUCVM = new PrivateCarUserControlViewModel();
        public PrivateCarUserControlViewModel PrivateCarUCVM
        {
            get => _privateCarUCVM;
            set => this.RaiseAndSetIfChanged(ref _privateCarUCVM, value);
        }
        ProfessionalCarUserControlViewModel _professionalUCVM =new ProfessionalCarUserControlViewModel();
        public ProfessionalCarUserControlViewModel ProfessionalUCVM
        {
            get => _professionalUCVM;
            set => this.RaiseAndSetIfChanged(ref _professionalUCVM, value);
        }
        BusUserControlViewModel _busUCVM = new BusUserControlViewModel();
        public BusUserControlViewModel BusUCVM
        {
            get => _busUCVM;
            set => this.RaiseAndSetIfChanged(ref _busUCVM, value);
        }
        TruckUserControlViewModel _truckUCVM = new TruckUserControlViewModel();
        public TruckUserControlViewModel TruckUCVM
        {
            get => _truckUCVM;
            set => this.RaiseAndSetIfChanged(ref _truckUCVM, value);
        }

        ViewModelBase activeView;

        public ViewModelBase ActivView
        {
            get => activeView;
            set => this.RaiseAndSetIfChanged(ref activeView, value);
        }

        private void getVehicleType()
        {
            switch (SelectedCarIndex)
            {
                case 0:
                    ActivView = null;
                    break;
                case 1:
                    ActivView = new BusUserControlViewModel();
                    break;
                case 2:
                    ActivView = new TruckUserControlViewModel();
                    break;
                case 3:
                    ActivView =new PrivateCarUserControlViewModel();
                    break;
                case 4:
                    ActivView =new ProfessionalCarUserControlViewModel();
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
