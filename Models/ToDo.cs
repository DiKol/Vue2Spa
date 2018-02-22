using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vue2Spa.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string DueDatePart { get { return DueDate.ToShortDateString(); } }
        public string DueTimePart { get { return DueDate.ToShortTimeString(); } }
        public string Details { get; set; }

    }
}
