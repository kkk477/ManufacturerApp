using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturer.Models.Tests
{
    [TestClass]
    public class ManufacturerRepositoryTest
    {
        public async Task ManufacturersRepositoryMethodAllTest()
        {
            var options = new DbContextOptionsBuilder<ManufacturerDbContext>().UseInMemoryDatabase(databaseName: "ManufacturerApp").Options;

            // Add() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var manufacturer = new Manufacturer() { Name = "SAMSUNG", ManufacturerCode = "SM", Comment = "삼성" };
                await repository.AddManufacturerAsync(manufacturer);
                await context.SaveChangesAsync();
            }

            using (var context = new ManufacturerDbContext(options))
            {
                Assert.AreEqual(1, await context.manufacturers.CountAsync());
                var manufacturer = await context.manufacturers.Where(m=> m.Id == 1).SingleOrDefaultAsync();
                Assert.AreEqual("SM", manufacturer.ManufacturerCode);
            }

            // GetManufacturersAsync() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var manufacturer = new Manufacturer() { Name = "LG", ManufacturerCode = "LG", Comment = "LG" };
                await repository.AddManufacturerAsync(manufacturer);
                await context.SaveChangesAsync();
            }

            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var manufacturers =await repository.GetManufacturersAsync();
                Assert.AreEqual(2,  manufacturers.Count());
            }

            // GetByIdAsync() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var manufacturer = new Manufacturer() { Name = "SK", ManufacturerCode = "SK", Comment = "SK" };
                await repository.AddManufacturerAsync(manufacturer);
                await context.SaveChangesAsync();
            }

            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var sk = await repository.GetManufacturerAsync(3);
                Assert.AreEqual("SK", sk.Comment);
            }

            // EditAsync() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var manufacturer = new Manufacturer() { Name = "MS", ManufacturerCode = "MS", Comment = "MS" };
                await repository.AddManufacturerAsync(manufacturer);
                await context.SaveChangesAsync();
            }

            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                var microsoft = await repository.GetManufacturerAsync(4);
                microsoft.Name = "마이크로소프트";
                await repository.EditManufacturerAsync(microsoft);
                await context.SaveChangesAsync();

                var microsoftNew = await repository.GetManufacturerAsync(4);
                Assert.AreEqual("마이크로소프트", microsoftNew.Name);
            }

            // DeleteAsync() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                // Empty
            }

            using (var context = new ManufacturerDbContext(options))
            {
                var repository = new ManufacturerRepository(context);
                await repository.DeleteManufacturerAsync(1);
                await repository.DeleteManufacturerAsync(2);
                await repository.DeleteManufacturerAsync(3);

                Assert.AreEqual("1", await context.manufacturers.CountAsync());
            }

            // GetAllByPageAsync() Method Test
            using (var context = new ManufacturerDbContext(options))
            {
                // Empty
            }

            using (var context = new ManufacturerDbContext(options))
            {
                int pageIndex = 0;
                int pageSize = 2;

                var repository = new ManufacturerRepository(context);
                var manufacturers = await repository.GetAllByPageAsync(pageIndex, pageSize);

                Assert.AreEqual(1, manufacturers.TotalRecords);
                Assert.AreEqual(1, manufacturers.Records.ToList().Count());
            }
        }
    }
}
