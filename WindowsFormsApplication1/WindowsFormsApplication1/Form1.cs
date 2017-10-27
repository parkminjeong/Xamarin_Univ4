using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InTheHand.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1

{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        public Form1()
        {
            InitializeComponent();//UI 컴포넌트를 생성하는 역할
        }

        private void Form1_Load(object sender, EventArgs e)//폼이 로드될때 실행
        {
            server();
        }

        private void server()
        {
            Thread bluetoothserverthread = new Thread(new ThreadStart(serverconnectthread));
            bluetoothserverthread.Start();//서버 스래드 실행
        }

        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        bool serverStarted = false;
        private void serverconnectthread()
        {
            serverStarted = true;
            updateUI("서버 실행 ㄱㄱ , 클라이언트 기다리고 있지롱");
            BluetoothListener blueListener = new BluetoothListener(mUUID);
            blueListener.Start();
            BluetoothClient conn = blueListener.AcceptBluetoothClient();
            updateUI("클라이언트 접속 ㅇㅇ");

            Stream mstream = conn.GetStream();
            char delimiterChars = '#'; //자르는 기준 * 일단은 공백
            while (true)
            {
                try {
                    byte[] received = new byte[1024];
                    mstream.Read(received, 0, received.Length);
                    //updateUI("received: " + Encoding.ASCII.GetString(received));

                    String meg = Encoding.ASCII.GetString(received);
                    string[] words = meg.Split(delimiterChars); // delimiterChars를 기준으로 메시지를 자름
                    int command = Convert.ToInt32(words[0]);

                    if (command == 111)
                    { // 파일전송일 경우
                        int fileLength = Int32.Parse(words[1]); //파일크기
                        String fileName = words[2];  //파일이름
                        int totalLength = 0;  //현재까지 받은 파일 크기
                        string filePath = @"C:\" + fileName;
                        Console.WriteLine(filePath);
                        FileStream fileStr = new FileStream("vpn.hwp", FileMode.Create, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(fileStr);

                        while (totalLength < fileLength)
                        {
                            int receveLength = mstream.Read(received, 0, received.Length);
                            writer.Write(received, 0, receveLength);
                            totalLength += receveLength;
                        }
                        writer.Close();
                    }
                    else if (command == 123)
                    {
                        int command1 = Convert.ToInt32(words[1]);

                        if (command1 == 32)
                        {
                            keybd_event(32, 0, 0x00, 0);
                            keybd_event(32, 0, 0x02, 0);

                        }

                        else if (command1 == 37)
                        {
                            keybd_event(37, 0, 0x00, 0);
                            keybd_event(37, 0, 0x02, 0);

                        }
                        else if (command1 == 38)
                        {
                            keybd_event(38, 0, 0x00, 0);
                            keybd_event(38, 0, 0x02, 0);

                        }

                        else if (command1 == 39)
                        {
                            keybd_event(39, 0, 0x00, 0);
                            keybd_event(39, 0, 0x02, 0);
                        }
                        else if (command1 == 40)
                        {
                            keybd_event(40, 0, 0x00, 0);
                            keybd_event(40, 0, 0x02, 0);
                        }
                        else if (command1 == 999)
                        {

                            Console.WriteLine();
                        };
                        
                    }

                    else if (command == 1818)
                    {
                        int maxX, maxY, posiX = 0, posiY = 0;
                        float tempfloat;
                        tempfloat = float.Parse(words[1]);
                        Math.Truncate(tempfloat);
                        maxX = (int)tempfloat;
                        tempfloat = float.Parse(words[2]);
                        Math.Truncate(tempfloat);
                        maxY = (int)tempfloat;
                        tempfloat = float.Parse(words[3]);
                        Math.Truncate(tempfloat);
                        posiX = (int)tempfloat;
                        tempfloat = float.Parse(words[4]);
                        Math.Truncate(tempfloat);
                        posiY = (int)tempfloat;
                        if (words.Length == 6)
                        {
                            int direction = int.Parse(words[5]);
                      
                            if (direction==5100)
                            {
                                  Console.WriteLine("dwdwdwd{0}",words[5]);
                                Console.WriteLine("dwdwdwd{");
                                Mouse.SendMouseInput(posiX, posiY, maxX, maxY, false, true);
                            }
                            else
                            {
                                Console.WriteLine("{0}", words[5]);
                                Mouse.SendMouseInput(posiX, posiY, maxX, maxY, true, false);
                            }
                        }

                        else
                        {
                            Console.WriteLine("빠다다닥");

                            Mouse.SendMouseInput(posiX, posiY, maxX, maxY, false, false);
                        }
                    }
                }
                catch(IOException e)
                {
                    return;
                }
            }
        }

        private void updateUI(string message) //폼에 메시지 출력 함수
        {
            Func<int> del = delegate ()
            {
                textBox1.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
