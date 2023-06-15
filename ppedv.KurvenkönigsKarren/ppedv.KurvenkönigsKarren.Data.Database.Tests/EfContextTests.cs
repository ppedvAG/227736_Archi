using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.KurvenkönigsKarren.Model.DomainModel;
using System.Reflection;

namespace ppedv.KurvenkönigsKarren.Data.Database.Tests
{
    public class EfContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";

        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            Assert.True(con.Database.EnsureCreated());
        }

        [Fact]
        public void Insert_and_read_Car()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var car = fix.Create<Car>();

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Car>(car.Id);
                loaded.Should().BeEquivalentTo(car, x => x.IgnoringCyclicReferences());
            }

        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}