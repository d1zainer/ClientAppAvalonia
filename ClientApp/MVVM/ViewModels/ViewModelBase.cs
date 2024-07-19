using ReactiveUI;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientApp.MVVM.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {

        public static Action<string> ChangeString = delegate { };
    }
}
