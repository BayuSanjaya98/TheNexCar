using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNexCar.Controler
{
    class Car
    {
        private AccubatteryController accubatteryController;
        private DoorController doorController;
        private OnCarEngineStatusChanged callbackCarEngineStatusChanged;
        private MainWindow mainWindow;

        public Car(AccubatteryController accubatteryController, DoorController doorController, OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accubatteryController = accubatteryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public Car(AccubatteryController accubatteryController, DoorController doorController, MainWindow mainWindow)
        {
            this.accubatteryController = accubatteryController;
            this.doorController = doorController;
            this.mainWindow = mainWindow;
        }

        public void turnOnPower()
        {
            this.accubatteryController.turnOn();
        }
        public void turnOfPower()
        {
            this.accubatteryController.turnOff();
        }
        public bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }
        public void closeTheDoor()
        {
            this.doorController.closed();
        }
        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }
        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }
        private bool doorIsClosed()
        {
            return this.doorController.isLocked();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        public void toggleStartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPED", "door is open");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPED", "door is unlocked");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPED", "no power availabe");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine started");
        }
        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }
        public void toggleTheDoorButton()
        {
            if (!doorIsClosed())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }
        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOfPower();
            }
        }
    }

    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
}
