using System.ComponentModel.DataAnnotations;

namespace RazorPageIntro.Model
{
    public class BookCollections
    {
        public int  ID { get; set; }
        [Required(ErrorMessage ="Please enter the title name")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="Please enter a Title Name minimum 3 characters")]
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Please enter the Author name")]
        public string AuthorName { get; set; }
        [RegularExpression(@"[1-5]+", ErrorMessage ="Rating must be between 1 to 5")]
        [Required(ErrorMessage ="Please enter book rating")]
        public string Rating { get; set; }
    }
}
