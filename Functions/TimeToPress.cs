using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class TimeToPress
    {
        public static bool TimeToPressKey()
        {
            DateTime tijd_ = DateTime.Now;
            if ((DateTime.Now - tijd_).TotalMilliseconds > 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
