namespace ShoppingSite_FrontEnd.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Faq
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Question { get; set; }

        [Required]
        [StringLength(100)]
        public string Answer { get; set; }
    }
}
