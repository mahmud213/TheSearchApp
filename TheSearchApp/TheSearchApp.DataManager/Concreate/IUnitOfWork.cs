using System;
using System.Collections.Generic;
using System.Text;
using TheSearchApp.DataManager.Repositories;

namespace TheSearchApp.DataManager.Concreate
{
    public interface IUnitOfWork : IDisposable
    {
        SearchAppDBContext SearchAppDBContext { get; }

        ISearchHistoryRepository SearchHistoryRepo { get; }

        void Save();
        void SaveAsync();
    }
}
