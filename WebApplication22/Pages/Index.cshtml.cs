using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Visma.Training.Serverless.ServiceBus;

namespace WebApplication22.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var serviceBus = Request.Query["sb"];
            var topicname = Request.Query["topic"];
            var num = 0;
            try
            {
                num = Int32.Parse(Request.Query["num"]);
            }
            catch (Exception)
            {
                num = 10;
            }

            var txt = Request.Query["content"];

            if (num > 50)
                num = 50;

            if (!string.IsNullOrEmpty(serviceBus))
            {
               SendTopic.Send(serviceBus, topicname, txt, num);
             }

        }
 
    }
}
