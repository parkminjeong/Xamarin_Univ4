using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    internal struct MouseInput
    {
        public int X, Y;
        public uint MouseData, Flags, Time;
        public IntPtr ExtraInfo;
    }

    internal struct Input
    {
        public int Type;
        public MouseInput MouseInput;
    }

    public static class Mouse
    {
        public const int InputMouse = 0;

        public const int MouseEventMove = 0x01;
        public const int MouseEventLeftDown = 0x02;
        public const int MouseEventLeftUp = 0x04;
        public const int MouseEventRightDown = 0x08;
        public const int MouseEventRightUp = 0x10;
        public const int MouseEventAbsolute = 0x8000;

        private static bool lastLeftDown, lastRightDown;

        [DllImport("user32.dll", SetLastError = true)]  //c언어로 되있는 라이브러리 c#에서 사용하기 위해
        private static extern uint SendInput(uint numInputs, Input[] inputs, int size);

        public static void SendMouseInput(int positionX, int positionY, int maxX, int maxY, bool leftDown, bool two)
        {
            if (positionX > int.MaxValue)
                throw new ArgumentOutOfRangeException("positionX");
            if (positionY > int.MaxValue)
                throw new ArgumentOutOfRangeException("positionY");

            Input[] i = new Input[2];

            // move the mouse to the position specified
            i[0] = new Input();
            i[0].Type = InputMouse;
            i[0].MouseInput.X = (positionX * 65535) / maxX;
            i[0].MouseInput.Y = (positionY * 65535) / maxY;
            i[0].MouseInput.Flags = MouseEventAbsolute | MouseEventMove;

            // determine if we need to send a mouse down or mouse up event
            if (!lastLeftDown && leftDown)
            {
                i[1] = new Input();
                i[1].Type = InputMouse;
                i[1].MouseInput.Flags = MouseEventLeftUp;     
            }
            else if (lastLeftDown && !leftDown)
            {
                i[1] = new Input();
                i[1].Type = InputMouse;
                i[1].MouseInput.Flags = MouseEventLeftDown;
            }
            else if (!lastRightDown && two)
            {
                i[1] = new Input();
                i[1].Type = InputMouse;
                i[1].MouseInput.Flags = MouseEventRightUp;

            }
            else if (lastRightDown && !two)
            {
                i[1] = new Input();
                i[1].Type = InputMouse;
                i[1].MouseInput.Flags = MouseEventRightDown;
            }

            lastLeftDown = leftDown;
            lastRightDown = two;
            // send it off
            uint result = SendInput(2, i, Marshal.SizeOf(i[0]));
            if (result == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}

