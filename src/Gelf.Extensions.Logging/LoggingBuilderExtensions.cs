﻿#if NETSTANDARD2_0

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gelf.Extensions.Logging
{
    public static class LoggingBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="GelfLoggerProvider"/> with the service collection.
        /// <see cref="GelfLoggerOptions"/> must be configured with service collection when using this method.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddGelf(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, GelfLoggerProvider>();
            return builder;
        }

        /// <summary>
        /// Registers a <see cref="GelfLoggerProvider"/> and <see cref="GelfLoggerOptions"/>
        /// with the service collection.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddGelf(this ILoggingBuilder builder, Action<GelfLoggerOptions> configure)
        {
            builder.AddGelf();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}

#endif
