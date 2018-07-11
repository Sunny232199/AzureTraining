using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageTablesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("customers");
            table.CreateIfNotExists();
            Console.WriteLine("Table customers is ready!");

            ////Insert
            //CustomerEntity customer1 = new CustomerEntity("AP", "A01");
            //customer1.FirstName = "James";
            //customer1.LastName= "Mark";
            //customer1.Email = "james@adatum.com";
            //customer1.PhoneNumber = "9820001010";

            //TableOperation insertOperation = TableOperation.Insert(customer1);
            //table.Execute(insertOperation);
            //Console.WriteLine("Row added!");

            ////Bulk insert
            //TableBatchOperation batchOperation = new TableBatchOperation();

            //CustomerEntity customer1 = new CustomerEntity("MH", "A02");
            //customer1.FirstName = "Sarah";
            //customer1.LastName = "Lee";
            //customer1.Email = "sarah@adatum.com";
            //customer1.PhoneNumber = "9820001011";

            //CustomerEntity customer2 = new CustomerEntity("MH", "A03");
            //customer2.FirstName = "Simon";
            //customer2.LastName = "Jack";
            //customer2.Email = "simon@adatum.com";
            //customer2.PhoneNumber = "9820001012";

            //CustomerEntity customer3 = new CustomerEntity("MH", "A04");
            //customer3.FirstName = "Sim";
            //customer3.LastName = "Yu";
            //customer3.Email = "sim@adatum.com";
            //customer3.PhoneNumber = "9820001013";

            //CustomerEntity customer4 = new CustomerEntity("MH", "A05");
            //customer4.FirstName = "Dan";
            //customer4.LastName = "Jones";
            //customer4.Email = "dan@adatum.com";
            //customer4.PhoneNumber = "9820001014";

            //batchOperation.Insert(customer1);
            //batchOperation.Insert(customer2);
            //batchOperation.Insert(customer3);
            //batchOperation.Insert(customer4);

            //table.ExecuteBatch(batchOperation);
            //Console.WriteLine("Batch of rows added!");

            TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "MH"));

            foreach(CustomerEntity entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", entity.PartitionKey, entity.RowKey, entity.FirstName, entity.LastName, entity.Email, entity.PhoneNumber);
            }
        }
    }

    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string state, string customerID)
        {
            this.PartitionKey = state;
            this.RowKey = customerID;
        }
        public CustomerEntity()
        {

        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber{ get; set; }

    }


}
