using Xunit;

namespace LoadTestToolbox.Tests;

public sealed class DrillTests
{
	[Fact]
	public void NumberOfResultsMatchRequests()
	{
		//arrange
		var http = new HttpClient(new MockHttpMessageHandler());
		HttpRequestMessage newMessage() => new(HttpMethod.Get, new Uri("http://localhost"));
		var drill = new Drill(http, newMessage, () => { }, 5, 0);

		//act
		var results = drill.Run();

		//assert
		Assert.Equal(5, results.Count);
	}
}