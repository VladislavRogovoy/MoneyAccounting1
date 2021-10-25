using DataAccess.Models;
using DataAccess.Temp.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Managers
{
    public class THistoryManager
    {
        private IRepository<TransactionsHistory> _tHistory;
        public THistoryManager(IRepository<TransactionsHistory> tHistory)
        {
            _tHistory = tHistory;
        }

    }
}
