﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epicture
{
    class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> execute;

        public AddCommand(Action<object> action)
        {
            this.execute = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
