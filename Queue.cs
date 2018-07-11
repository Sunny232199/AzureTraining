using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AdatumStorageQueuesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("orders");
            queue.CreateIfNotExists();

            Console.WriteLine("Queue orders is ready!");

            //CloudQueueMessage message1 = new CloudQueueMessage("Message 1");
            //queue.AddMessage(message1);
            //Console.WriteLine("Message written!");

            //CloudQueueMessage message2 = new CloudQueueMessage("Message 2");
            //queue.AddMessage(message2);
            //Console.WriteLine("Message written!");

            //CloudQueueMessage message3 = new CloudQueueMessage("Message 3");
            //queue.AddMessage(message3);
            //Console.WriteLine("Message written!");

            //CloudQueueMessage message4 = new CloudQueueMessage("Message 4");
            //queue.AddMessage(message4);
            //Console.WriteLine("Message written!");

            //CloudQueueMessage message5 = new CloudQueueMessage("Message 5");
            //queue.AddMessage(message5);
            //Console.WriteLine("Message written!");

            //CloudQueueMessage peekMessage = queue.PeekMessage();
            //Console.WriteLine(peekMessage.AsString);


            CloudQueueMessage message = queue.GetMessage();
            Console.WriteLine(message.AsString);
            //Processing code to be written here
            queue.DeleteMessage(message);
            Console.WriteLine("Message Deleted!");

        }
    }
}
