﻿namespace Intillegio.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(IntillegioContext dbContext, IServiceProvider serviceProvider);
    }
}
