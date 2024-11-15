using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Book
    {
        public string Titel { get; set; } = "";
        public string Author { get; set; } = "";
        public int NbPages { get; set; }
        public string ISBN { get; set; } = "";

        public async Task SaveToFile()
        {
            await File.WriteAllTextAsync($"./book-{Titel}.json", JsonSerializer.Serialize(this,new
                JsonSerializerOptions
            { 
            PropertyNameCaseInsensitive = true,
            }
                ));
        }
    }
}
