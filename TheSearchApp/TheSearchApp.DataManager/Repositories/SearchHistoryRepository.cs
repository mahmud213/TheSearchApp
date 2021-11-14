using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheSearchApp.DataManager.Concreate;
using TheSearchApp.DataManager.Models;

namespace TheSearchApp.DataManager.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository, IDisposable
    {
        private SearchAppDBContext _dBContext;
        public SearchHistoryRepository(SearchAppDBContext dbContext)
        {
            this._dBContext = dbContext;
        }

        public void Add(SearchHistory entity)
        {
            try
            {
                this._dBContext.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(SearchHistory t)
        {
            throw new NotImplementedException();
        }

        public void Edit(SearchHistory t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchHistory> GetAll()
        {
            IEnumerable<SearchHistory> histories = new List<SearchHistory>();
            try
            {
                histories = this._dBContext.SearchHistory.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return histories;
        }

        public SearchHistory GetById(Int64 id)
        {
            return this._dBContext.SearchHistory.Find(id);
        }

        public IQueryable<SearchHistory> GetManyQueryable(Func<SearchHistory, bool> where)
        {
            throw new NotImplementedException();
        }

        public List<SearchHistory> GetSearchHistoryByUserId(string userId)
        {
            List<SearchHistory> histories = new List<SearchHistory>();
            try
            {
                histories = this._dBContext.SearchHistory.Where(w => w.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return histories;
        }

        public SearchHistory GetSearchHistoryByCriteria(string searchCriteria, string category)
        {
            SearchHistory history =
               (from H in _dBContext.SearchHistory.AsNoTracking()
                where H.SearchCategory == category && H.SearchCriteria == searchCriteria
                select new SearchHistory
                {
                    SearchId = H.SearchId,
                    UserId = H.UserId,
                    SearchCategory = H.SearchCategory,
                    SearchCriteria = H.SearchCriteria,
                    APIRequest = H.APIRequest,
                    APIResponse = H.APIResponse,
                    RequestDate = H.RequestDate
                }).FirstOrDefault();

            return history;
        }

        private bool disposed = false;

        public bool IsDisposed
        {
            get
            {
                return disposed;
            }
            set
            {
                if (value) this.disposed = true;
                else this.disposed = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //  this._dBContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposed);
            GC.SuppressFinalize(this);
        }
    }
}
