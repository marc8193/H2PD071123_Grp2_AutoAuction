using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Security.Cryptography.X509Certificates;

namespace H2PD071123_Grp2_AutoAuction.Views;

public partial class ContentAreaUserControl : UserControl
{
    //static 
    static ContentAreaUserControl? Instance;
    public ContentAreaUserControl()
    {
        InitializeComponent();
    
        if (Instance == null) {Instance = this;}
    }
    public static void Navigate( UserControl userControl)
    {
        if(Instance == null) { return; }
        Instance.Content = userControl;

    }
}