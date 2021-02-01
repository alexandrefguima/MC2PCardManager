using GitLabApiClient;
using GitLabApiClient.Models.Projects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2PCardManager
{
    public class GitLab
    {
        private GitLabClient _cli;
        private string 
            _localPath = "",
            _usr = "",
            _pwd = "";

        public GitLab(string usr, string pwd, string localPath)
        {
            this._localPath = localPath; this._usr = usr; this._pwd = pwd;
            _cli = new GitLabClient("https://gitlab.com/victor.trucco/Multicore_Bitstreams");            
        }

        public async Task Login()
        {
            _ = await _cli.LoginAsync(_usr, _pwd);
            await Load();
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return (List<Project>)await _cli.Projects.GetAsync();
        }
        public async Task Load()
        {
            var projs = _cli.Projects.GetAsync();
            List<Project> ps = await GetProjectsAsync();
            Project mc2p = (from p in ps where p.Name.Equals("Multicore - Bitstreams") select p).FirstOrDefault();
            await this._cli.Files.GetAsync(mc2p, this._localPath);
        }
    }
}
