using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Database;

public abstract class ModuleDbContext<TModuleDbContext>(
    DbContextOptions<TModuleDbContext> options,
    string schema,
    Assembly moduleInfrastructureAssembly)
    : DbContext(options) where TModuleDbContext : ModuleDbContext<TModuleDbContext>
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(schema);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(moduleInfrastructureAssembly);

        base.OnModelCreating(modelBuilder);
    }
}