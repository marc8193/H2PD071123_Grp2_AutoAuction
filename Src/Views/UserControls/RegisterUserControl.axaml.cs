using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Drawing.Text;

namespace H2PD071123_Grp2_AutoAuction.Src.Views.UserControls;

public partial class RegisterUserControl : UserControl
    
{ 
    static RegisterUserControl? Instance;

    public RegisterUserControl()
    {
        InitializeComponent();

        if(Instance  == null)
        {
            Instance = this;

        }
    }
    public RegisterUserControl GetInstanse()
    {
        return Instance == null ? new() : Instance;
    }
}