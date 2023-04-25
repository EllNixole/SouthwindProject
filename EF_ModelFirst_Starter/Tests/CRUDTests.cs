using NUnit.Framework;
using System.Linq;
using EF_ModelFirst;

namespace Tests
{
    public class DataActionTests
    {
        private Customer testCustomer1;

        [SetUp]
        public void SetUp()
        {
            using (var db = new SouthwindContext())
            {
                testCustomer1 = new Customer() { CustomerId = "TestId1", ContactName = "Test1", City = "TestCity1", Country = "TestCountry1", PostalCode = "TestPostalCode1" };
                db.Customers.Add(testCustomer1);
                db.SaveChanges();
            }
        }

        [Test]
        public void TestAdd()
        {
            using (var db = new SouthwindContext())
            {
                var add = new Add();
                add.ExecuteQuery("TestId2", "Test2", "TestCity2", "TestCountry2", "TestPostalCode2");

                var customer = db.Customers.FirstOrDefault(c => c.ContactName == "Test2");

                Assert.IsNotNull(customer);
                Assert.AreEqual("TestId2", customer.CustomerId);
                Assert.AreEqual("Test2", customer.ContactName);
                Assert.AreEqual("TestCity2", customer.City);
                Assert.AreEqual("TestCountry2", customer.Country);
                Assert.AreEqual("TestPostalCode2", customer.PostalCode);
            }
        }

        [Test]
        public void TestReadAll()
        {
            using (var db = new SouthwindContext())
            {
                var read = new Read();
                read.ExecuteQuery(-1);

                Assert.IsTrue(db.Customers.Count() >= 1);
            }
        }

        [Test]
        public void TestRead()
        {
            using (var db = new SouthwindContext())
            {
                var read = new Read();
                read.ExecuteQuery(testCustomer1.CustomerId);

                var customer = db.Customers.Find(testCustomer1.CustomerId);

                Assert.AreEqual("TestId1", customer.CustomerId);
                Assert.AreEqual("Test1", customer.ContactName);
                Assert.AreEqual("TestCity1", customer.City);
                Assert.AreEqual("TestCountry1", customer.Country);
                Assert.AreEqual("TestPostalCode1", customer.PostalCode);
            }
        }

        [Test]
        public void TestUpdate()
        {
            using (var db = new SouthwindContext())
            {
                var update = new Update();
                update.ExecuteQuery(testCustomer1.CustomerId, "ContactName", "NewName");

                var customer = db.Customers.Find(testCustomer1.CustomerId);

                Assert.IsNotNull(customer);
                Assert.AreEqual("NewName", customer.ContactName);
            }
        }

        [Test]
        public void TestDelete()
        {
            using (var db = new SouthwindContext())
            {
                // Delete the test customer
                var delete = new Delete();
                delete.ExecuteQuery(testCustomer1.CustomerID);
                //db.Customers.Remove(customerToDelete);
                //db.SaveChanges();
                var deletedCustomer = db.Customers.Find(testCustomer1.CustomerId);
                Assert.IsNull(deletedCustomer);
            }
        }
    }
}
