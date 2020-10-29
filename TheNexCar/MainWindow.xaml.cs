using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheNexCar.Controler;

namespace TheNexCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , OnPowerChanged, OnDoorChanged, OnCarEngineStatusChanged
    {
        private Car nextcar;
        private object message;
        private Car nextCar;
        private object vale;

        public object StartButton { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Controler.AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(accubatteryController, doorController, this);
        }

        private void OnStartClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleStartEngineButton();
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleThePowerButton();
        }

        private void DoorOpenButtonClick(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleTheDoorButton();
        }

        private void OnLockDoorButtonClick(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleTheLockDoorButton();
        }

        private void On(object sender, RoutedEventArgs e)
        {   

        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("OnAccuButtonClicked");
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("OnLockDoorButtonClicked");
        }

        private void DoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("DoorOpenButtonClicked");
        }

        public void onPowerChangedStatus(string value, string massage)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }

        public void doorSecurityChanged(string value, string massage)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = value;
        }

        public void doorstatusChanged(string value, string massage)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = value;
        }

        public void carEngineStatusChanged(string value, string message)
        {
            status.Content = message;
            StartButton = value;
        }
    }
}
