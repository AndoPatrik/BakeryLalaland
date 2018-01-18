using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using BakeryLalaland.Annotations;
>>>>>>> e4e9b2e7650db5d63c21f99456b14ea9e94ad185

namespace BakeryLalaland.Interfaces
{
    public class NotifyPropertyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
<<<<<<< HEAD

    internal class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
    }
=======
>>>>>>> e4e9b2e7650db5d63c21f99456b14ea9e94ad185
}
