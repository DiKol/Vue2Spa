using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System;

namespace Vue2Spa
{
    public class Program
    {
        public  static List<Models.ToDo> ToDoList = new List<Models.ToDo>();
        public static void Main(string[] args)
        {

            for (int i = 0; i <= 10; i++)
            {
                var td = new Models.ToDo() { ID = i, Title = "Test" + i.ToString(), DueDate = DateTime.Now, Details = "Test Description" + i.ToString() };
                ToDoList.Add(td);
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .Build();
    }
}
