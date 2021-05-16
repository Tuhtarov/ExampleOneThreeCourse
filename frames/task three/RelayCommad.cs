using System;

namespace PraktikaCourse3.frames.task_three
{
    internal class RelayCommad
    {
        private Func<object> p;

        public RelayCommad(Func<object> p)
        {
            this.p = p;
        }
    }
}