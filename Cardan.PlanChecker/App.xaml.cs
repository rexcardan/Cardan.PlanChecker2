﻿using ESAPIX.Bootstrapper;
using Cardan.PlanChecker.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ESAPIX.Common;

namespace Cardan.PlanChecker
{
    /// <summary>
    /// Interaction logic for 
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string[] args = e.Args;
            base.OnStartup(e);
            var bs = new AppBootstrapper<MainView>(() => { return VMS.TPS.Common.Model.API.Application.CreateApplication(); });
            //You can use the following to load a context (for debugging purposes)
            //args = ContextIO.ReadArgsFromFile(@"context.txt");
            //Might disable (uncomment) for plugin mode
            //bs.IsPatientSelectionEnabled = false;
            bs.Run(args);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppComThread.Instance.Dispose();
            base.OnExit(e);
        }
    }
}
