namespace ShoppingSite_BackEnd.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int Total { get; set; }

        public DateTime CreatedTime { get; set; }

        public int Status { get; set; }

        public bool RequestRefund { get; set; }

        public DateTime? RequestRefundTime { get; set; }

        [Required]
        [StringLength(30)]
        public string Receiver { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string CellPhone { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
