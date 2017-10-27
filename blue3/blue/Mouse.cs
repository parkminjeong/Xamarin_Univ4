using Android.App;
using Android.Widget;
using Android.OS;

using System;

using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Gestures;
using System.Windows;
using Android.Content.Res;
using Android.Content;


//using Xamarin.Forms;

namespace blue
{
    [Activity(Label = "mouse")]
    class Mouse : Activity, View.IOnTouchListener
    {
        public Android.Widget.Button MouseLeft, MouseRight;
        public View touch;


        private string MIn, CIn;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.mouse);

            MouseLeft = this.FindViewById<Android.Widget.Button>(Resource.Id.Mouse1);
            MouseLeft.Click += MouseLeft_Click;
            MouseRight = this.FindViewById<Android.Widget.Button>(Resource.Id.Mouse2);
            MouseRight.Click += MouseRight_Click;

            //----------
            Button btnkey = (Button)FindViewById(Resource.Id.btnkey);
            Button btnfile = (Button)FindViewById(Resource.Id.btnfile);
            Button btnm = (Button)FindViewById(Resource.Id.btnm);
            //----------

            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);
            string maxX = widthInDp.ToString();
            string maxY = heightInDp.ToString();
            MIn = "1818#" + maxX + "#" + maxY;
            touch = FindViewById<View>(Resource.Id.temp1);
            touch.SetOnTouchListener(this);

            //-------------------------------------
            btnkey.Click += delegate
            {
                Intent keyintent = new Intent(this, typeof(keyBoard));
                StartActivity(keyintent);
            };

            btnfile.Click += delegate
            {
                Intent fileintent = new Intent(this, typeof(FilePickerActivity));
                StartActivity(fileintent);
            };

            btnm.Click += delegate
            {
                Intent mouseintent = new Intent(this, typeof(Mouse));
                StartActivity(mouseintent);

            };
            //-------------------------------------
        }
        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void MouseLeft_Click(object sender, EventArgs e)
        {
            CIn = "#5000";
            Send(a, b, CIn);

        }
        private void MouseRight_Click(object sender, EventArgs e)
        {
            CIn = "#5100";

        }

        //------------
        private float start1_x, start1_y, ingx, ingy;
        public float x, y;
        private string a, b;
        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    start1_x = e.GetX();
                    start1_y = e.GetY();

                    break;
                case MotionEventActions.Move:
                    ingx = e.GetX();
                    ingy = e.GetY();
                    a = ingx.ToString();
                    b = ingy.ToString();
                    Send(a, b,CIn);
                    break;
            }
            return true;
        }
        public void Send(string a, string b, string c)
        {
            String sendtemp = MIn + "#" + a + "#" + b + CIn;
            var M_inform = new Java.Lang.String(sendtemp);
            ((MainActivity)MainActivity.mcontext).write(M_inform);
            CIn = null;
        }
    }
}
