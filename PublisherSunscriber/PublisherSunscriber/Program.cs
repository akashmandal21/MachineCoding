using System;

namespace PublisherSunscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            IPubSub ps = new PubSub(1);
            IProducer p = new Producer(ps);
            IConsumer c1 = new Consumer(ps, "reg1", "c1");
            IConsumer c2 = new Consumer(ps, "reg1", "c2");
            IConsumer c3 = new Consumer(ps, "reg1", "c3");
            IConsumer c4 = new Consumer(ps, "reg2", "c4");
            IConsumer c5 = new Consumer(ps, "reg2", "c5");

            c1.addConsumer();
            c2.addConsumer();
            c3.addConsumer();
            c4.addConsumer();
            c5.addConsumer();
            c1.addDependency(c2);

            Message m1 = new Message("reg1", "reg1abcd");
            p.addToQueue(m1);

            Message m2 = new Message("reg2", "reg1abcd");
            p.addToQueue(m2);

            Message m3 = new Message("reg2", "reg2abcd");
            p.addToQueue(m3);

            c1.getSubscribedMessages();
            c2.getSubscribedMessages();
            c3.getSubscribedMessages();
            c4.getSubscribedMessages();
            c5.getSubscribedMessages();
        }
    }
}
