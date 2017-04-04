using System.Collections.ObjectModel;
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
            FitMethods.Add(new FitMethod {Name = "Best Fit"});
            FitMethods.Add(new FitMethod {Name = "First Fit"});
        }

        public FitMethod SelectedFitMethod { get; set; }

        public ObservableCollection<FitMethod> FitMethods { get; } = new ObservableCollection<FitMethod>();

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

        private void CmbFitMethod_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is FitMethod)
            {
                SelectedFitMethod = (FitMethod) e.AddedItems[0];
            }
        }

        public class FitMethod
        {
            public string Name { get; set; }
        }
    }
}