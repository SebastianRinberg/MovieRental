using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Documentary
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 10)]
        [Required]
        public int NumberInStock { get; set; }

        public DocumentaryGenre DocumentaryGenre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int DocumentaryGenreId { get; set; }

    }
}