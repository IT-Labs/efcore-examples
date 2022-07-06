using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Contracts
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [JsonIgnore]
        public List<BookAuthor> BookAuthor { get; set; }

        [NotMapped]
        public List<Book> Books => BookAuthor?.Select(x => x.Book).ToList();
    }
}
