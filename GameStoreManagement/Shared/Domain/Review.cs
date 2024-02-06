using GameStoreManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreManagement.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        [Required]
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Rating can be a decimal number with up to two decimal places.")]
        public double rating { get; set; }

       
    }
}
