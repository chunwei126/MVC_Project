using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSite_BackEnd.Site.Models.ViewModels
{
	public class ProductIndexVM
	{
    [Display(Name = "編號")]
    [Required]
    public int Id { get; set; }

    [Display(Name = "類別")]
    [Required]
    public int CategoryId { get; set; }

    [Display(Name = "品名")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Display(Name = "商品描述")]
    public string Description { get; set; }

    [Display(Name = "價格")]
    [Required]
    public int Price { get; set; }


    [Display(Name = "上架")]
    [Required]
    public bool Status { get; set; }

    [Display(Name = "檔案")]
    [Required]
    [StringLength(40)]
    public string ProductImage { get; set; }
    [Display(Name = "庫存")]
    [Required]
    public int Stock { get; set; }

    [Display(Name = "描述")]
    public string BriefDescription
    {
      get
      {
        if (string.IsNullOrEmpty(this.Description))
        {
          return string.Empty;
        }
        int maxLength = 10;
        return this.Description.Length > maxLength
            ? this.Description.Substring(0, maxLength) + "..."
            : this.Description;
      }
    }
  }
}