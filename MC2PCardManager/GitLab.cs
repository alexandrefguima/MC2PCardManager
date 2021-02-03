using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC2PCardManager
{
    public class GitLab
    {
        private string
            _localPath = "",
            _currentVersion = "",
            _readme = "",
            _downloadedFile = "";

        public string CurrentVersion
        {
            get
            {
                if (string.IsNullOrEmpty(this._currentVersion)) this.Update();
                return this._currentVersion;
            }
        }
        public GitLab(string localPath)
        {
            this._localPath = localPath;
        }
        public bool DownloadLatest()
        {
            bool ret = true;
            try
            {
                using (var webCli = new WebClient())
                {
                    webCli.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.146 Safari/537.36";
                    this._downloadedFile = this._localPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyyMMdd-HHmm") + "_Multicore_Bitstreams-master.zip";
                    webCli.DownloadFile("https://gitlab.com/victor.trucco/Multicore_Bitstreams/-/archive/master/Multicore_Bitstreams-master.zip", this._downloadedFile);
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        public bool Update(bool downloadLatest = false)
        {
            bool ret = true;
            try
            {
                using (var webCli = new WebClient())
                {
                    webCli.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.146 Safari/537.36";

                    string page = webCli.DownloadString("https://gitlab.com/victor.trucco/Multicore_Bitstreams");

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(page);
                    HtmlNode node = doc.GetElementbyId("tree-holder");
                    if (node != null) _currentVersion = node.InnerText;
                    if (downloadLatest)
                    {
                        ret = this.DownloadLatest();
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
    }
}
