using Core.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Admin.ViewModels
{
    public class ProductGroupEditViewModel
    {
        [Display(Name = "Title", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringMaxLengthError")]
        public string Title { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(DisplayNameResource))]
        public bool IsActive { get; set; }

        [Display(Name = "Parent", ResourceType = typeof(DisplayNameResource))]
        public int? ParentId { get; set; }

        [Display(Name = "Icon", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        public byte[] Icon { get; set; }

        [Display(Name = "ProductGroupType", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        public int ProductGroupTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        public IEnumerable<int> Provinces { get; set; }
    }
}