using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string txt, string caption, int lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();
    public struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cxTopHeight;
        public int cxBottomHeight;
    }

    [DllImport("Dwmapi.dll")]
    public static extern uint DmwExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS lParam);

    private void Start()
    {
        MessageBox(new IntPtr(0), "Hello World!", "Hello Dailog!", 0);

        IntPtr hWnd = GetActiveWindow();
        MARGINS margin = new MARGINS { cxLeftWidth =-1};
        DmwExtendFrameIntoClientArea(hWnd, ref margin);
    }
}
