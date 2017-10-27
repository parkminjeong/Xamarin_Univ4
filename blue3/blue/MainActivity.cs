using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Lang;
using System;
using System.IO;
using Java.Util;

namespace blue
{
    [Activity(Label = "blue", MainLauncher = true, Icon = "@drawable/icon",Theme ="@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity, dialog.iondateselectedlistener
    {
        private static BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
                    private connect con;
        public static Context mcontext;
        private BluetoothDevice ad;

        public void ondateselected(BluetoothDevice address)
        {
            ad = address;
            if (con != null)
            {
                con.cancel();
                con = null;
            }
            con = new connect(address);
            con.run();

            Intent mousee = new Intent(this, typeof(Mouse));
            StartActivity(mousee);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button bt_s = (Button)FindViewById(Resource.Id.blue);
            bt_s.Click += Bt_s_Click;
            mcontext = this;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (adapter != null)
            {
                adapter.CancelDiscovery();
            }
        }

        private void Bt_s_Click(object sender, EventArgs e)
        {
            if (adapter == null)
            {
                Toast.MakeText(this, "이 장치는 블루투스를 지원하지 않습니다.", ToastLength.Short).Show();
            }
            if (!adapter.IsEnabled)
            {
                Intent enableBtIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                StartActivityForResult(enableBtIntent, 0);
            }
            AlertDialog.Builder list = new AlertDialog.Builder(this);
            list.SetTitle("장치검색");
            list.SetMessage("장치를 검색하시겠습니까?");
            list.SetPositiveButton("검색", (senderAlert, args) => {
                Toast.MakeText(this, "검색을 시작합니다.", ToastLength.Short).Show();
                searchdevice();
            });
            list.SetNegativeButton("취소", (senderAlert, args) =>
            {
                Toast.MakeText(this, "검색을 취소했습니다.", ToastLength.Short).Show();
            });
            Dialog dialog = list.Create();
            dialog.Show();
        }

        private void searchdevice()
        {
            Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog mmdialog = new dialog();
            mmdialog.Show(transaction, "dialog fragment");
        }

        public void write(Java.Lang.String tm)
        {
            byte[] bytes = tm.GetBytes();
            con.write(bytes);//서버에 메시지 보내기
        }
        public void writeb(byte[] b)
        {            
            con.write(b);//서버에 메시지 보내기
        }
    }
}

