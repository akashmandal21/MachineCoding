using System;
namespace PublisherSunscriber
{
    public interface IPubSub
    {
        void addSubscriber(string regex, Consumer consumer);
        void addToQueue(Message message);
        void getQueuedMessages(Consumer consumer);
        void getSubscribedMessages(Consumer consumer);
    }
}
