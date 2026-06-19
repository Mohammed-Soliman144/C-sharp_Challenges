using System;
using System.Collections.Generic;
using System.IO;

namespace TodoManager
{
    class Program
    {
        public static void Main(string[] args)
        {
            TodoApp todoApp = new TodoApp();
            int i = 0;
            Console.WriteLine("Enter all tasks you need to add \nA-then after finish type \"exit\"\nB-type \"print\"\nC-type \"delete\"");
            do
            {

                Console.WriteLine($"Enter Task #{i + 1}");
                string task = Console.ReadLine() ?? "";
                task = task.Trim().ToLower();
                switch (task)
                {
                    case "exit":
                        todoApp.ShowTasks();
                        i = -1;
                        break;
                    case "print":
                        todoApp.ShowTasks();
                        return;
                    case "delete":
                        Console.WriteLine("Enter task you need to delete it");
                        string deleted = Console.ReadLine() ?? "";
                        Console.WriteLine(todoApp.RemoveTask(deleted.Trim().ToLower()));
                        Console.WriteLine("new list");
                        todoApp.ShowTasks();
                        i = -1;
                        break;
                    default:
                        Console.WriteLine(todoApp.AddTask(task));
                        i++;
                        break;
                }
            } while (i != -1);
        }
    }

    class TodoApp
    {
        private List<string> todoList = new List<string>();


        public string AddTask(string task)
        {
            bool isExist = todoList.Contains(task);
            if (!isExist)
                todoList.Add(task);
            return isExist ? "This task is already exist" : "Task added successfully!";
        }


        public string RemoveTask(string task)
        {
            bool isExist = todoList.Contains(task);
            if (isExist)
                todoList.Remove(task);
            return isExist ? "Task remove successfully!" : "This Task deos not exist";
        }

        public string RemoveTask(int taskNumber)
        {
            if (taskNumber - 1 < 0 || taskNumber - 1 > todoList.Count)
                return "this task does not exit";
            bool isExist = todoList[taskNumber - 1] != "" ? true : false;
            if (isExist)
                todoList.RemoveAt(taskNumber);
            return isExist ? "Task remove successfully!" : "This Task deos not exist";
        }


        public void ShowTasks()
        {
            todoList.ForEach(task => Console.WriteLine(task));
        }
    }
}
