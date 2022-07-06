using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Contracts
{
    public class Book : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public List<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();

        [NotMapped]
        public List<Author> Authors => BookAuthor?.Select(x => x.Author).ToList();
    }
}
