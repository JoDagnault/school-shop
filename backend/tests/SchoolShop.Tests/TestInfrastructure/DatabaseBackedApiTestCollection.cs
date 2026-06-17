namespace SchoolShop.Tests.TestInfrastructure;

[CollectionDefinition("DatabaseBackedApiTests")]
public sealed class DatabaseBackedApiTestCollection : ICollectionFixture<DatabaseBackedApiTestFixture>;
