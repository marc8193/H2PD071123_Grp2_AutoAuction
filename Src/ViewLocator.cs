using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using H2PD071123_Grp2_AutoAuction.ViewModels;

namespace H2PD071123_Grp2_AutoAuction;

public class ViewLocator : IDataTemplate
{
    public Control Build(object data)
    {
        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }
        
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }
}