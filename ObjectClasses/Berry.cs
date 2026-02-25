using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.ObjectClasses
{
    internal class Berry
    {
        Random random = new Random();
        public int position { get; set; }
        public Berry(int screenWidthHeight_)
        {
            position = random.Next(1, screenWidthHeight_ - 2);
        }


        public void RandomPositon(int screenWidthHeight_)
        {
            position = random.Next(1, screenWidthHeight_ - 2);


        }
    }
}
