using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Nom requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prénom requis")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Sélectionner un genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Adresse requise")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Code postal requis")]
        [RegularExpression(@"\d{5}", ErrorMessage = "Le code postal doit comporter 5 chiffres.")]
        public int? CodePostal { get; set; }

        [Required(ErrorMessage = "Nom de la ville requise")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Adresse mail requise")]
        [EmailAddress(ErrorMessage = "L'adresse mail doit respecter le format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date de début de formation requise")]
        [DataType(DataType.Date, ErrorMessage = "Format de date incorrect.")]
        [Range(typeof(DateTime), "1/1/1990", "1/1/2021", ErrorMessage = "Date doit être antérieure au 01/01/2021")]
        public DateTime? DateDebut { get; set; }

        [Required(ErrorMessage = "Selectionner le type de formation")]
        public string TypeFormation { get; set; }

        public string? AvisCobol { get; set; }
        public string? AvisCsharp { get; set; }

    }
}
