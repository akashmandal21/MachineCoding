using System;
using System.Collections.Generic;

namespace PublisherSunscriber
{
    public class PubSub : IPubSub
    {
        List<Consumer> consumerList = new List<Consumer>();
        Dictionary<string, List<Consumer>> subscriberMap = new Dictionary<string, List<Consumer>>();
        Dictionary<Consumer, MessageQueue> messageQueueMap = new Dictionary<Consumer, MessageQueue>();
        int queueSize;

        public PubSub(int queueSize)
        {
            this.queueSize = queueSize;
        }
        public void addSubscriber(string regex,Consumer consumer)
        {
            Console.WriteLine("Consumer added: " + consumer.getName());
            List<Consumer> tempConsumerList = new List<Consumer>();
            if (!subscriberMap.ContainsKey(regex))
            {
                tempConsumerList.Add(consumer);
                subscriberMap.Add(regex, tempConsumerList);
            }
            else
            {
                tempConsumerList = subscriberMap[regex];
                tempConsumerList.Add(consumer);
                subscriberMap[regex] = tempConsumerList;
            }
            
        }
        public void addToQueue(Message message)
        {
            string regex = message.getRegex();
            MessageQueue mq = new MessageQueue(this.queueSize); //This could have been skipped
            List<Consumer> tempConsumerList = new List<Consumer>();
            if (subscriberMap.ContainsKey(regex))
            {
                tempConsumerList = subscriberMap[regex];
                for(int i = 0; i < tempConsumerList.Count; i++)
                {
                    tempConsumerList[i].addToMessageList(message);
                    // if consumerList from message does not consist of any value from list of dependencyList then only add this message
                    // esle case // c1->c2, c2->c3
                    // Dictionary<Consumer, List<Consumer>> dependcyList;
                     if (messageQueueMap.ContainsKey(tempConsumerList[i]))
                    {
                        mq = messageQueueMap[tempConsumerList[i]];
                        mq.addMessage(message);
                        messageQueueMap[tempConsumerList[i]] = mq;
                        
                    }
                    else
                    {
                        mq.addMessage(message);
                        messageQueueMap.Add(tempConsumerList[i], mq);
                    }
                }
            }
        }
        public void getQueuedMessages(Consumer consumer)
        {
            if (messageQueueMap.ContainsKey(consumer))
            {
               
                MessageQueue messageQueue = messageQueueMap[consumer];
                while (!messageQueue.IsEmpty())
                {
                    Message message = messageQueue.GetFront();
                    Console.WriteLine("Message received for consumer" + consumer.getName() + ": " + message.getValue());
                    consumer.addToMessageList(message);
                    messageQueue.RemoveMessage();
                }
            }
        }
        public void getSubscribedMessages(Consumer consumer)
        {
            getQueuedMessages(consumer);
        }
    }
}
