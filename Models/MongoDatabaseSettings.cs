using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public MongoDatabaseSettings(string MONGODB_ADDON_URI, string MONGODB_ADDON_DB)
        {
            this.MONGODB_ADDON_URI = MONGODB_ADDON_URI;
            this.MONGODB_ADDON_DB = MONGODB_ADDON_DB;
        }

        public string MONGODB_ADDON_URI { get; set; }
        public string MONGODB_ADDON_DB { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string MONGODB_ADDON_URI { get; set; }
        string MONGODB_ADDON_DB { get; set; }
    }
}
