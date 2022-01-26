using Dapper;
using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class PollRepository : IPollRepository
	{
		private readonly string _connString;
		private readonly AppDbContext _db;

		public PollRepository(string connString, AppDbContext db)
		{
			_connString = connString;
			_db = db;
		}

		public IEnumerable<PollEntity> Search()
		{
			IEnumerable<Poll> query = _db.Polls;
			return query.Select(x => x.ToPollEntity());
		}

		public void UpdateVote(int productId, int qty)
		{
			string sql = $"UPDATE Polls SET Votes = @Votes WHERE Id = @Id";
			var entity = new { Votes = qty , Id = productId };

			using (var conn = new SqlConnection(_connString))
			{
				conn.Execute(sql, entity);
			}
		}
	}
}