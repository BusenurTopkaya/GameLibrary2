using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Entities
{
    [Table("Games")]
    public class Game
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [DisplayName("Game Name"),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]      
        public string GameName { get; set; }
        [DisplayName("About Game"),
         StringLength(250)]
        public string GameAbout { get; set; }
        public virtual GType types { get; set; }
        public virtual GCatagory Categories { get; set; }
        public virtual GCountry GameCountries { get; set; }
        public virtual GPlayerAge PlayerAges { get; set; }
        public virtual GPlatform Platforms { get; set; }

        public int typeId { get; set; }
        public int categoryId { get; set; }
      
       public int CountryId { get; set; }
       public int playerageId { get; set; }
       public int platformId { get; set; }
    }
}