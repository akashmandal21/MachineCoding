using System;
namespace PublisherSunscriber
{
    public interface IProducer
    {
        void addToQueue(Message message);
    }
}
