using Presentation.UI.WebUI.Enums;

namespace WebUI.Helper;

public static class WebHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static bool IsHomePage(string route)
    {
        string path = route.ToString().ToLower().Split("/").Last();

        string[] pathArray = new string[] { "en", "ru", "fr", "it", "es", "de", "nl", "sv", "da", "" };
        if (pathArray.Any(x => x.Equals(path)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string GetSegmentFromUrl(string url)
    {
        Uri uri = new Uri(url);
        if (uri.Segments.Length >= 2)
        {
            string segment = uri.Segments[1];
            segment = segment.Trim('/');
            return segment;
        }
        return "tr";
    }

    public static CurrencyEnum GetCurrencyByRegion(string region)
    {
        switch (region)
        {
            case "TR":
                return CurrencyEnum.TRY;
            case "RU":
                return CurrencyEnum.USD;
            case "FR":
            case "NL":
            case "ES":
            case "DE":
            case "IT":
                return CurrencyEnum.EUR;
            case "SV":
                return CurrencyEnum.SEK;
            case "EN":
                return CurrencyEnum.GBP;
            case "DA":
                return CurrencyEnum.DKK;
            default:
                throw new Exception($"Unknow Region: {region}");
        }
    }

    public static string GetLastSegment(string url)
    {
        if (string.IsNullOrEmpty(url))
            return string.Empty;

        // URL'i '/' karakterine göre ayırır ve boş olmayan segmentleri alır.
        var segments = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

        // Son segmenti döndürür.
        return segments.Length > 0 ? segments[^1] : string.Empty;
    }

}
