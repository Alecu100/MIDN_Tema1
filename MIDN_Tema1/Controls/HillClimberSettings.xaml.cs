using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using MIDN_Tema1.Annotations;

namespace MIDN_Tema1.Controls
{
    /// <summary>
    ///     Interaction logic for HillClimberSettings.xaml
    /// </summary>
    public partial class HillClimberSettings : UserControl, INotifyPropertyChanged
    {
        private int _numberOfAtempts;

        public HillClimberSettings()
        {
            InitializeComponent();
            NumberOfAtempts = 30;
        }

        public int NumberOfAtempts
        {
            get { return _numberOfAtempts; }
            set
            {
                _numberOfAtempts = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}