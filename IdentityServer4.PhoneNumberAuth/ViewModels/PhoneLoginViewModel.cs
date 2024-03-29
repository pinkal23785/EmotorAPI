using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IdentityServer4.PhoneNumberAuth.ViewModels
{
    public class PhoneLoginViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public byte UserType { get; set; }

    }
}