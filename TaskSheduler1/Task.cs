using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSheduler1
{
    class Task
    {
        public int id { get; set; }
        public string start_dat { get; set; }
        public DateTime DstartDat { get; set; }
        public int status { get; set; } //1 - Выполнен // 2 - В работе
        public string name { get; set; }
        public string description { get; set; }
        public string endDate{ get; set; } //Дата завершения
        public DateTime DendDate { get; set; }

        public bool notif_end = false;

        public bool notif_any = false;

        public DateTime Dnotif_any;
        public Task(string[] inp)
        {
            //id`Статус`Название`Описание`Дата завершения`Увед. По заверш(1-Да)`Увед в Date(1-Да)`Date
            try
            {
                id = Convert.ToInt32(inp[0]);
                status = Convert.ToInt32(inp[1]);
                name = inp[2];
                description = inp[3];
                endDate = inp[4];
                start_dat = inp[5];
                DstartDat = Containerr.convert(start_dat);
                if (endDate != "")
                {
                    DendDate = Convert.ToDateTime(endDate);
                }
                if(inp[6]=="1") notif_end = true;
                if (inp[7] == "1")
                {
                    try {
                        notif_any = true;
                        Dnotif_any = Convert.ToDateTime(inp[8]);
                    }
                    catch {}
                }
            }
            catch{}
        }
    }
}
