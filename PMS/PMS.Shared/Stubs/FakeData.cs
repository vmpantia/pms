using Bogus;
using PMS.Shared.Models.Entities;
using PMS.Shared.Models.Enums;

namespace PMS.Shared.Stubs
{
    public static class FakeData
    {
        public static Faker<WorkItem> WorkItem() =>
            new Faker<WorkItem>()
                .RuleFor(prop => prop.Id, fk => fk.Random.Guid())
                .RuleFor(prop => prop.Title, fk => fk.Commerce.ProductName())
                .RuleFor(prop => prop.Description, fk => fk.Commerce.ProductDescription())
                .RuleFor(prop => prop.OwnerId, fk => fk.Random.Guid())
                .RuleFor(prop => prop.Type, fk => fk.PickRandom<WorkItemType>())
                .RuleFor(prop => prop.Status, fk => fk.PickRandom<WorkItemStatus>())
                .RuleFor(prop => prop.StartDate, fk => fk.Date.Past().Date)
                .RuleFor(prop => prop.EndDate, fk => fk.Date.Future().Date)
                .RuleFor(prop => prop.CreatedAt, fk => fk.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, fk => fk.Internet.Email());
    }
}
