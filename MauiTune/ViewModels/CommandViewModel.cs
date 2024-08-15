


using System;
using System.Windows.Input;

namespace Statsfy.ViewModel 
{ 

    public class CommandViewModel : ICommand
    {
        //Fields
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public CommandViewModel(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //Events
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExecute==null?true:_canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

}
