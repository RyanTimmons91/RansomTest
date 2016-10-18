using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RansomTest.Utilities
{
    static class Drives
    {
        internal static List<object[]> GetDrives()
        {
            List<object[]> RowOut = new List<object[]>();
            
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    RowOut.Add(new object[2] { d.Name, d.DriveType });
                }
            }
            return RowOut;
        }
    }
}
