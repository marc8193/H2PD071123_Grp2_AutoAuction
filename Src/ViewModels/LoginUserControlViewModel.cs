using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;

namespace H2PD071123_Grp2_AutoAuction.ViewModels
{
    public class LoginUserControlViewModel : ViewModelBase
    {
        public LoginUserControlViewModel() {}

        string? _username; 
        public string Username 
        { 
            get { return _username!; } 
            set { this.RaiseAndSetIfChanged(ref _username, value); }
        }

        string? _password;
        public string Password 
        { 
            get { return _password!; } 
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }
    }
}
