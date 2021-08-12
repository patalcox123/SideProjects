using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ITaskDao
    {
        List<Task> GetTasks();
        Task GetTask(int id);
        int AddTask(Task task);
        int UpdateTask(Task task);
        int UpdateTaskStatus(Task task);
        int DeleteTask(int id);
        List<Task> GetTaskByRenterId(int id);
    }
}
