using ChuKySo.BL.Model.Entity;

namespace ChuKySo.BL.Repository
{
    public class BaseRepository
    {
        private ChuKySoEntities _dbEntities;

        protected ChuKySoEntities dbEntities
        {
            get { return _dbEntities ?? (_dbEntities = new ChuKySoEntities()); }
        }

        public BaseRepository()
        {
        }

        public BaseRepository(ChuKySoEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public ChuKySoEntities GetDBEntities()
        {
            return dbEntities;
        }
    }
}