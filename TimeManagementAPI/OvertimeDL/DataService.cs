using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeDL
{
    public class DataService
    {
        Inc _dataService;
        public DataService(Inc dataService)
        {
            _dataService = dataService;
        }

        public void Add(OvetimeClass3 over)
        {
            _dataService.Add(over);
        }
        public List<OvetimeClass3> GetTime()
        {
            return _dataService.GetTime();
        }
    }
}
