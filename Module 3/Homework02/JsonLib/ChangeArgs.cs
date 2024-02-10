using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLib
{
    public class ChangeArgs : EventArgs
    {
        public DateTime Dt { get; private set; }

        public ChangeArgs(DateTime dt)
        {
            Dt = dt;
        }

        public ChangeArgs() : this(DateTime.Now) { }

    }
}
