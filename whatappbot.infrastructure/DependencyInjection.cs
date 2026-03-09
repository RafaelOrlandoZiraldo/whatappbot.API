using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.Interface;
using whatappbot.aplication.Services;
using whatappbot.domain.Repository;
using whatappbot.infrastructure.Repository;

namespace whatappbot.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IChatSessionService, ChatSessionService>();
            services.AddTransient<IManageStateService, ManageStateService>();
            services.AddHttpClient<IWhatAppService, WhatAppService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IEmailService, EmailService>();


            return services;
        }
    }
}
