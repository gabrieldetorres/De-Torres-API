using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OvertimeDL
{
    public class InMemory
    {
        public List<OvetimeClass3> over = new List<OvetimeClass3>();

        public void Add(OvetimeClass3 ove)
        {
            over.Add(ove);
        }
        public List<OvetimeClass3> GetOver()
        {
            return over;
        }
    }
}
