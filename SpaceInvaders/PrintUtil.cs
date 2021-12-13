using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class PrintUtil
    {
        public static void PrintBoarderedText(String text)
        {
            Debug.WriteLine("//--------------------------------------------------------");
            Debug.WriteLine("//" + text);
            Debug.WriteLine("//--------------------------------------------------------");
        }

        public static void PrintDividerText(String text)
        {
            Debug.WriteLine("//----------------------" + text);
        }
    }
}
