using Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace Api.Admin.ViewModels
{
    public class ProductGroupTypeEditViewModel
    {
        [Display(Name = "Title", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringMaxLengthError")]
        public string Title { get; set; }

        [Display(Name = "Icon", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        public byte[] Icon { get; set; }

        public bool IsActive { get; set; }
    }
}