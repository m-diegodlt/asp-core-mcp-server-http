# ASP Core MCP Server HTTP

This project is an ASP.NET Core server implementation for Model Context Protocol (MCP) over HTTP.

## Resources

- [MCP Official Docs](https://modelcontextprotocol.io/docs/getting-started/intro)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Adding MCP to ASP.NET Core project tutorial](https://learn.microsoft.com/en-us/azure/app-service/tutorial-ai-model-context-protocol-server-dotnet)

## Features

- ASP.NET Core based HTTP server
- Model Context Protocol (MCP) support

## Getting Started

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/asp-core-mcp-server-http.git
    ```

2. **Install dependencies:**
    ```bash
    dotnet restore
    ```

3. **Run the server:**
    ```bash
    dotnet run
    ```

## Project Structure

- `Controllers/` - HTTP endpoints
- `McpServer/` - MCP tools

## Requirements

- .NET 9.0 or later

## How to run locally and test using VS Code

**NOTE**: These instructions should be followed on VS Code.

### 1. Run the server:
- Navigate to the project directory and execute in the terminal:
    ```bash
    dotnet run
    ```

### 2. Add MCP server to VS Code:
- Open the `mcp.json` file in the project directory.
- Click on the "Add Server..." button in the bottom right corner of the editor window.
- Select "HTTP" as the server type.
- The full URL will consist of the base address from the terminal output (e.g., http://localhost:5000) followed by `/api/mcp`, resulting in http://localhost:5000/api/mcp. **NOTE**: The port number may vary. Reference the terminal output for the correct port number.
- Set the server name to `todos-mcp-server`. This name will be used in the prompts to reference this MCP server.

### 3. Test the server:
- Open the Copilot Studio chat window in VS Code.
- Set the chat to "Agent" mode.
- Use the following prompt for the first message:
    ```
    Using todos-mcp-server get me all todos
    ```
- This will ensure that the Copilot Chat uses the correct MCP server for the request.
- Subsequent messages shouldn't require explicitly mentioning the MCP server.

### 4. Prompt usage example:
- "Using todos-mcp-server get me all todos"
- "Add a new todo with title 'Buy groceries'"
- "Add a new todo with title 'Walk the dog'"
- "Get all todos"
- "Update the todo with id 1 to mark it as completed and get me all todos."
- "Delete the todo with id 2 and get me all todos."

## License

This project is licensed under the MIT License.
