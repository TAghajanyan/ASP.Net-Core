using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Services
{
    public class WriteingService : IWriteing
    {
        public string Write()
        {
            return "Writeing Service!!";
        }
    }
}
