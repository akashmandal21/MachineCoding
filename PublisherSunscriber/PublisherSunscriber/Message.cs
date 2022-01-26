using System.Collections.Generic;

namespace PublisherSunscriber
{
    public class Message
    {
        string regex;
        string value;
        List<IConsumer> consumerList = new List<IConsumer>(); //[c2]
        public Message(string regex, string value)
        {
            this.regex = regex;
            this.value = value;
        }
        public string getRegex()
        {
            return regex;
        }
        public string getValue()
        {
            return value;
        }
    }
}