﻿using Lynicon.Extensibility;
using Lynicon.Membership;
using Lynicon.Repositories;
using Lynicon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynicon.Commands
{
    public class InitializeAdminCmd : ToolsCommandBase
    {
        LyniconSystem sys;

        public override string CommandWord
        {
            get
            {
                return "initialize-admin";
            }
        }

        public InitializeAdminCmd(LyniconSystem sys)
        {
            this.sys = sys;
        }

        public override bool Execute(params string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please give the admin password as the 3rd argument");
                return false;
            }

            if (args[0].Length < 7)
            {
                Console.WriteLine("The admin password should be at least 7 characters");
                return false;
            }

            SecurityManager.EnsureAdminUser(args[0]);

            // Ensure any caches running which store user info are dumped to disk (if necessary)
            foreach (var cache in LyniconSystem.Instance.Modules.ModuleSequence.OfType<Cache>())
            {
                if (cache.AppliesToType(typeof(User)))
                {
                    Console.WriteLine("Writing cache to file: " + cache.GetType().Name);
                    cache.Dump();
                }
            }

            Console.WriteLine("Created admin user, username: administrator, email: admin@lynicon-app.com, with supplied password");
            return true;
        }
    }
}
