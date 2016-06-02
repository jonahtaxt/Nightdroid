using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Effisoft.Nightdroid.Common.Interfaces.DataAccess;
using Effisoft.Nightdroid.Common.Interfaces.Repository;
using Effisoft.Nightdroid.DataAccess.MongoDB;
using Effisoft.Nightdroid.Repository;

namespace Effisoft.Nightdroid.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NSDataAccess>().As<INSDataAccess>();
            builder.RegisterType<NSRepository>().As<INSRepository>();

            var container = builder.Build();

            var nsDataAccess = container.Resolve<INSDataAccess>(
                new NamedParameter("connection", "mongodb://yanna:3XMPJne24U@ds058548.mlab.com:58548/yannacgmdata"),
                new NamedParameter("databaseName", "yannacgmdata")
                );
            var nsRepository = container.Resolve<INSRepository>(new TypedParameter(typeof(INSDataAccess), nsDataAccess));

            var result = nsRepository.GetNSDataAsync("entries", 3).Result;

            Console.ReadLine();
        }
    }
}