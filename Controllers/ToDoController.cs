using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<Models.ToDo> Get()
        {
            return Program.ToDoList;
        }

        [HttpPost("[action]")]
        public Models.ToDo Edit(int id)
        {

            return Program.ToDoList.FirstOrDefault(x => x.ID == id);
        }


        [HttpPost("[action]")]
        public void Remove(int id)
        {
            Program.ToDoList.RemoveAll(x => x.ID == id);
        }


        [HttpPost("[action]")]
        public void Add(string title, string date, string time, string details)
        {
            var m = new Models.ToDo();
            m.Title = title;
            m.Details = details;
            m.DueDate = ParseDate(date, time);
            m.ID = Program.ToDoList.Max(x => x.ID) + 1;

            Program.ToDoList.Add(m);
        }

        [HttpPost("[action]")]
        public void Update(int id, string title, string date, string time, string details)
        {

            foreach (var item in Program.ToDoList) {

                if (item.ID == id)
                {
                    item.Title = title;
                    item.Details = details;
                    item.DueDate = ParseDate(date, time);
                    break;
                }
            }

        }

        private DateTime ParseDate(string date, string time)
        {
            var dt = DateTime.Now;

            try
            {
                var culture = CultureInfo.InstalledUICulture;

                var dt1 = DateTime.Parse(date, culture);

                var parts = time.Split(new char[] { ':' });
                string hours = parts[0];
                string minutes = parts[1].Substring(0, 2);

                

                int h = 0;
                int mm = 0;
                if (int.TryParse(hours, out h))
                {
                    dt1.AddHours(h);
                }

                if (int.TryParse(minutes, out mm))
                {
                    dt1.AddHours(mm);
                }

                dt = new DateTime(dt1.Year, dt1.Month, dt1.Day, h, mm, 0);
            }
            catch (Exception e)
            {
                dt = DateTime.Now;
                //log error
            }
            return dt;

        }

    }
}
