using H2PD071123_Grp2_AutoAuction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    public class ProfessionalCarUserControlViewModel : ViewModelBase
    {
        private string height;

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        private string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        private string weight;

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
