using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using OvertimeDL;
using TimeManagementAPI;

namespace OvertimeBl
{
    public class OvertimeClass
    {
         InMemory overtime = new InMemory();
        DataService data = new DataService(new SQLdbdata());
        JsonClass j = new JsonClass();

        private readonly EmailService _emailService;

        TimeSpan time_in = new TimeSpan(9, 0, 0);
        TimeSpan time_out = new TimeSpan(17, 0, 0);

        public OvertimeClass(EmailService emailService)
        {
            _emailService = emailService;
        }

        public void AddTime(OvetimeClass3 newRecord)
        {
            overtime.Add(newRecord);
            data.Add(newRecord);
            j.Add(newRecord);

            _emailService.SendEmail(newRecord, "gabrieldetorres21@gmail.com"); 

        }

        public List<OvetimeClass3> GetTime()
        {
            return overtime.GetOver();
        }


        public void Overtimehours(OvetimeClass3 emp)
        {
            if (emp.TimeIn > time_in)
            {
                Console.WriteLine("Status: Late");
                overtime.Add(emp);
                data.Add(emp);
                j.Add(emp);

            }
            else if (emp.TimeIn < time_in)
            {
                Console.WriteLine("Early Bird");
                overtime.Add(emp);
                data.Add(emp);
                j.Add(emp);
            }
            else
            {
                Console.WriteLine("Status: On Time ");
                overtime.Add(emp);
                data.Add(emp);
                j.Add(emp);
            }

            if (emp.Timeout > time_out)
            {
                Console.WriteLine("Overtime");
                overtime.Add(emp);
                data.Add(emp);
                j.Add(emp);
            }
            else
            {
                Console.WriteLine("No Overtime");
                overtime.Add(emp);
                data.Add(emp);
                j.Add(emp);
            }
        }

        public void TotalHours(OvetimeClass3 emp)
        {
            TimeSpan hours = emp.Timeout - emp.TimeIn;
            Console.WriteLine("Total Working Hours: " + hours);
        }

    }
}
