using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
    public class RelayCommandViewModel : ICommand
    {
        private Action<object> action;

        public event EventHandler? CanExecuteChanged;

        public RelayCommandViewModel(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }
    }
}
