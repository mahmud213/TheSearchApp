using System;
using System.Collections.Generic;
using TheSearchApp.DataManager.Models;

namespace TheSearchApp.DataManager.Repositories
{
    public interface ISearchHistoryRepository : ICommonRepository<SearchHistory>
    {
        List<SearchHistory> GetSearchHistoryByUserId(string userId);
        SearchHistory GetSearchHistoryByCriteria(string searchCriteria, string category);
        SearchHistory GetById(Int64 id);
    }
}
