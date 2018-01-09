using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Übung.Annotations;
using Übung.Command;
using Übung.Types;


namespace Übung.ViewModel
{
    public class PersoViewModel : INotifyPropertyChanged
    {
        private string _vorname;
        private string _name;
        private string _alter;

        /// <inheritdoc />
        public PersoViewModel ()
        {
            Init();
        }

        private void Init ()
        {
            BestCommand = new BestCommand(this);
            PersonenList = new List<Person> ();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Person> PersonenList { get; set; }

        public string Vorname
        {
            get { return _vorname; }
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
            get { return _name; }
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
            get { return _alter; }
            set
            {
                if (value == _alter)
                    return;
                _alter = value;
                OnPropertyChanged ();
            }
        }

        public BestCommand BestCommand { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}