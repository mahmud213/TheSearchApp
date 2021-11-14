using System;
using System.Collections.Generic;
using System.Text;
using TheSearchApp.DataManager.Repositories;

namespace TheSearchApp.DataManager.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private SearchAppDBContext _dbContext;

        private ISearchHistoryRepository _searchHistoryRepo;

        public SearchAppDBContext SearchAppDBContext
        {
            get
            {
                return this._dbContext;
            }
        }

        public UnitOfWork(SearchAppDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ISearchHistoryRepository SearchHistoryRepo
        {
            get
            {
                if (_searchHistoryRepo == null)
                {
                    _searchHistoryRepo = new SearchHistoryRepository(_dbContext);
                }
                return _searchHistoryRepo;
            }
        }


        #region Database change

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        public async void SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

        #endregion

        private bool disposed = false;

        /// <summary>
        /// Object disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
