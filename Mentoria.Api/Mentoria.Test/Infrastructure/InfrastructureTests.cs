namespace Mentoria.Test.Infrastructure
{
    public class InfrastructureTests
    {

        private readonly Fixture _fixture;
        private DataContext _context;

        public InfrastructureTests()
        {
            _fixture = new Fixture();

            var builder = new DbContextOptionsBuilder<DataContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new DataContext(builder.Options);
        }

        [Fact]
        public async Task ShouldReturnOneFakeCustomer()
        {
            var cust = _fixture.Create<Customer>();

            _context.Customers.Add(cust);
            _context.SaveChanges();

            var rep = new CustomerRepository(_context);
            
            var result = await rep.GetAllAsync();

            result.Should().NotBeNullOrEmpty();
            result.Count().Should().Be(1);
            result.First().Should().BeEquivalentTo(cust);
        }
    }
}