using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class DVD : Storage
    {
        const int zero = 0;

        public int WriteSpeed {get;}//mb/sec
        public int ReadSpeed {get;}
        public DVDType DiscType { get; set; }
        public int MemorySize { get; }
        public int FreeMemorySize { get; set; }

        public DVD(int discType)
        {
            WriteSpeed = (int)StorageSpeed.DVDWrite;
            ReadSpeed = (int)StorageSpeed.DVDRead;
            DiscType = (DVDType)discType;
            if(DiscType == DVDType.unilateral)
            {
                MemorySize = (int)DVDSize.UnilateralDVD;
            }
            else if(DiscType == DVDType.bilateral)
            {
                MemorySize = (int)DVDSize.BilateralDVD;
            }
            FreeMemorySize = MemorySize;
        }

        public override void Copy(WorkPC obj)
        {
            while (GetFreeMemorySize() != 0 && obj.FileSize != 0)
            {
                obj.FileSize--;
                FreeMemorySize--;
                if (FreeMemorySize == zero)
                    Console.WriteLine("Устройство " + this.Model + " заполненно");
                Console.WriteLine("Осталось скопировать " + obj.FileSize + " мегабайт рабочих файлов");
            }
        }

        public override int GetFreeMemorySize()
        {
            return FreeMemorySize;
        }

        public override int GetMemorySize()
        {
            return MemorySize;
        }

        public override void GetStorageInfo()
        {
            Console.WriteLine("Наименование носителя: DVD компакт диск " + DiscType);
            Console.WriteLine("Модель :" + this.Model);
            Console.WriteLine("Скорость чтения :" + ReadSpeed);
            Console.WriteLine("Скорость записи :" + WriteSpeed);
            Console.WriteLine("Обьем памяти :" + MemorySize);
        }
    }
}
