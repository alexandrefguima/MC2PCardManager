using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2PCardManager
{
    [Serializable]
    public class MulticoreDirectory
    {
        public DirectoryInfo DirInfo { get; set; }
        public string Readme { get; set; }
        public string RomsFolder { get; set; }

        public MulticoreDirectory()
        {
            DirInfo = null;
            Readme = string.Empty;
            RomsFolder = string.Empty;
        }
    }

    [Serializable]
    public class Multicore2TypeDirectory
    {
        public string Name { get; set; }
        public List<MulticoreDirectory> Directories { get; set; }

        public Multicore2TypeDirectory()
        {
            Name = string.Empty;
            Directories = new List<MulticoreDirectory>();
        }
    }
}
