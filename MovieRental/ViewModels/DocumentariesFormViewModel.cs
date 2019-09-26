using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.ViewModels
{
    public class DocumentariesFormViewModel
    {
        public IEnumerable<DocumentaryGenre> Genres { get; set; }

        public int? Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 10)]
        [Required]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? DocumentaryGenreId { get; set; }


        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Documentary";

                return "New Documentary";
            }
        }

        public DocumentariesFormViewModel()
        {
            Id = 0;
        }

        public DocumentariesFormViewModel(Documentary documentary)
        {
            Id = documentary.Id;
            Name = documentary.Name;
            ReleaseDate = documentary.ReleaseDate;
            NumberInStock = documentary.NumberInStock;
            DocumentaryGenreId = documentary.DocumentaryGenreId;
        }
    }
}