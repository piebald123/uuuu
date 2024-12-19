using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VDOLPZZZ.AppData
{
    internal class Class1
    {
        public static Database1Entities1 c;
        public static Database1Entities1 context
        {
            get
            {
                if (c == null)
                    c = new Database1Entities1 ();
                return c;
            }
        }
    }
}
