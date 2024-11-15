using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class BookRepository
    {

        /*
        il ne faut pas utiliser this dans la méthode
        Serialize, car cela sérialiserait la classe BookRepository 
        au lieu des données du livre. Cela résulterait en un JSON vide.
         */
        public async Task SaveToFile(Book book)
        {
            await File.WriteAllTextAsync($"./book-{book.Titel}.json", JsonSerializer.Serialize(book, new
                JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }
                ));
        }
    }
}
