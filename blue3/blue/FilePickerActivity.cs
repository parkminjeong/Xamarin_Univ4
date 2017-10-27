
using Android.OS;
using Android.Support.V4.App;
using Android.App;

namespace blue
{
    [Activity(Label = "FilePickerActivity")]
    public class FilePickerActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.file_main);
        }

    }
}