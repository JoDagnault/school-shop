using System.Net;
using System.Net.Http.Json;
using SchoolShop.Api.SupplyLists.GetSupplyListByKey;
using SchoolShop.Domain.SupplyLists.Key;
using SchoolShop.Tests.SupplyLists.Testing.Builders;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;
using SchoolShop.Tests.Testing;

namespace SchoolShop.Tests.SupplyLists.Large.Api.GetSupplyListByKey;

[Trait("Size", "Large")]
[Collection("DatabaseBackedApiTests")]
public class GetSupplyListByKeyEndpointTests : IAsyncLifetime
{
    private readonly DatabaseBackedApiTestFixture _fixture;
    private HttpClient? _client;

    public GetSupplyListByKeyEndpointTests(DatabaseBackedApiTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GivenPersistedSupplyList_WhenCallingGetSupplyListByKeyEndpoint_ShouldReturnMatchingSupplyListItems()
    {
        const string expectedItemName = "Graphite Pencil";
        const uint expectedItemQuantity = 12;
        var expectedSupplyList = new SupplyListBuilder()
            .WithKey(SupplyListKeyFixture.ASupplyListKey())
            .WithItem(expectedItemName, expectedItemQuantity)
            .Build();
        await _fixture.Database.Persist(expectedSupplyList);

        var response = await Client.GetAsync(GetSupplyListByKeyUriFor(expectedSupplyList.Key));

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<GetSupplyListByKeyResponse>();
        result.ShouldNotBeNull();
        result.Items.ShouldBe([
            new GetSupplyListByKeyItemResponse(expectedItemName, expectedItemQuantity)
        ]);
    }

    [Fact]
    public async Task GivenMissingSupplyList_WhenCallingGetSupplyListByKeyEndpoint_ShouldReturnNotFound()
    {
        var missingSupplyListKey = SupplyListKeyFixture.ASupplyListKey();

        var response = await Client.GetAsync(GetSupplyListByKeyUriFor(missingSupplyListKey));

        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    private static string GetSupplyListByKeyUriFor(SupplyListKey key)
    {
        var school = Uri.EscapeDataString(key.School.Name);
        var grade = Uri.EscapeDataString(key.Grade.Value);
        var academicYear = key.AcademicYear.StartYear;

        return $"/supply-lists?school={school}&grade={grade}&academicYear={academicYear}";
    }

    public async Task InitializeAsync()
    {
        await _fixture.ResetDatabaseAsync();
        _client = _fixture.Api.CreateClient();
    }

    public Task DisposeAsync()
    {
        _client?.Dispose();

        return Task.CompletedTask;
    }

    private HttpClient Client =>
        _client ?? throw new InvalidOperationException("The test client has not been initialized.");
}
