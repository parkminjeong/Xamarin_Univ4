using Android.Bluetooth;
using Java.Lang;
using Java.Util;
using System.IO;

namespace blue
{

    class connect: Thread
    {
        private const string TAG = "BluetoothChat";
        private BluetoothSocket msocket;
        private BluetoothDevice mdevice;
        private Stream mmoutstream;
        private static UUID MY_UUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
        

        public connect(BluetoothDevice device)
        {
            BluetoothSocket tmp = null;
            mdevice = device;

            try
            {
                tmp = device.CreateRfcommSocketToServiceRecord(MY_UUID);
            }
            catch (Java.IO.IOException) { }
            msocket = tmp;
            Stream tmpout = null;
            try
            {
                tmpout = msocket.OutputStream;
            }
            catch (Java.IO.IOException) { }
            mmoutstream = tmpout;
        }
        public void run()
        {
            try
            {
                msocket.Connect();
            }
            catch (Java.IO.IOException)
            {
                try
                {
                    msocket.Close();
                }
                catch (Java.IO.IOException) { }
                return;
            }
        }
        public void SendFile() { 

        }

        public void write(byte[] bytes)
        {
            try
            {
                mmoutstream.Write(bytes, 0, bytes.Length);

            }
            catch (Java.IO.IOException) { }
        }

        public void cancel()
        {
            try
            {
                msocket.Close();
            }
            catch (Java.IO.IOException) { }
        }
    }
}