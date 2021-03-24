using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string MONGODB_ADDON_URI { get; set; }
        public string MONGODB_ADDON_DB { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string MONGODB_ADDON_URI { get; set; }
        string MONGODB_ADDON_DB { get; set; }
    }
}
