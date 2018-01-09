#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Übung.Annotations;
using Übung.Command;
using Übung.Types;

#endregion


namespace Übung.ViewModel
{
    public class PersoViewModel : INotifyPropertyChanged
    {
        private string _alter;
        private string _name;
        private string _vorname;

        /// <inheritdoc />
        public PersoViewModel ()
        {
            BestCommand = new BestCommand (this);
            PersonenList = new List<Person> ();
        }

        public List<Person> PersonenList { get; set; }

        public string Vorname
        {
            get => _vorname;
            set
            {
                if (value == _vorname)
                    return;
                _vorname = value;
                OnPropertyChanged ();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged ();
            }
        }

        public string Alter
        {
            get => _alter;
            set
            {
                if (value == _alter)
                    return;
                _alter = value;
                OnPropertyChanged ();
            }
        }

        public BestCommand BestCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}