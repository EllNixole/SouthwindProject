using NUnit.Framework;
using System.Linq;
using EF_ModelFirst;

namespace Tests
{
    public class CRUDTests
    {
        public class CRUDAppTests 
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
                    var delete = new Delete();
                    delete.ExecuteQuery(testCustomer1.CustomerID);
                    //db.Customers.Remove(customerToDelete);
                    //db.SaveChanges();
                    var deletedCustomer = db.Customers.Find(testCustomer1.CustomerId);
                    Assert.IsNull(deletedCustomer);
                }
            }
        }

        [TestFixture]
        public class ExceptionTests 
        {
            [Test]
            public void TestAddWithNullValues()
            {
                using (var db = new SouthwindContext())
                {
                    var add = new Add();
                    Assert.That(() => add.ExecuteQuery(null, null, null, null, null), Throws.InstanceOf<ArgumentNullException>()
                        .With.Message.Contain("Input cannot be null."));
                }
            }

            [Test]
            public void TestReadWithNonExistentCustomerId()
            {
                using (var db = new SouthwindContext())
                {
                    var read = new Read();
                    Assert.That(() => read.ExecuteQuery("NonExistentId"), Throws.InstanceOf<ArgumentNullException>()
                    .With.Message.Contain("Cannot find customer with that ID."));
                }
            }

            [Test]
            public void TestUpdateWithNonExistentCustomerId()
            {
                using (var db = new SouthwindContext())
                {
                    var update = new Update();
                    Assert.That(() => update.ExecuteQuery("NonExistentId", "ContactName", "NewName"), Throws.InstanceOf<ArgumentNullException>()
                    .With.Message.Contain("Cannot find customer with that ID."));
                }
            }

            [Test]
            public void TestDeleteWithNonExistentCustomerId()
            {
                using (var db = new SouthwindContext())
                {
                    var delete = new Delete();
                    Assert.That(() => delete.ExecuteQuery("NonExistentId"), Throws.InstanceOf<ArgumentNullException>()
                    .With.Message.Contain("Cannot find customer with that ID."));
                }
            }
        }
    }
}
