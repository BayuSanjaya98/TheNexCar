using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNexCar
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged onDoorChanged;
        private MainWindow mainWindow;

        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.door = new Door();
            this.onDoorChanged = onDoorChanged;
        }

        public DoorController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void closed()
        {
            this.door.close();
            this.onDoorChanged.doorstatusChanged("CLOSED", "dor is closed");
        }
        public void open()
        {
            this.door.open();
            this.onDoorChanged.doorstatusChanged("OPENED", "dor is opened");
        }
        public void activateLock()
        {
            if (this.door.isClosed())
            {
                this.door.isClosed();
                onDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            }
            else
            {
                unlock(); 
            }
        }
        public void unlock()
        {
            this.door.unlock();
            onDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string massage);
        void doorstatusChanged(string vale, string massage);
    }
}
