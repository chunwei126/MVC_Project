using ShoppingSite_BackEnd.Site.Models.EFModels;
using ShoppingSite_BackEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_BackEnd.Site.Models.Core.Interfaces
{
	public interface IProductRepository
	{
		void Create(ProductEntity entity);
		void Update(ProductEntity entity);
		void Delete(int docId);
		IEnumerable<ProductEntity> Search(string title, string description);
		ProductEntity Load(int docId);
	}
}
