using System;
using System.Windows.Input;

namespace CinemaBooking.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, System.Threading.Tasks.Task> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Func<object, System.Threading.Tasks.Task> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await _execute(parameter);
        }
    }
}