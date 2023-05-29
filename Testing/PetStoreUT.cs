using DataAcessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Testing
{
    [TestFixture]
    public class PetStoreUT
    {
            private Customer customer;
            private Order order;

        public object OrderId { get; private set; }

        [SetUp]
            public void SetUp()
            {
                // Set up any necessary test data or configuration
                customer = new Customer("John Doe");
                order = new Order(customer);


        }

            [Test]
            public void Customer_GetCustomerName_ShouldReturnCorrectName()
            {
                // Arrange
                string expectedName = "John Doe";

                // Act
                string actualName = customer.FirstName;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedName, actualName);
            }

    
      

            [Test]
            public void Order_AddOrderItem_ShouldIncreaseItemCountAndAddOrderItem()
            {
                // Arrange
                OrderItem orderItem = new OrderItem(OrderId, 2);
                int initialItemCount = order.ItemCount;

                // Act
                order.AddOrderItem(orderItem);
                int updatedItemCount = order.ItemCount;

            // Assert
            NUnit.Framework.Assert.AreEqual(updatedItemCount, initialItemCount + 1);
            NUnit.Framework.CollectionAssert.Contains(order.OrderItems, orderItem);
            }

            [Test]
            public void Order_RemoveOrderItem_ShouldDecreaseItemCountAndRemoveOrderItem()
            {
                // Arrange
                OrderItem orderItem = new OrderItem(OrderId, 2);
                order.AddOrderItem(orderItem);
                int initialItemCount = order.ItemCount;

                // Act
                order.RemoveOrderItem(orderItem);
                int updatedItemCount = order.ItemCount;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(updatedItemCount, initialItemCount - 1);
            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.DoesNotContain(order.OrderItems, orderItem);
            }

            [TestCase("Michael Scott")]
            [TestCase("Pam Beesly")]
            [TestCase("Jim Halpert")]
            public void Customer_GetCustomerName_ShouldReturnCorrectName(string name)
            {
                // Arrange
                Customer dynamicCustomer = new Customer(name);

                // Act
                string actualName = dynamicCustomer.FirstName;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(name, actualName);
            }
        }
    }
