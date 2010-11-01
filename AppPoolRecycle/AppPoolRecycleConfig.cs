using System;
using Microsoft.Web.Administration;

namespace AppPoolRecycle
{
    public class AppPoolRecycleConfig
    {
        public string AppPoolName { get; set; }
        public string RemoteServerName { get; set; }

        public AppPoolRecycleConfig(string[] args)
        {
            Parse(args);
        }

        private void Parse(string[] args)
        {
            if(args.Length == 0 || args.Length > 2)
            {
                throw new ArgumentException("Incorrect arguments\n" + Example);
            }

            AppPoolName = args[0];
            
            if(args.Length == 2)
            {
                RemoteServerName = args[1];
            }
        }

        public ServerManager GetServerManager()
        {
            if(string.IsNullOrEmpty(RemoteServerName))
            {
                return new ServerManager();
            }

            return ServerManager.OpenRemote(RemoteServerName);
        }

        private string Example
        {
            get { return "apr [app pool name] [remote server name (optional)]"; }
        }
    }
}