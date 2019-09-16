using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public enum StorageSpeed { USBRead = 25, USBWrite = 10, DVDRead = 11, DVDWrite = 4, HDDRead = 16, HDDWrite = 8};
    public enum DVDType{ unilateral = 1, bilateral = 2 };
    public enum DVDSize { UnilateralDVD = 4700,BilateralDVD = 8500};
    public enum DeviceType { Flash = 1, HDD = 2, DVD = 3 };
}
