using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorInterface.ViewModels
{
    /// <summary>
    /// BaseViewModel - Classe base para os ViewModels da aplicação. 
    /// Ela implementa a interface INotifyPropertyChanged, que é utilizada 
    /// para notificar a interface do usuário sobre mudanças nas propriedades 
    /// dos ViewModels.
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
