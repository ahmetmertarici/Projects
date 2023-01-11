using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class EditWriterInformationModel
    {

        public int WriterId { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]

        public string WriterName { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]

        public string WriterSurname { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]

        public string Mail { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]

        public string Nickname { get; set; }
        public string? Thumbnail { get; set; }
    }
}
