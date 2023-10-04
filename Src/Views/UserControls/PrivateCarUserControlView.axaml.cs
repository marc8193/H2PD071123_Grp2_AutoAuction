using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class PrivateCarUserControlView : UserControl
{
    public PrivateCarUserControlView()
    {
        InitializeComponent();
        DataContext = new PrivateCarUserControlViewModel();
    }
}