using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core
{
    public class CacheDictionary
    {
        public int Id = 1;
        public static Dictionary<int, byte[]> dictioanry = new Dictionary<int, byte[]>();
        private CacheDictionary()
        {

        }
        private static CacheDictionary instance = null;
        public static CacheDictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CacheDictionary();
                }
                return instance;
            }
        }

        public int Add(byte[] file)
        {
            dictioanry.Add(Id, file);
            Id++;
            return Id-1;
        }
    }
}
