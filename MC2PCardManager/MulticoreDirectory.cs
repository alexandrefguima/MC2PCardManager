using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2PCardManager
{
    public enum eMCModels
    {
        Undefined = 0,
        Multicore1 = 1,
        Multicore2 = 2,
        Multicore2p = 3
    }    

    [Serializable]
    public class MulticoreDirectory
    {
        public Multicore2TypeDirectory TypeDir { get; set; }
        public DirectoryInfo DirInfo { get; set; }
        public string Readme { get; set; }
        public List<MulticoreCoreZipFile> Cores { get; set; }
        public MulticoreDirectory()
        {
            TypeDir = null;
            DirInfo = null;
            Readme = string.Empty;
            Cores = new List<MulticoreCoreZipFile>();
        }
    }

    [Serializable]
    public class Multicore2TypeDirectory
    {
        public string Name { get; set; }
        public bool HaveRoms { get; set; }

        public List<MulticoreDirectory> Directories { get; set; }

        public Multicore2TypeDirectory()
        {
            Name = string.Empty;
            HaveRoms = false;
            Directories = new List<MulticoreDirectory>();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class MulticoreCoreZipFile
    {
        public string Name
        {
            get
            {
                return FileInfo.Name.ToUpper().Replace(".ZIP", "");
            }
        }
        public MulticoreDirectory HardDir { get; set; }
        public FileInfo FileInfo { get; set; }

        public string ZipContents { get; set; }

        public string RomsFolder { get; set; }

        public bool IsOnSD { get; set; }
        public bool SameName { get; set; }

        public MulticoreCoreZipFile()
        {
            HardDir = null;
            FileInfo = null;
            RomsFolder = string.Empty;
            IsOnSD = false;
            SameName = false;
        }

        public override string ToString()
        {
            string ret = FileInfo.Name;
            if (SameName) ret += " [" + HardDir.DirInfo.Name + "]";
            return ret;
        }
    }

    [Serializable]
    public class Multicore2Repo
    {
        public eMCModels Model { get; set; }
        public List<Multicore2TypeDirectory> TypeDirs { get; set; }

        public Multicore2Repo()
        {
            TypeDirs = new List<Multicore2TypeDirectory>();
            Model = eMCModels.Undefined;
        }

        public Multicore2Repo(eMCModels model)
        {
            TypeDirs = new List<Multicore2TypeDirectory>();
            Model = model;
        }

        public void ClearSdMarks()
        {
            foreach(Multicore2TypeDirectory tDir in TypeDirs)
            {
                foreach(MulticoreDirectory mcDir in tDir.Directories)
                {
                    foreach(MulticoreCoreZipFile core in mcDir.Cores)
                    {
                        core.IsOnSD = false;
                    }
                }
            }
        }

        public List<MulticoreCoreZipFile> Cores
        {
            get
            {
                List<MulticoreCoreZipFile> ret = new List<MulticoreCoreZipFile>();
                foreach (Multicore2TypeDirectory tDir in TypeDirs)
                {
                    foreach (MulticoreDirectory mcDir in tDir.Directories)
                    {
                        ret.AddRange(mcDir.Cores);
                    }
                }
                return ret;
            }
        }
        public override string ToString()
        {
            return Model.ToString();
        }
    }
}
