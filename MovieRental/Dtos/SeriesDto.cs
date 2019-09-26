using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Dtos
{
    public class SeriesDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Season { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(0, 10)]
        [Required]
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}