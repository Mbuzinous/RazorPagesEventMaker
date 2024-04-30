using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string JsonFileName)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Event>>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
