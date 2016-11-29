using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MVCLibrary.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }

}
