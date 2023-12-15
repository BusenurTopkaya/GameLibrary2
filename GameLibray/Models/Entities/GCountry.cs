using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Entities
{
    [Table("GameCountries")]
    public class GCountry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [DisplayName("Country Name"), StringLength(20)]
        public string CountryName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}