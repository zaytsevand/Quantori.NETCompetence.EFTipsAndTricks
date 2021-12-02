using Microsoft.Extensions.Logging;
using Quantori.NETCompetence.EFTipsAndTricks.Examples.DTOs;
using Quantori.NETCompetence.EFTipsAndTricks.Models;

namespace Quantori.NETCompetence.EFTipsAndTricks.Examples;

internal class DynamicallyTypedDataInEntities
{
    private readonly ILogger<DynamicallyTypedDataInEntities> _logger;
    private readonly AppContext _context;

    public DynamicallyTypedDataInEntities(ILogger<DynamicallyTypedDataInEntities> logger, AppContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task CreateUsersAsync()
    {
        _context.Users.AddRange(new User
            {
                Name = Faker.Name.First(),
                StructuredAddress = new Address
                {
                    FullAddress = string.Join(", ",
                        "USA",
                        Faker.Address.UsState(),
                        Faker.Address.City(),
                        Faker.Address.StreetAddress(true),
                        Faker.Address.ZipCode()
                    )
                }
            },
            new User
            {
                Name = Faker.Name.First(),
                StructuredAddress = new DetailedAddress
                {
                    Country = "USA",
                    State = Faker.Address.UsState(),
                    City = Faker.Address.City(),
                    Street = Faker.Address.StreetAddress(true),
                    Zip = Faker.Address.ZipCode()
                }
            });

        await _context.SaveChangesAsync();
    }
    public async Task ReadUsersAsync()
    {
        var asyncEnumerable = _context.Users.AsAsyncEnumerable();

        await foreach (var user in asyncEnumerable)
        {
            switch (user.StructuredAddress)
            {
                case DetailedAddress detailedAddress:
                    _logger.LogInformation("User: {0}. Detailed address: {1}", user.Name, detailedAddress);
                    break;
                case Address address:
                    _logger.LogInformation("User: {0}. Simple address: {1}", user.Name, address);
                    break;
            }
        }
    }
}