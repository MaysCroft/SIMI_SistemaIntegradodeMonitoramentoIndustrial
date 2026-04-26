using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SensorInterface.Commands
{
    /// <summary>
    /// RelayCommand é uma implementação da interface ICommand que permite 
    /// criar comandos de forma simples e flexível. Ele é utilizado para 
    /// vincular ações do usuário (como cliques em botões) a métodos específicos 
    /// no ViewModel. O RelayCommand aceita um Action para a execução do comando 
    /// e um Func<bool> para determinar se o comando pode ser executado. Ele também 
    /// implementa o evento CanExecuteChanged para notificar a interface do usuário 
    /// quando a capacidade de execução do comando muda, permitindo que os controles 
    /// sejam habilitados ou desabilitados de acordo com a lógica definida no Func<bool>. 
    /// Essa classe é amplamente utilizada em aplicações WPF para facilitar a implementação 
    /// de comandos e a separação de responsabilidades entre a interface do usuário e a lógica de negócios.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
