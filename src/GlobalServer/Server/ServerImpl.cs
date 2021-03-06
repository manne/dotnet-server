﻿using System.Threading;
using GlobalServer.Api;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;

namespace GlobalServer.Server
{
    public class ServerImpl : ServerBase
    {
        public ServerImpl(IGlobalServerSettings settings) 
            : base(settings)
        {
        }

        protected override ISettingsLoader GetSettingsLoader()
        {
            var propertiesFactory = PropertiesBuilder.Default();
            return propertiesFactory.GetSettingsLoader();
        }

        protected override Task StartServer(ISettings settings, CancellationToken cancellationToken)
        {
            GlobalServerApi.SetSettings(settings);

            Host = GlobalServerApi.CreateHostBuilder(new string[0])
                .Build();

            return Host.StartAsync(cancellationToken);
        }
    }
}