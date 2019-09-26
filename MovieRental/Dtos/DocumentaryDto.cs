using System;
using System.ComponentModel.DataAnnotations;


namespace MovieRental.Dtos
{
    public class DocumentaryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 10)]
        [Required]
        public int NumberInStock { get; set; }

        public DocumentaryGenreDto DocumentaryGenre { get; set; }

        [Required]
        public int DocumentaryGenreId { get; set; }
    }
}