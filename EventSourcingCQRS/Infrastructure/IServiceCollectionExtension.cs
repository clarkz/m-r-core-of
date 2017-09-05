﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Data;
using Infrastructure.Data.Interfaces;

namespace Infrastructure
{
	public static class IServiceCollectionExtension
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
            // Data Services
			services.AddDbContext<InventoryDbContext>(options =>
					options.UseSqlite("Data Source=./inventory.sqlite"));

            services.AddTransient<IInventoryReadRepository, InventoryReadRepository>();
			services.AddTransient<IInventoryWriteRepository, InventoryWriteRepository>();

            services.AddTransient<IInventoryRepository, InventoryRepository>();

			return services;
		}
	}
}