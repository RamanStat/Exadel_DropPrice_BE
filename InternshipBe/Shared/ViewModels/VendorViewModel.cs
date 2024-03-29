﻿using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class VendorViewModel
    {
        public int VendorId { get; set; }

        [Required(ErrorMessageResourceName = "VendorNameIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        [MaxLength(200, ErrorMessageResourceName = "VendorNameExceededMaxLength", ErrorMessageResourceType = typeof(ValidationResource))]
        public string VendorName { get; set; }

        [Required(ErrorMessageResourceName = "VendorDescriptionIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "VendorEmailIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "VendorAddressIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "VendorPhoneIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Phone { get; set; }

        public string SocialLinks { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
