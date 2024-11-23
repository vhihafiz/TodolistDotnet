class Program {
    static string[] todos = new String[10];
    static void Main(string[] args)
    {
        for (int i = 1; i<=20; i++) {
            AddTodo(i.ToString());
        }

        GetAllTodo();
        

    }

    static void AddTodo(string todo) {

        bool isFull = true;

        for (int i = 0; i < todos.Length; i++) {
            if (todos[i] == null) {
                isFull = false;
                break;
            }
        }

        if (isFull) {
            string[] tempTodos = todos;
            todos = new string[todos.Length * 2];

            for (int i = 0; i < tempTodos.Length; i++) {
                todos[i] = tempTodos[i];
            }
        }

        for (int i = 0; i < todos.Length; i++) {
            if(todos[i] == null) {
                todos[i] = todo;
                break;
            }
        }
    }

    static void GetAllTodo() {
        for (int i = 0; i < todos.Length; i++) {
            if (todos[i] != null) {
                Console.WriteLine((i+1) + ". " + todos[i]);
            }
        }
    }


} 