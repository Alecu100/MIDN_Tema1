﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using MIDN_Tema1.Annotations;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Runners;

namespace MIDN_Tema1
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _numberOfAtempts;
        private int _numberOfInputs;
        private int _numberOfIntervals;
        private int _numberOfRuns;
        private IFunction _selectedFunction;
        private IRunner _selectedRunner;

        public MainWindow()
        {
            InitializeComponent();

            Functions.Add(new GriewangkFunction());
            Functions.Add(new RastriginFunction());
            Functions.Add(new RosenbrockFunction());
            Functions.Add(new SixHumpCamelBack());
            Functions.Add(new HomeworkFunction());

            NumberOfIntervals = (int) Math.Pow(10, 2);
            NumberOfInputs = 5;
            NumberOfRuns = 1;

            Runners.Add(new HillClimbingRunner());
            Runners.Add(new GeneticAlgorithmRunner());
            Runners.Add(new HybridAlgorithmRunner());
            Runners.Add(new ParticleSwarmRunner());

            cmbFunction.SelectedItem = Functions[0];
            cmbRunner.SelectedItem = Runners[Runners.Count - 1];
        }

        public ObservableCollection<IFunction> Functions { get; } = new ObservableCollection<IFunction>();

        public ObservableCollection<RunnerResult> RunnerResults { get; } = new ObservableCollection<RunnerResult>();

        public ObservableCollection<IRunner> Runners { get; } = new ObservableCollection<IRunner>();

        public int NumberOfRuns
        {
            get { return _numberOfRuns; }
            set
            {
                _numberOfRuns = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfIntervals
        {
            get { return _numberOfIntervals; }
            set
            {
                _numberOfIntervals = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfInputs
        {
            get { return _numberOfInputs; }
            set
            {
                _numberOfInputs = value;
                OnPropertyChanged();
            }
        }

        public IFunction SelectedFunction
        {
            get { return _selectedFunction; }
            set
            {
                _selectedFunction = value;
                OnPropertyChanged();
            }
        }

        public IRunner SelectedRunner
        {
            get { return _selectedRunner; }
            set
            {
                _selectedRunner = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFunction.SelectionBoxItem == null || cmbRunner.SelectionBoxItem == null)
            {
                MessageBox.Show("Please select a Runner and a Function!");
                return;
            }


            var selectedRunner = (IRunner) cmbRunner.SelectionBoxItem;
            selectedRunner.Run((IFunction) cmbFunction.SelectionBoxItem, NumberOfInputs, NumberOfRuns,
                NumberOfIntervals);

            foreach (var runnerResult in selectedRunner.Results)
            {
                RunnerResults.Add(runnerResult);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            RunnerResults.Clear();
        }

        private void CmbRunner_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var runner = (IRunner) e.AddedItems[0];
                scrlViewerRunnerSettings.Content = runner.RunnerSettings;
                colOptionalField.Header = runner.OptionalFieldName;
            }
        }
    }
}