using Pipeline.API.Handlers;

namespace Pipeline.API.Endpoints
{
    public static class TodoEndpoint
    {
        public static void MapTodoRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/todoitems", TodoHandlers.GetAllTodos);
            app.MapGet("/todoitems/complete", TodoHandlers.GetCompleteTodos);
            app.MapGet("/todoitems/{id}", TodoHandlers.GetTodoById);
            app.MapPost("/todoitems", TodoHandlers.CreateTodo);
            app.MapPut("/todoitems/{id}", TodoHandlers.UpdateTodo);
            app.MapDelete("/todoitems/{id}", TodoHandlers.DeleteTodo);
        }
    }
}
