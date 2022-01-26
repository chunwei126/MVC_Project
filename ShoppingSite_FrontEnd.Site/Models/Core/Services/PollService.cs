using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Services
{
	public class PollService
	{
		private IPollRepository _repository;

		public PollService(IPollRepository repo)
		{
			_repository = repo;
		}

		public IEnumerable<PollEntity> SearchVoteResults()
		{
			return _repository.Search();
		}

		public void UpdateVote(int productid, int qty)
		{
			_repository.UpdateVote(productid, qty);
		}
	}
}