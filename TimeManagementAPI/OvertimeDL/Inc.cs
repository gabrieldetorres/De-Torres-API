using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeDL
{
    public interface Inc
    {
         void Add(OvetimeClass3 over);
        List<OvetimeClass3> GetTime();
    }
}
