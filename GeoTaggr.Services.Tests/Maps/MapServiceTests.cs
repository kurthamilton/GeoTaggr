using GeoTaggr.Core.Maps;
using GeoTaggr.Services.Maps;

namespace GeoTaggr.Services.Tests.Maps;

public static class MapServiceTests
{
    [TestCase(12.345, "https://www.google.com/maps/@12.345,12.345,3a,75y,90t/data=!3m6!1e1!3m4!1sMdUB9CBeFLjfxZp5ixZQ9w!2e0!7i13312!8i6656?entry=ttu")]
    [TestCase(12.345, "https://www.google.com/maps?q&layer=c&cbll=12.345,12.345")]
    [TestCase(-12.345, "https://www.google.com/maps/@-12.345,-12.345,3a,75y,90t/data=!3m6!1e1!3m4!1sMdUB9CBeFLjfxZp5ixZQ9w!2e0!7i13312!8i6656?entry=ttu")]
    [TestCase(-12.345, "https://www.google.com/maps?q&layer=c&cbll=-12.345,-12.345")]
    public static void TryParseLocation_ParsesDifferentUrlFormats(double expectedLatLong, string url)
    {
        MapService service = CreateService();
        bool result = service.TryParseLocation(url, out Coordinates? location);
        
        Assert.IsTrue(result);

        if (result)
        {
            Assert.That(location.Lat, Is.EqualTo(expectedLatLong));
            Assert.That(location.Long, Is.EqualTo(expectedLatLong));
        }        
    }

    private static MapService CreateService()
    {
        return new MapService(new MapServiceSettings(""));
    }
}
