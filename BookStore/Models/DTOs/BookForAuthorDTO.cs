﻿namespace BookStore.Models.DTOs
{
    public class BookForAuthorDTO
    {
        public Guid BookId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}