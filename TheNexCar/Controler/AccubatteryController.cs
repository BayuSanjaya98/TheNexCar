using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNexCar.Model;

namespace TheNexCar.Controler
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callBackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callBackOnPowerChanged)
        {
            this.callBackOnPowerChanged = callBackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callBackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }
        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callBackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }

        internal bool accubatteryIsOn()
        {
            throw new NotImplementedException();
        }
    }

    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string massage);
    }

}
