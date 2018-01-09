using System;
using System.Diagnostics;
using System.Windows.Input;

using Übung.Types;
using Übung.ViewModel;


namespace Übung.Command
{
    public class BestCommand : ICommand
    {
        private PersoViewModel ViewModel;

        public BestCommand (PersoViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        /// <inheritdoc />
        public bool CanExecute (object parameter)
        {
            Debug.WriteLine ("Checked for execution");
            return !string.IsNullOrEmpty (ViewModel.Vorname) &&
                   !string.IsNullOrEmpty (ViewModel.Name) &&
                   !string.IsNullOrEmpty (ViewModel.Alter);
        }

        /// <inheritdoc />
        public void Execute (object parameter)
        {
            if (int.TryParse (ViewModel.Alter, out var alter))
                ViewModel.PersonenList.Add (new Person (ViewModel.Vorname, ViewModel.Name, alter));
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}