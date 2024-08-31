using FluentValidation;
using ToDoApi.Models;
namespace ToDoApi.Validators
{
	public class TodoItemValidator : AbstractValidator<TodoItem>
	{
		public TodoItemValidator(){
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("The Name is required.");
		}
	}
}
