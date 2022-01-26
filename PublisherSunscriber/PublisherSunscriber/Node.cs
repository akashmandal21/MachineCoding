using System;
namespace PublisherSunscriber
{
    public class Node
    {
        public Message message;
        public Node next;
        public Node(Message message)
        {
            this.message = message;
            this.next = null;
        }
    }
}
