using System.Data;
using Microsoft.VisualBasic;

class Program
{
    static string[] todos = new String[10];
    static void Main(string[] args)
    {
        MenuApp();
    }

    static void MenuApp()
    {
        bool isStart = true;

        while (isStart)
        {
            Console.WriteLine("Todo App Monolith with Dotnet");
            Console.WriteLine("1. Add Todo");
            Console.WriteLine("2. Get All Todo");
            Console.WriteLine("3. Update Todo");
            Console.WriteLine("4. Delete Todo");
            Console.WriteLine("X. Exit APP");

            Console.Write("Choice: ");
            string userChoice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userChoice)) {
                Console.WriteLine("Please Type a Valid Menu");
            }

            switch (userChoice)
            {
                case "1":
                    MenuAddTodo();
                    break;
                case "2":
                    GetAllTodo();
                    break;
                case "3":
                    MenuUpdateTodo();
                    break;
                case "4":
                    MenuDeleteTodo();
                    break;
                case "x":
                    isStart = false;
                    break;
                case "X":
                    isStart = false;
                    break;
            }

        }
    }

    static void MenuAddTodo()
    {

        bool isValidInput = false;

        while (!isValidInput)
        {
            Console.WriteLine("Menu Add Todo");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Type x or X for CANCEL");
            Console.Write("Add Todo: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                AddTodo(input);
                isValidInput = true;
            }
            else if (input.Equals("x") || input.Equals("X"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Cannot NULL or Whitespace! Please input valid todo");
            }

        }
    }

    static void MenuUpdateTodo()
    {
        GetAllTodo();
        bool isValidInputId = false;
        bool isValidInputTodo = false;
        string id = "";
        int todoId;

        while (!isValidInputId)
        {
            Console.WriteLine("Menu Add Todo");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Type x or X for CANCEL");
            Console.Write("Todo Id: ");
            id = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(id) && !id.Equals("X") && !id.Equals("x"))
            {
                isValidInputId = true;
            }
            else if (id.Equals("x") || id.Equals("X"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Cannot NULL or Whitespace! Please input valid todo");
            }
        }

        while (!isValidInputTodo)
        {
            Console.Write("New Todo: ");
            string newTodo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTodo) && !newTodo.Equals("X") && !newTodo.Equals("x"))
            {
                todoId = int.Parse(id);
                UpdateTodo(todoId, newTodo);
                isValidInputTodo = true;
            }
            else if (newTodo.Equals("x") || newTodo.Equals("X"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Cannot NULL or Whitespace! Please input valid todo");
            }
        }
    }


    static void MenuDeleteTodo()
    {
        GetAllTodo();
        bool isValidInput = false;
        

        while (!isValidInput)
        {
            Console.WriteLine("Menu Add Todo");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Type x or X for CANCEL");
            Console.Write("Deleted Id: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && !input.Equals("X") && !input.Equals("x"))
            {
                int id = int.Parse(input);
                DeleteTodo(id);
                isValidInput = true;
            }
            else if (input.Equals("x") || input.Equals("X"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Cannot NULL or Whitespace! Please input valid todo");
            }

        }
    }

    static void AddTodo(string todo)
    {

        bool isFull = true;

        for (int i = 0; i < todos.Length; i++)
        {
            if (todos[i] == null)
            {
                isFull = false;
                break;
            }
        }

        if (isFull)
        {
            string[] tempTodos = todos;
            todos = new string[todos.Length * 2];

            for (int i = 0; i < tempTodos.Length; i++)
            {
                todos[i] = tempTodos[i];
            }
        }

        for (int i = 0; i < todos.Length; i++)
        {
            if (todos[i] == null)
            {
                todos[i] = todo;
                break;
            }
        }
    }

    static void GetAllTodo()
    {
        Console.WriteLine("------ Todolist ------");
        for (int i = 0; i < todos.Length; i++)
        {
            if (todos[i] != null)
            {
                Console.WriteLine((i + 1) + ". " + todos[i]);
            }
        }
    }

    static void DeleteTodo(int id)
    {
        if (todos[0] == null)
        {
            Console.WriteLine("Theres no todo to be deleted");
        }
        else if (id <= 0)
        {
            Console.WriteLine("Minimum id is 1");
        }
        else if (id > todos.Length)
        {
            Console.WriteLine("Id is out of length");
        }
        else if (todos[(id - 1)] == null)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i] == null)
                {
                    Console.WriteLine("Todo only untill id: " + i + "!, Cannot remove todo id: " + id);
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Success delete id: " + id + "todo: " + todos[id - 1]);
            for (int i = (id - 1); i < todos.Length; i++)
            {
                if (i == todos.Length - 1)
                {
                    todos[i] = null;
                }
                else
                {
                    string temp = todos[i + 1];
                    todos[i + 1] = todos[i];
                    todos[i] = temp;
                }
            }
        }
    }

    static void UpdateTodo(int id, string newTodo)
    {
        if (todos[0] == null)
        {
            Console.WriteLine("Theres no todo to be update");
        }
        else if (id <= 0)
        {
            Console.WriteLine("Cannot update Todo!, Minimum id is 1");
        }
        else if (id > todos.Length)
        {
            Console.WriteLine("Cannot update Todo!, Id is out of length");
        }
        else if (todos[(id - 1)] == null)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i] == null)
                {
                    Console.WriteLine("Cannot update todo id: " + id + "!, Todo only untill id: " + i);
                    break;
                }
            }
        }
        else
        {
            Console.Write("Success update id: " + id + ", from todo: " + todos[id - 1]);
            todos[id - 1] = newTodo;
            Console.Write(" to todo: " + todos[id - 1] + "\n");
        }
    }


}