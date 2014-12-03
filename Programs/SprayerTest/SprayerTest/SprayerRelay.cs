using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBRelay = TctecUSB4.TctecUSB4;
using System.Collections; 

namespace SprayerTest
{
    class SprayerRelay
    {
        String relayId;

        public SprayerRelay(String relayId) 
        {
            this.relayId = relayId;
        }

        public void changeSprayerStatus(int relayNumber, Boolean status) 
        {
            //Turns on/off the specified relay from 1-4
            USBRelay.setBits(relayId, (byte) getSprayerByte(relayNumber), status);
        } 

        private byte getSprayerByte(int relayNumber)
        {
            switch (relayNumber)
            {
                case 1:
                    return 0x01;
                case 2:
                    return 0x02;
                case 3:
                    return 0x04;
                case 4:
                    return 0x08;
                default:
                    return 0x00;
            }  
        } 

        public static String printIds()
        {
            ArrayList relayIds = USBRelay.getSerialNumbers();
            StringBuilder idString = new StringBuilder();
            for (int i = 0; i < relayIds.Count; i++)
            {
                idString.Append(relayIds[i].ToString() + "\r\n");
            } 
            return idString.ToString();
        } 
    }
}
