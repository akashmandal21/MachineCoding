using System;
namespace PublisherSunscriber
{

    public class MessageQueue
    {
        Node front, back;
        int size;
        int maxSize;
        public MessageQueue(int queueSize)
        {
            this.maxSize = queueSize;
        }
        internal void addMessage(Message message)
        {
            if(this.size <= this.maxSize)
            {
                Node n = new Node(message);
                if(front == null)
                {
                    front = n;
                }
                else
                {
                    back.next = n;
                }
                this.size++;
                back = n;
            }
        }

        public bool IsEmpty()
        {
            return (this.size == 0);
        }
        public Message GetFront()
        {
            return (IsEmpty()) ? null : this.front.message;
        }
        public void RemoveMessage()
        {
            if (IsEmpty())
            {
                return;
            }
            Node temp = this.front;
            if (front == back)
            {
                front = null;
                back = null;
            }
            else
            {
                front = front.next;
            }
            this.size--;
        }
    }
}
