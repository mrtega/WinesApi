using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinesApi.Models
{
    public class WineCellarDatabaseSettings : IWineCellarDatabaseSettings
    {
        public string WinesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWineCellarDatabaseSettings
    {
        string WinesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
