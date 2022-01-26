using System;

namespace SingletonPattern
{
    class SingletonEager
    {
        private static SingletonEager instance = new SingletonEager(); //when we are defining the variable, at the same time we are declaring it.
        private SingletonEager()
        {

        }
        public static SingletonEager getInstance()
        {
            return instance;
        }

    }
    class SingletonLazy
    {
        private static SingletonLazy instance;
        private SingletonLazy()
        {

        }
        public static SingletonLazy getInstance()
        {
            if(instance==null) //not thread safe
            {
                instance = new SingletonLazy();
            }
            return instance;
        }
 
    }
    class SingletonSynchronized //performance comprimised 
    {
        static readonly object Lock = new object ();
        private static SingletonSynchronized instance;
        private SingletonSynchronized()
        {

        }
        public static SingletonSynchronized getInstance()
        {
            lock(Lock) //only one thread can access at a time
            {
                if (instance == null)
                {
                    instance = new SingletonSynchronized();
                }
                return instance;
            }
        }

    }
    public class SingletonPattern
    {
        public static void Main(string[] args)
        {
            SingletonEager instance = SingletonEager.getInstance();
            Console.WriteLine(instance);
            SingletonLazy instanceLazy = SingletonLazy.getInstance();
            Console.WriteLine(instanceLazy);

        }
    }
}
