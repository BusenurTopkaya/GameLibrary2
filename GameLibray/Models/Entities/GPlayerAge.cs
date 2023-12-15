using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Entities
{
    [Table("PlayerAges")]
    public class GPlayerAge
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerAgeId { get; set; }

        [StringLength(3)]
        public string PlayerAge { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}