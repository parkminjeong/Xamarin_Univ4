using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;

namespace blue
{
    class dialog:DialogFragment
    {
        private static BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
        private static ArrayAdapter<string> paireeddevice;
        private static ArrayAdapter<string> newdevice;
        private static ArrayList ar = new ArrayList();
        private Receiver receiver;
        private iondateselectedlistener onda;
        public interface iondateselectedlistener
        {
            void ondateselected(BluetoothDevice address);
        }
        public class DE
        {
            public string name;
            public string address;

            public DE(string n, string a)
            {
                this.name = n;
                this.address = a;
            }
        }



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.device,container,false);
            this.Dialog.SetTitle("장치 검색");

            if (adapter.IsDiscovering)
            {
                adapter.CancelDiscovery();
            }
            adapter.StartDiscovery();

            paireeddevice = new ArrayAdapter<string>(this.Activity, Resource.Layout.list);
            newdevice = new ArrayAdapter<string>(this.Activity, Resource.Layout.list);

            var pairedlist = view.FindViewById<ListView>(Resource.Id.pairedlist);
            pairedlist.Adapter = paireeddevice;
            pairedlist.ItemClick += device_click;

            var newlist = view.FindViewById<ListView>(Resource.Id.newdevice);
            newlist.Adapter = newdevice;
            newlist.ItemClick += device_click;

            receiver = new Receiver();

            var filter = new IntentFilter(BluetoothDevice.ActionFound);
            Activity.RegisterReceiver(receiver, filter);

            filter = new IntentFilter(BluetoothAdapter.ActionDiscoveryFinished);
            Activity.RegisterReceiver(receiver, filter);

            var device = adapter.BondedDevices;
            if (device.Count > 0)
            {
                foreach(var dev in device)
                {
                    paireeddevice.Add(dev.Name);
                    ar.Add(new DE(dev.Name, dev.Address));
                }
            }
            else
            {
                paireeddevice.Add("not found");
            }

            return view;
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            Activity act = this.Activity;
            onda = (iondateselectedlistener)act;
        }

        private void device_click(object sender, AdapterView.ItemClickEventArgs e)
        {
            adapter.CancelDiscovery();

            var info = (e.View as TextView).Text.ToString();
            foreach(DE d in ar)
            {
               
                if (info.Equals(d.name) == true)
                {
                    BluetoothDevice dev = adapter.GetRemoteDevice(d.address);
                    onda.ondateselected(dev);
                    Dismiss();
                }
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            if (adapter != null)
            {
                adapter.CancelDiscovery();
            }
            Activity.UnregisterReceiver(receiver);
        }
        private class Receiver: BroadcastReceiver
        {
            BluetoothDevice devi;

            public override void OnReceive(Context context, Intent intent)
            {
                string action = intent.Action;

                if (action == BluetoothDevice.ActionFound)
                {
                    devi = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                    if (devi.BondState != Bond.Bonded)
                    {
                        newdevice.Add(devi.Name);
                        ar.Add(new DE(devi.Name, devi.Address));
                    }
                }
                else if (action == BluetoothAdapter.ActionDiscoveryFinished)
                {
                    if (newdevice.Count == 0)
                    {
                        newdevice.Add("not found");
                    }
                }
            }
        }
    }


}