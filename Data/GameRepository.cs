using MathsMAUI.Models;
using SQLite;

namespace MathsMAUI.Data
{
    public class GameRepository
    {
        private readonly string _dbPath;
        private readonly SQLiteConnection _dbConn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
            _dbConn = new SQLiteConnection(_dbPath);
            _dbConn.CreateTable<History>();
        }

        public List<History> GetAllHistory()
        {
            return _dbConn.Table<History>().ToList();
        }
        
        public void AddHistory(History history)
        {
            _dbConn.Insert(history);
        }

        public void DeleteHistory(int id) 
        { 
            _dbConn.Delete(id);
        }
    }
}
