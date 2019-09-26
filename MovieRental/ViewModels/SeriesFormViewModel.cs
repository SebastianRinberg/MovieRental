using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.ViewModels
{
    public class SeriesFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Season { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(0, 10)]
        [Required]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Series";

                return "New Series";
            }
        }

        public SeriesFormViewModel()
        {
            Id = 0;
        }

        public SeriesFormViewModel(Series series)
        {
            Id = series.Id;
            Name = series.Name;
            Season = series.Season;
            ReleaseDate = series.ReleaseDate;
            NumberInStock = series.NumberInStock;
            GenreId = series.GenreId;
        }
    }
}