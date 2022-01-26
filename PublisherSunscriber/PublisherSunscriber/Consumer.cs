using System;
using System.Collections.Generic;

namespace PublisherSunscriber
{
    public class Consumer : IConsumer
    {
        string regex;
        string name;
        IPubSub ps;
        List<Message> messageList = new List<Message>();
        List<IConsumer> dependencyList = new List<IConsumer>();

        public Consumer(IPubSub pubSub, string regex, string name)
        {
            this.ps = pubSub;
            this.regex = regex;
            this.name = name;
        }
        public void addConsumer()
        {
            ps.addSubscriber(regex, this);
        }
        public void addToMessageList(Message message)
        {
            if(message.getRegex().Equals(this.regex))
            {
                Console.WriteLine("Message: " + " " + message.getValue() + " added for consumer: " + this.name);
                this.messageList.Add(message);
            }
        }
        public void addDependency(IConsumer c2)
        {
            this.dependencyList.Add(c2); // c1 -> c2
        }
        public void showMessages()
        {
            for(int i = 0; i < this.messageList.Count; i++)
            {
                Console.WriteLine("Message for consumer: " + this.name + " is: " + this.messageList[i].getValue());
            }
        }

        public string getName()
        {
            return this.name;
        }
        public void getSubscribedMessages()
        {
            ps.getSubscribedMessages(this);
            //this.showMessages();
        }
    }
}
