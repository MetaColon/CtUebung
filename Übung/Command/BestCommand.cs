#region

using System;
using System.Diagnostics;
using System.Windows.Input;

using Übung.Types;
using Übung.ViewModel;

#endregion


namespace Übung.Command
{
    public class BestCommand : ICommand
    {
        private readonly PersoViewModel _viewModel;

        public BestCommand (PersoViewModel viewModel) => _viewModel = viewModel;

        /// <inheritdoc />
        public bool CanExecute (object parameter)
        {
            Debug.WriteLine ("Checked for execution");
            return !string.IsNullOrEmpty (_viewModel.Vorname) &&
                   !string.IsNullOrEmpty (_viewModel.Name) &&
                   !string.IsNullOrEmpty (_viewModel.Alter);
        }

        /// <inheritdoc />
        public void Execute (object parameter)
        {
            if (int.TryParse (_viewModel.Alter, out var alter))
                _viewModel.PersonenList.Add (new Person (_viewModel.Vorname, _viewModel.Name, alter));
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}