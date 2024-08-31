using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using FluentValidation.AspNetCore;
using ToDoApi.Validators;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(
	opt => opt.UseSqlite("Data Source=TodoList.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
	.AddFluentValidation(fv => fv
	.RegisterValidatorsFromAssemblyContaining<TodoItemValidator>());
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using(var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
	context.Database.EnsureCreated();
}
app.Run();