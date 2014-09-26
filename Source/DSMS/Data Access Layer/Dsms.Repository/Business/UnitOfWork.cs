using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dsms.Entity;

namespace Dsms.Repository
{
    /// <summary>
    /// This class is for connect entity framework
    /// </summary>
    /// <history>
    /// - 2014/05/20: Created by Phat Vo
    /// </history>
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly ChuKySoEntities _db;

        public UnitOfWork()
        {
            _db = new ChuKySoEntities();

        }

        public void Dispose()
        {

        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public int Commit()
        {
            var result = _db.SaveChanges();
            _transaction.Complete();
            return result;
        }

        public DbContext Db
        {
            get { return _db; }
        }
    }
}
