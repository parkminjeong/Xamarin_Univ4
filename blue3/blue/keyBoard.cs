using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace blue
{
    [Activity(Label = "keyBoard")]
    class keyBoard : Activity
    {
        private string keyname;
        private string sendtext;
        private EditText edtText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.key);
            Button btnkey = (Button)FindViewById(Resource.Id.btnkey);   //Ű����
            Button btnsend = (Button)FindViewById(Resource.Id.btnsend);  //����
            Button btnLeft = (Button)FindViewById(Resource.Id.btnLeft);   //����
            Button btnRight = (Button)FindViewById(Resource.Id.btnRight);   //������
            Button btnUp = (Button)FindViewById(Resource.Id.btnUp);   // �� 
            Button btnDown = (Button)FindViewById(Resource.Id.btnDown);  // �Ʒ�
            EditText editText1 = (EditText)FindViewById(Resource.Id.editText1);  //�����ؽ�Ʈ
            Button btnfile = (Button)FindViewById(Resource.Id.btnfile);   // ��������
            Button btnm = (Button)FindViewById(Resource.Id.btnm);   // ���콺
            Button btnSpacebar = (Button)FindViewById(Resource.Id.btnSpacebar);

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

            //-----------------------------------------------------------


            btnLeft.Click += btnLeft_Click;
            btnRight.Click += btnRight_Click;
            btnsend.Click += btnsend_Click;
            btnUp.Click += btnUp_Click;
            btnDown.Click += btnDown_Click;
            btnSpacebar.Click += btnSpacbar_Click;
            //  sendText = (editText1.GetType().ToString());
          





        }// oncreate;;;

        private void btnSpacbar_Click(object sender, EventArgs e)
        {
            keyname = "#32";
            Sendkey(keyname);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            keyname = "#40";
            Sendkey(keyname);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            keyname = "#38";
            Sendkey(keyname);
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            //sendtext = editText1.Text;
           // textstring(sendtext);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            keyname = "#37";
            Sendkey(keyname);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            keyname = "#39";
            Sendkey(keyname);
        }

        public void Sendkey(string keyname)

        {
            // string len = Convert.ToString(length);
           String sendtemp = "123" + keyname;    //+" " + sendText;
          
            var M_inform = new Java.Lang.String(sendtemp);
            ((MainActivity)MainActivity.mcontext).write(M_inform);
            
        }

        public void textstring(string sendtext)
        {
            String sendtemp = "123" +"999"+ sendtext;
            var M_inform = new Java.Lang.String(sendtemp);
            ((MainActivity)MainActivity.mcontext).write(M_inform);
        }



    }
}