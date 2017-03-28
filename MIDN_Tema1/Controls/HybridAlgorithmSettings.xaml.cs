using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using MIDN_Tema1.Annotations;

namespace MIDN_Tema1.Controls
{
    /// <summary>
    ///     Interaction logic for GeneticAlgorithmSettings.xaml
    /// </summary>
    public partial class HybridAlgorithmSettings : UserControl, INotifyPropertyChanged
    {
        private double _crossoverChance;
        private int _crossoverCuts;
        private double _improvementChance;
        private double _mutationChance;
        private int _populationSize;

        public HybridAlgorithmSettings()
        {
            InitializeComponent();

            MutationChance = 0.33d;
            CrossoverChance = 0.33d;
            CrossoverCuts = 3;
            PopulationSize = 30;
            ImprovementChance = 0.33d;
        }


        public int PopulationSize
        {
            get { return _populationSize; }
            set
            {
                _populationSize = value;
                OnPropertyChanged();
            }
        }

        public double CrossoverChance
        {
            get { return _crossoverChance; }
            set
            {
                _crossoverChance = value;
                OnPropertyChanged();
            }
        }

        public int CrossoverCuts
        {
            get { return _crossoverCuts; }
            set
            {
                _crossoverCuts = value;
                OnPropertyChanged();
            }
        }

        public double ImprovementChance
        {
            get { return _improvementChance; }
            set
            {
                _improvementChance = value;
                OnPropertyChanged();
            }
        }

        public double MutationChance
        {
            get { return _mutationChance; }

            set
            {
                _mutationChance = value;
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