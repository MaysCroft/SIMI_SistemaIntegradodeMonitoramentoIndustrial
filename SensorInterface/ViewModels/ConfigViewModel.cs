using System;
using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using SensorInterface.Commands;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SensorInterface.ViewModels
{
    internal class ConfigViewModel : BaseViewModel
    {
        public ICommand CalibrarCommand { get; }

        public ConfigViewModel()
        {
            CalibrarCommand = new RelayCommand(CalibrarSensores);
        }

        private void CalibrarSensores()
        {
            throw new NotImplementedException();
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string temperaturaMaxima;
        private string pressaoMaxima;

        public string TemperaturaMaxima { get => temperaturaMaxima; set => SetProperty(ref temperaturaMaxima, value); }
        public string PressaoMaxima { get => pressaoMaxima; set => SetProperty(ref pressaoMaxima, value); }
    }
}
