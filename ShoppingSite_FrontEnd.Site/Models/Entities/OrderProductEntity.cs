using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class OrderProductEntity
	{
		public OrderProductEntity(int id, string name, int price)
		{
			Id = id;
			Name = name;
			Price = price;
		}

		public int Id { get; set; }


		//public string Name { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name;
			set => _Name = string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(value));
		}

		private int _Price;

		public int Price
		{
			get => _Price;
			set => _Price = value >= 0 ? value : throw new Exception("售價不能小零");
		}
	}
}