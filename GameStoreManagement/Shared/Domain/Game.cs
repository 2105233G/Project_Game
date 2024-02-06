using GameStoreManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreManagement.Shared.Domain
{
    public class Game : BaseDomainModel

    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        public string? Platform { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

    }
}
