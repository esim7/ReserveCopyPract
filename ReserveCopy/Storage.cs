using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public abstract int GetMemorySize();
        public abstract void Copy(WorkPC obj);
        public abstract int GetFreeMemorySize();
        public abstract void GetStorageInfo();
    }
}
