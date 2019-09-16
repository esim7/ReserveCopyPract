using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class Program
    {     
        static void Main(string[] args)
        {
            const int zero = 0;
            List <Storage> Devices = new List <Storage>();
            WorkPC pc = new WorkPC("User 228");
            bool isActive = true;
            string key;
            do
            {
                Console.Clear();
                int totalMemSize = 0;
                int totalWriteTime = 0;
                Console.WriteLine("На Вашем рабочем компьютере " + pc.FileSize + " мегабайт, рабочих документов\n");
                Console.WriteLine("1. Добавить устройство \n2. Расчет общего количества памяти всех устройств \n3. Копирование информации на устройства" +
                    " \n4. Расчет времени необходимого для копирования \n5. Расчет необходимого количества носителей информации \n6. Выход");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите какое устройство Вы" +
                                "хотите добавить \n1. Флеш накопитель \n2. Переносной HDD диск \n3. DVD компакт диск");
                            int storrageType; int.TryParse(Console.ReadLine(), out storrageType);
                            if (storrageType == (int)DeviceType.Flash)
                            {
                                Console.WriteLine("Введите модель флеш накопителя ");
                                string model = Console.ReadLine();
                                Console.WriteLine("Введите обьем памяти флеш накопителя (мегабайт)");
                                int memorySize; int.TryParse(Console.ReadLine(), out memorySize);
                                Flash flash = new Flash(memorySize);
                                flash.Model = model;
                                Devices.Add(flash);
                            }
                            else if (storrageType == (int)DeviceType.HDD)
                            {
                                Console.WriteLine("Введите модель HDD накопителя ");
                                string model = Console.ReadLine();
                                Console.WriteLine("Введите количество разделов HDD накопителя ");
                                int sectionCount; int.TryParse(Console.ReadLine(), out sectionCount);
                                Console.WriteLine("Введите емкость раздела HDD накопителя (мегабайт)");
                                int sectionSize; int.TryParse(Console.ReadLine(), out sectionSize);
                                HDD hdd = new HDD(sectionCount, sectionSize);
                                hdd.Model = model;
                                Devices.Add(hdd);
                            }
                            else if (storrageType == (int)DeviceType.DVD)
                            {
                                Console.WriteLine("Введите намименование DVD диска ");
                                string model = Console.ReadLine();
                                Console.WriteLine("Введите количество тип DVD диска \n1. Односторонний \n2. Двусторонний ");
                                int discType; int.TryParse(Console.ReadLine(), out discType);
                                DVD dvd = new DVD(discType);
                                dvd.Model = model;
                                Devices.Add(dvd);
                            }
                            break;
                        }
                    case "2":
                        {
                            if(Devices.Count == zero)
                            {
                                Console.WriteLine("Ошибка! Нет доступных устройств");
                            }
                            else if(Devices.Count > zero)
                            {
                                for (int i = 0; i < Devices.Count; i++)
                                {
                                    if (Devices[i] is Flash)
                                        totalMemSize += (Devices[i] as Flash).MemorySize;
                                    else if (Devices[i] is DVD)
                                        totalMemSize += (Devices[i] as DVD).MemorySize;
                                    else if (Devices[i] is HDD)
                                        totalMemSize += (Devices[i] as HDD).MemorySize;
                                }
                                Console.WriteLine("Общая физическая память всех носителей " + totalMemSize + " мегабайта");
                            }     
                        }
                        break;
                    case "3":
                        {
                            if (Devices.Count == zero)
                            {
                                Console.WriteLine("Ошибка! Нет доступных устройств");
                            }
                            else if (Devices.Count > zero)
                            {
                                for (int i = 0; i < Devices.Count; i++)
                                {
                                    if (Devices[i] is Flash)
                                        totalMemSize += (Devices[i] as Flash).MemorySize;
                                    else if (Devices[i] is DVD)
                                        totalMemSize += (Devices[i] as DVD).MemorySize;
                                    else if (Devices[i] is HDD)
                                        totalMemSize += (Devices[i] as HDD).MemorySize;
                                }
                                if (totalMemSize < pc.FileSize)
                                {
                                    Console.WriteLine("Ошибка, недостаточно памяти на Ваших носителях, добавьте еще устройство или повторите позднее :)");
                                }
                                else if (totalMemSize >= pc.FileSize)
                                {
                                    for (int i = 0; i < Devices.Count; i++)
                                    {
                                        if (Devices[i].GetFreeMemorySize() == zero)
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            if (Devices[i] is Flash)                                            
                                                (Devices[i] as Flash).Copy(pc);                                                                                                                                         
                                            else if (Devices[i] is DVD)                                           
                                                (Devices[i] as DVD).Copy(pc);                                                                                                                             
                                            else if (Devices[i] is HDD)                                           
                                                (Devices[i] as HDD).Copy(pc);                                                                                                                                        
                                        }
                                    }
                                    Console.WriteLine("Копирование успешно завершено!");
                                }                                 
                            }
                        }
                        break;
                    case "4":
                        {
                            if (Devices.Count == zero)
                                Console.WriteLine("Ошибка! Нет доступных носителей");
                            else if (Devices.Count > zero)
                            {
                                for(int i = 0; i < Devices.Count; i++)
                                {
                                    if (Devices[i] is Flash)                                    
                                        totalWriteTime += ((Devices[i] as Flash).MemorySize / (Devices[i] as Flash).WriteSpeed);                                 
                                    else if (Devices[i] is DVD)                            
                                        totalWriteTime += ((Devices[i] as DVD).MemorySize / (Devices[i] as DVD).WriteSpeed);                                 
                                    else if (Devices[i] is HDD)                                    
                                        totalWriteTime += ((Devices[i] as HDD).MemorySize / (Devices[i] as HDD).WriteSpeed);                                   
                                }
                            }
                            var ts = TimeSpan.FromSeconds(totalWriteTime);
                            Console.WriteLine("Примерное время для копирования на имеющиеся у Вас устройства ");
                            Console.WriteLine("{0} д. {1} ч. {2} м. {3} с. {4} мс.", ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                        }
                        break;
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите тип устройства для которого нужно расчитать необходимое количество");
                            Console.WriteLine("1. Флеш накопитель \n2. HDD диск\n3. DVD диск");
                            string command = Console.ReadLine();
                            if (command == "1")
                            {
                                Console.WriteLine("Введите обьем имеющихся флеш накопителей (мегабайт)");
                                int size;
                                int.TryParse(Console.ReadLine(), out size);
                                int devicesCount = pc.FileSize / size;
                                if((devicesCount * size) < pc.FileSize)
                                {
                                    devicesCount++;
                                }
                                Console.WriteLine("Для полного копирования рабочих данных нужно " + devicesCount + " флеш накопителей");
                            }
                            if (command == "2")
                            {
                                Console.WriteLine("Введите количество разделов на имеющихся HDD накопителях");
                                int sections;
                                int.TryParse(Console.ReadLine(), out sections);
                                Console.WriteLine("Введите обьем раздела (мегабайт)");
                                int sectionSize;
                                int.TryParse(Console.ReadLine(), out sectionSize);
                                int devicesCount = pc.FileSize / (sections * sectionSize);
                                if(devicesCount * (sections * sectionSize) < pc.FileSize)
                                {
                                    devicesCount++;
                                }
                                Console.WriteLine("Для полного копирования рабочих данных нужно " + devicesCount + " HDD накопителей");
                            }
                            if (command == "3")
                            {
                                Console.WriteLine("Введите тип DVD диска \n1. Односторонний \n2. Двусторонний");
                                string dvdType = Console.ReadLine();
                                int deviceCount;
                                if (dvdType == "1")
                                {
                                    deviceCount = pc.FileSize / (int)DVDSize.UnilateralDVD;
                                    if (deviceCount * (int)DVDSize.UnilateralDVD < pc.FileSize)
                                    {
                                        deviceCount++;
                                    }
                                    Console.WriteLine("Для полного копирования рабочих данных нужно " + deviceCount + " DVD дисков");
                                }
                                else if (dvdType == "2")
                                {
                                    deviceCount = pc.FileSize / (int)DVDSize.BilateralDVD;
                                    if (deviceCount * (int)DVDSize.BilateralDVD < pc.FileSize)
                                    {
                                        deviceCount++;
                                    }
                                    Console.WriteLine("Для полного копирования рабочих данных нужно " + deviceCount + " DVD дисков");
                                }
                            }
                        }
                        break;
                    case "6":
                        {
                    isActive = false;
                        }
                        break;
                }
            Console.ReadLine();
            } while (isActive != false);
        }
    }
}
