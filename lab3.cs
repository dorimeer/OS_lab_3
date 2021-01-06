using System;
using System.Collections.Generic;

namespace Lab3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var processController = new ProcessController();
            processController.Append(new Process("Process1", 7));
            processController.Append(new Process("Process2", 2));
            processController.Append(new Process("Process3", 8));
            processController.Append(new Process("Process4", 5));
            foreach (var process in processController.ExecuteAllProcesses())
            {
                Console.WriteLine($"{process.Name} executed. Execution time: {process.ExecutionTime}");
            }
        }
    }
    public class Process
    {
        public string Name { get; set; }

        public int ExecutionTime { get; set; }

        public Process(string name, int executionTime)
        {
            Name = name;
            ExecutionTime = executionTime;
        }
    }

    public class ProcessController
    {
        public Queue<Process> ProcessContainer { get; }

        public ProcessController()
        {
            ProcessContainer = new Queue<Process>();
        }
        public void Append(Process process)
        {
            ProcessContainer.Enqueue(process);   
        }
        public Process ExecuteProcess()
        {
            return ProcessContainer.Dequeue();
        }
        public IEnumerable<Process> ExecuteAllProcesses()
        {
            while (ProcessContainer.Count != 0)
            {
                yield return ProcessContainer.Dequeue();
            }
        }
    }
}