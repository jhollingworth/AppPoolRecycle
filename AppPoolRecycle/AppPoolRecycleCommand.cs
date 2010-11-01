using System;

namespace AppPoolRecycle
{
    public class AppPoolRecycleCommand
    {
        private readonly AppPoolRecycleConfig _config;

        public AppPoolRecycleCommand(AppPoolRecycleConfig config)
        {
            _config = config;
        }

        public void Execute()
        {
            var serverManager = _config.GetServerManager();
            var appPool = serverManager.ApplicationPools[_config.AppPoolName];

            if(null == appPool)
            {
                throw new NullReferenceException(string.Format("The app pool {0} does not exist", _config.AppPoolName));
            }

            appPool.Recycle();
            Console.WriteLine("Recycled {0}", _config.AppPoolName);
        }
    }
}