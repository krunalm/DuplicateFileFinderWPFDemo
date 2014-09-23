using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DuplicateFileFinder
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

    //public class DelegateCommand : ICommand
    //{
    //    private readonly Action executeMethod;
    //    //private readonly Action<object> executeMethodWithPara;
    //    private readonly Func<bool> canExecuteMethod;

    //    public DelegateCommand(Action executeMethod)
    //        : this(executeMethod, () => true)
    //    {
    //    }

    //    //public DelegateCommand(Action<object> executeMethod)
    //    //    : this(executeMethod, () => true)
    //    //{
    //    //}

    //    public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
    //    {
    //        if (executeMethod == null)
    //            throw new ArgumentNullException("executeMethod");
    //        if (canExecuteMethod == null)
    //            throw new ArgumentNullException("canExecuteMethod");

    //        this.executeMethod = executeMethod;
    //        this.canExecuteMethod = canExecuteMethod;
    //    }

    //    //public DelegateCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
    //    //{
    //    //    if (executeMethod == null)
    //    //        throw new ArgumentNullException("executeMethod");
    //    //    if (canExecuteMethod == null)
    //    //        throw new ArgumentNullException("canExecuteMethod");

    //    //    this.executeMethodWithPara = executeMethod;
    //    //    this.canExecuteMethod = canExecuteMethod;
    //    //}

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public bool CanExecute(object stupid)
    //    {
    //        return CanExecute();
    //    }

    //    public bool CanExecute()
    //    {
    //        return canExecuteMethod();
    //    }

    //    public void Execute(object parameter)
    //    {
    //        //if (parameter == null)
    //        //    return;

    //        Execute();
    //        //executeMethodWithPara(parameter);
    //    }

    //    public void Execute()
    //    {
    //        executeMethod();
    //    }

    //    public void OnCanExecuteChanged()
    //    {
    //        CommandManager.InvalidateRequerySuggested();
    //    }
    //}
}
