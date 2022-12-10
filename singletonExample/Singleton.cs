using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonExample
{
    // Lazy loading using thread safety
    internal class Singleton
    {
        private static string ID;
        private static string Name;
        private static Singleton Instance = null;
        private static Object Synchronize=new Object();


        private Singleton()
        {
            ID = "1";
            Name = "defaultInstance";
        }
        public void showMessage()
        {
            Console.WriteLine(" instance created with name :{0} and ID :{1}", ID, Name);
        }

        public static Singleton GetInstance
        {
            get
            {

                lock (Synchronize)    //lock make the creation of Singleton instance thread safe, the method getInstance()
                                      //is synchronized so that the method is executed by only one thread at a time
                {
                    if (Instance == null)
                        Instance = new Singleton();
                }
            return Instance;
                
            }
        }
    }
}
