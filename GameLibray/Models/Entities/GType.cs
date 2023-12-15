using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Entities
{
    [Table("Types")]
    public class GType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [DisplayName("Type Name"), StringLength(20)]
        public string TypeName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}