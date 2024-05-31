﻿using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Core.Entity
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
