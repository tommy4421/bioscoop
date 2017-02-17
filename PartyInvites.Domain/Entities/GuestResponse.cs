using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Domain.Entities {
    public class GuestResponse {
        [Key]
        public int GuestResponsesID { get; set; }

        [Required(ErrorMessage = "Vul je naam in.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul je email in.")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Het email adres voldoet niet aan de eisen.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul je telefoonnummer in.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vul in of je komt of niet.")]
        public bool? WillAttend { get; set; }
    }
}