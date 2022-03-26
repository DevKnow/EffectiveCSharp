using System;

namespace Item8_51page
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class EventSource
    {
        private EventHandler<int> Update;

        public void RaiseUpdates()
        {
            counter++;
            //var handler = Update;
            //if(handler!=null)
            //    handler(this, counter);
            Update?.Invoke(this, counter);
        }

        private int counter = 0;
    }
}
