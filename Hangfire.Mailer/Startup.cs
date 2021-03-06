﻿using System;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.Mailer.Startup))]

namespace Hangfire.Mailer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(
                    "MailerDb",
                    new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) })
                .UseFilter(new LogFailureAttribute());

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
