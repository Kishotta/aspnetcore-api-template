using AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Todos;

public sealed class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todos");
        
        builder.HasKey(todo => todo.Id);

        builder.Property(todo => todo.Title).HasMaxLength(200);
    }
}