using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodelås
{
    public class Lock
    {
        public int Code { get; set; }
        public int Length { get; set; }
        public bool IsLockd = true;
        public int Try = 3;

        public Lock()
        {
            Code = 6047;
            Length = 4;
        }
    }
}
