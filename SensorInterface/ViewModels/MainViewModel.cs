using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using System.Threading.Tasks;
using SensorInterface.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shared;

namespace SensorInterface.ViewModels
{
    /// <summary>
    /// MainViewModel - ViewModel principal da aplicação. Ele é responsável por 
    /// gerenciar os dados dos sensores e as ações do usuário, como carregar os 
    /// dados dos sensores a partir da API. Ele contém propriedades para armazenar 
    /// as listas de temperaturas e pressões, e um comando para carregar os dados 
    /// dos sensores a partir da API. O método CarregarSensores faz uma requisição 
    /// HTTP GET para a API, obtém os dados dos sensores e atualiza as listas de 
    /// temperaturas e pressões, que são vinculadas à interface do usuário para exibição.
    /// </summary>
    internal class MainViewModel : BaseViewModel
    {
        public ObservableCollection<DateTime> Horario { get; set; }
        public ObservableCollection<double> Temperaturas { get; set; }
        public ObservableCollection<double> Pressoes { get; set; }

        public ICommand CarregarSensoresCommand { get; }
        public ICommand CalibrarCommand { get; }

        public MainViewModel()
        {
            Horario = new ObservableCollection<DateTime>();
            Temperaturas = new ObservableCollection<double>();
            Pressoes = new ObservableCollection<double>();

            // Comandos:
            CarregarSensoresCommand = new RelayCommand(CarregarSensores);
            CalibrarCommand = new RelayCommand(CalibrarSensores);
        }

        private async void CarregarSensores()
        {
            var http = new HttpClient();

            var dados = await http.GetFromJsonAsync<List<SensorData>>(
                "https://localhost:7257/api/v1/sensores");

            Horario.Clear();
            Temperaturas.Clear();
            Pressoes.Clear();

            foreach (var sensor in dados)
            {
                Horario.Add(sensor.Timestamp);
                Temperaturas.Add(sensor.Temperatura);
                Pressoes.Add(sensor.Pressao);
            }
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
