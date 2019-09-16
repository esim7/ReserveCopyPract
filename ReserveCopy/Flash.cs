using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class Flash : Storage
    {
        const int zero = 0;

        public int WriteSpeed { get; set; } //mb/sec
        public int ReadSpeed { get; set; }
        public int MemorySize { get; set; }
        public int FreeMemorySize { get; set; }

        public Flash(int memorySize)
        {
            WriteSpeed = (int)StorageSpeed.USBWrite;
            ReadSpeed = (int)StorageSpeed.USBRead;
            MemorySize = memorySize;
            FreeMemorySize = MemorySize;
        }

        public override void Copy(WorkPC obj)
        {
            while (GetFreeMemorySize() != 0 && obj.FileSize != 0)
            {
                obj.FileSize--;
                FreeMemorySize--;
                if(FreeMemorySize == zero)
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
            Console.WriteLine("Наименование носителя: USB 3.0 Flash накопитель");
            Console.WriteLine("Модель :" + this.Model);
            Console.WriteLine("Скорость чтения :" + ReadSpeed);
            Console.WriteLine("Скорость записи :" + WriteSpeed);
            Console.WriteLine("Обьем памяти :" + MemorySize);
        }
    }
}
