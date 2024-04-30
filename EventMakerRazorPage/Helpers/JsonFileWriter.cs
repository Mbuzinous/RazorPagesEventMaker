using System.Text.Json;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(List<Event> @events, string JsonFileName)
        {
            using (FileStream outputStream = File.OpenWrite(JsonFileName))
            {
                var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(writer, @events.ToArray());
            }
        }
    }
}
