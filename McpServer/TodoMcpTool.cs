using System.ComponentModel;
using ModelContextProtocol.Server;

namespace asp_core_mcp_server_http.McpServer
{
    [McpServerToolType]
    public class TodosMcpTool
    {
        private static readonly List<TodoItem> _items = new();

        [McpServerTool, Description("Reads todo items. If 'id' is provided, returns the specific item; otherwise, returns all items.")]
        public IEnumerable<TodoItem> ReadTodos(string id)
        {
            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int todoId))
            {
                var item = _items.FirstOrDefault(i => i.Id == todoId);
                if (item != null)
                {
                    return new List<TodoItem> { item };
                }
                return new List<TodoItem>();
            }

            return _items;
        }


        [McpServerTool, Description("Creates a new todo item with the given title.")]
        public TodoItem CreateTodo(string title)
        {
            var item = new TodoItem
            {
                Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1,
                Title = title,
                IsCompleted = false
            };
            _items.Add(item);
            return item;
        }

        [McpServerTool, Description("Updates an existing todo item. You can update the title and/or completion status.")]
        public TodoItem UpdateTodo(int id, string? title = null, bool? isCompleted = null)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                if (title != null)
                {
                    item.Title = title;
                }
                if (isCompleted.HasValue)
                {
                    item.IsCompleted = isCompleted.Value;
                }
            }

            return item;
        }

        [McpServerTool, Description("Deletes a todo item by its ID. Returns true if the item was found and deleted; otherwise, false.")]
        public bool DeleteTodo(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }

}

