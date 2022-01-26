using System;
namespace PublisherSunscriber
{
    public interface IConsumer
    {
        void addConsumer();
        void addToMessageList(Message message);
        void addDependency(IConsumer c2);
        void getSubscribedMessages();
        //void getSubscribedMessages();
    }
}
