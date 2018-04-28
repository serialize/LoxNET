using System;
using System.Reflection;
using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;
using LoxNET.Transport.Domain.Model.ConnectionModel;
using LoxNET.Transport.Domain.Services;

namespace LoxNET.Transport
{
    public static class LoxNETTransport
    {
        public static Assembly Assembly { get; } = typeof(LoxNETTransport).Assembly;

        public static IEventFlowOptions ConfigureTransportDomain(this IEventFlowOptions eventFlowOptions)
        {
            return eventFlowOptions
                .AddDefaults(Assembly)
                .RegisterServices(sr => {
                    sr.Register<ISocketService, SocketService>(Lifetime.Singleton);
                });
        }

    }
    
}