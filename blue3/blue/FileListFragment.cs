   using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
namespace blue
{

    /// <summary>
    ///   A ListFragment that will show the files and subdirectories of a given directory.
    /// </summary>
    /// <remarks>
    ///   <para> This was placed into a ListFragment to make this easier to share this functionality with with tablets. </para>
    ///   <para> Note that this is a incomplete example. It lacks things such as the ability to go back up the directory tree, or any special handling of a file when it is selected. </para>
    /// </remarks>
    public class FileListFragment : ListFragment
    {
        public static readonly string DefaultInitialDirectory = "/sdcard/";
        private FileListAdapter _adapter;
        private DirectoryInfo _directory;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _adapter = new FileListAdapter(Activity, new FileSystemInfo[0]);
            ListAdapter = _adapter;
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var fileSystemInfo = _adapter.GetItem(position);

            if (fileSystemInfo.IsFile())
            {
                fileSend(fileSystemInfo.FullName);
                Log.Verbose("FileListFragment", "The file {0} was clicked.", fileSystemInfo.FullName);                
                Toast.MakeText(Activity, "You selected file " + Path.GetFileName(fileSystemInfo.FullName), ToastLength.Short).Show();
            }
            else
            {
                // Dig into this directory, and display it's contents
                RefreshFilesList(fileSystemInfo.FullName);
            }

            base.OnListItemClick(l, v, position, id);
        }

        public override void OnResume()
        {
            base.OnResume();
            RefreshFilesList(DefaultInitialDirectory);
        }

        public void RefreshFilesList(string directory)
        {
            IList<FileSystemInfo> visibleThings = new List<FileSystemInfo>();
            var dir = new DirectoryInfo(directory);

            try
            {
                foreach (var item in dir.GetFileSystemInfos().Where(item => item.IsVisible()))
                {
                    visibleThings.Add(item);
                }
            }
            catch (Exception ex)
            {
                Log.Error("FileListFragment", "Couldn't access the directory " + _directory.FullName + "; " + ex);
                Toast.MakeText(Activity, "Problem retrieving contents of " + directory, ToastLength.Long).Show();
                return;
            }

            _directory = dir;

            _adapter.AddDirectoryContents(visibleThings);

            // If we don't do this, then the ListView will not update itself when then data set 
            // in the adapter changes. It will appear to the user that nothing has happened.
            ListView.RefreshDrawableState();

            Log.Verbose("FileListFragment", "Displaying the contents of directory {0}.", directory);
        }
        public void fileInfoSend(string fileName,int length)
        {
            string len = Convert.ToString(length);
            String sendtemp = "111" + "#" + len + "#" + fileName;
            Console.WriteLine(sendtemp);
            var M_inform = new Java.Lang.String(sendtemp);
            ((MainActivity)MainActivity.mcontext).write(M_inform);
        }
        public void fileSend(string filePath)
        {
            String fileName = Path.GetFileName(filePath); //파일이름 추출
            FileStream fileStr = new FileStream(filePath, FileMode.Open, FileAccess.Read); //파일 열기
            int fileLength = (int)fileStr.Length;  //파일 크기 가져오기
            byte[] buffer = BitConverter.GetBytes(fileLength);  //파일 크기를 서버에 전송하기 위해 바이트 배열로 전환
            fileInfoSend(fileName, fileLength); //파일정보 전송
            int conut = fileLength / 1024 + 1; // 파일 보낼 횟수
            BinaryReader reader = new BinaryReader(fileStr);  //파일을 읽기 위해 BinaryRearder 객체 생성

            //파일 송신 작업
            for (int i = 0; i < conut; i++)
            {
                buffer = reader.ReadBytes(1024);
                ((MainActivity)MainActivity.mcontext).writeb(buffer);
            }
            reader.Close();
        }
    }
}
