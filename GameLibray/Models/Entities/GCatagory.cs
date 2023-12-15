using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Entities
{
    [Table("Categories")]
    public class GCatagory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [DisplayName("Catagory Name"), StringLength(20)]
        public string CategoryName { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}