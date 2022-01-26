namespace ShoppingSite_BackEnd.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Poll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductImage { get; set; }

        public DateTime CreateTime { get; set; }

        public int Votes { get; set; }

        public virtual Category Category { get; set; }
    }
}
