//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int ID { get; set; }

        [Display(Name="First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string Lastname { get; set; }

        [Display(Name = "Street")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Display(Name = "Housenumber")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Housenumber required")]
        public string Housenumber { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City required")]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal code required")]
        public string Zipcode { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number required")]
        public string PhoneNumber { get; set; }

        [Display(Name ="E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username required")]
        [StringLengthAttribute(32,ErrorMessage ="Username must be between 3 and 32 characters long",MinimumLength =3)]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLengthAttribute(40, ErrorMessage = "Password must be between 8 and 40 characters long", MinimumLength = 8)]
        public string PasswordHash { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLengthAttribute(40, ErrorMessage = "Password must be between 8 and 40 characters long", MinimumLength = 8)]
        [Compare("PasswordHash",ErrorMessage ="Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}