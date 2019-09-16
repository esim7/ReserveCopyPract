using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class WorkPC
    {
        public string UserName { get; set; }
        public string FileName { get; }
        public int FileSize { get; set; }

        public WorkPC(string userName)
        {
            UserName = userName;
            FileName = "Рабочие документы";
            FileSize = 578560; //565 гигабайт
        }

    }
}
