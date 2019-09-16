using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class HDD : Storage
    {
        const int zero = 0;

        public int WriteSpeed { get; } //mb/sec
        public int ReadSpeed { get; }
        public int SectionCount { get; set; }
        public int SectionMemorySize{ get; set; }
        public int MemorySize { get; }
        public int FreeMemorySize { get; set; }

        public HDD(int sectionCount, int sectionMemorySize)
        {
            WriteSpeed = (int)StorageSpeed.HDDWrite;
            ReadSpeed = (int)StorageSpeed.HDDRead;
            SectionCount = sectionCount;
            SectionMemorySize = sectionMemorySize;
            MemorySize = SectionCount * SectionMemorySize;
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
            Console.WriteLine("Наименование носителя: USB 2.0 HDD диск");
            Console.WriteLine("Модель :" + this.Model);
            Console.WriteLine("Скорость чтения :" + ReadSpeed);
            Console.WriteLine("Скорость записи :" + WriteSpeed);
            Console.WriteLine("Обьем памяти :" + MemorySize);
        }
    }
}
