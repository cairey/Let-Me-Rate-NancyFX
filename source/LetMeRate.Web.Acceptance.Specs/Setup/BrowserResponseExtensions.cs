using System.IO;
using Nancy.Testing;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    public static class BrowserResponseExtensions
    {
        public static string GetBodyAsString(this BrowserResponse response)
        {
            using (var contentsStream = new MemoryStream())
            {
                response.Context.Response.Contents.Invoke(contentsStream);
                contentsStream.Position = 0;
                using (var streamReader = new StreamReader(contentsStream))
                    return streamReader.ReadToEnd();
            }
        }
    } 
}
