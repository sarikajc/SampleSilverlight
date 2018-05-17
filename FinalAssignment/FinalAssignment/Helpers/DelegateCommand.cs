using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FinalAssignment.Helpers
{
    public class DelegateCommand<T> : ICommand  
    {
        Predicate<T> canExecute;
        Action<T> execute;
        public DelegateCommand(Predicate<T> _canexecute, Action<T> _execute) : this()
        {
            canExecute = _canexecute;
            execute = _execute;
        }
        public DelegateCommand()
        { }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute( (T)parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}
