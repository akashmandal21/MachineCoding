using System;
namespace PublisherSunscriber
{
    public class Producer : IProducer
    {
        IPubSub ps;
        public Producer(IPubSub ps)
        {
            this.ps = ps;
        }
        public void addToQueue(Message message)
        {
            ps.addToQueue(message);
        }
    }
}
