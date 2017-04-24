using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using MIDN_Tema1.Annotations;

namespace MIDN_Tema1.Controls
{
    /// <summary>
    ///     Interaction logic for ParticleSwarmSettings.xaml
    /// </summary>
    public partial class ParticleSwarmSettings : UserControl, INotifyPropertyChanged
    {
        private int _swarmSize;
        private double _w1Factor;
        private double _w2Factor;
        private double _w3Factor;

        public ParticleSwarmSettings()
        {
            InitializeComponent();
        }

        public int SwarmSize
        {
            get { return _swarmSize; }
            set
            {
                _swarmSize = value;
                OnPropertyChanged();
            }
        }

        public double W1Factor
        {
            get { return _w1Factor; }
            set
            {
                _w1Factor = value;
                OnPropertyChanged();
            }
        }

        public double W2Factor
        {
            get { return _w2Factor; }
            set
            {
                _w2Factor = value;
                OnPropertyChanged();
            }
        }

        public double W3Factor
        {
            get { return _w3Factor; }
            set
            {
                _w3Factor = value;
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