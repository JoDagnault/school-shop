namespace SchoolShop.Tests.TestInfrastructure;

[CollectionDefinition("DatabaseBackedTests")]
public sealed class DatabaseBackedTestCollection : ICollectionFixture<DatabaseBackedTestFixture>;
