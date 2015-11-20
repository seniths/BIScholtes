using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using LaboBILibrary;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertionFonctionnelle()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());

            CompanyContext context = new CompanyContext();
            Customer customer = new Customer()
            {
                AdresseLine1 = "Rue Mionvaux, 48",
                AccountBalance = 5000.5,
                City = "Marloie",
                Country = "Belgium",
                EMail = "maxime_renard@hotmail.com",
                Name = "Renard",
                PostCode = "6900",
                Remark = "test"
            };

            context.Customers.Add(customer);
            context.SaveChanges();
            DBIsNotEmpty();
        }

        public void DBIsNotEmpty()
        {
            CompanyContext context = new CompanyContext();
            Assert.IsTrue(context.Customers.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DoubleConnexion()
        {
            CompanyContext context1 = new CompanyContext();
            Customer customer1 = context1.Customers.First();

            CompanyContext context2 = new CompanyContext();
            Customer customer2 = context2.Customers.First();

            customer1.AccountBalance += 1000;
            context1.SaveChanges();

            customer2.AccountBalance += 500;
            context2.SaveChanges();
        }
    }
}
