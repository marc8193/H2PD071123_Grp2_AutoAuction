using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class ProfessionalCarUserControlView : UserControl
{
    public ProfessionalCarUserControlView()
    {
        InitializeComponent();
        DataContext = new ProfessionalCarUserControlViewModel();
    }
}