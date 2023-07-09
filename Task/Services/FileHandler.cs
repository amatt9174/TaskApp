using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using Task.Models;

namespace Task.Services
{
    public class FileHandler
    {
        public static List<TaskModel> GetTaskData(int? id)
        {
            // this will need to change when you run in your environment
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            if (File.Exists(path + "Tasks.data")) File.Delete(path + "Tasks.data");

            // load list of tasks file from json file
            var taskData = File.ReadAllText(path + "Tasks.json");
            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(taskData);
            var editTask = tasks?.Where(x => x.Id == id).ToList();

            var result = editTask?.Any();
            var isNotEmpty = result.HasValue ? true : false;
            if (isNotEmpty)
            {
                using (StreamWriter sw = new StreamWriter(path + "Tasks.data"))
                {
                    if (tasks != null && editTask != null)
                    {
                        foreach (var item in tasks)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Title);
                            sw.Write(item.CreatedOn);
                            sw.Write(item.Comments);
                            sw.Write(item.AssignedTo);
                            sw.Write(item.Priority);
                            sw.Write(item.Status);
                            sw.Write(item.StatusChangedOn);
                            sw.WriteLine();
                        }
                        return editTask;
                    }
                }
            }
            return new List<TaskModel>();
        }
        public static List<TaskModel> GetOpenTaskData()
        {
            // this will need to change when you run in your environment
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            if (File.Exists(path + "Tasks.data")) File.Delete(path + "Tasks.data");

            // load list of tasks file from json file
            var taskData = File.ReadAllText(path + "Tasks.json");
            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(taskData);
            var openTasks = tasks?.Where(x => x.Status?.ToLower() != "closed" && x.Status?.ToLower() != "completed").ToList();

            var result = openTasks?.Any();
            var isNotEmpty = result.HasValue ? true : false;
            if (isNotEmpty)
            {
                using (StreamWriter sw = new StreamWriter(path + "Tasks.data"))
                {
                    if (tasks != null && openTasks != null)
                    {
                        foreach (var item in tasks)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Title);
                            sw.Write(item.CreatedOn);
                            sw.Write(item.Comments);
                            sw.Write(item.AssignedTo);
                            sw.Write(item.Priority);
                            sw.Write(item.Status);
                            sw.Write(item.StatusChangedOn);
                            sw.WriteLine();
                        }
                        return openTasks;
                    }
                }
            }
            return new List<TaskModel>();
        }
        public static List<TaskModel> GetAllTaskData()
        {
            // this will need to change when you run in your environment
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            if (File.Exists(path + "Tasks.data")) File.Delete(path + "Tasks.data");

            // load list of tasks file from json file
            var taskData = File.ReadAllText(path + "Tasks.json");
            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(taskData);

            var result = tasks?.Any();
            var isNotEmpty = result.HasValue ? true : false;
            if (isNotEmpty)
            {
                using (StreamWriter sw = new StreamWriter(path + "Tasks.data"))
                {
                    if (tasks != null)
                    {
                        foreach (var item in tasks)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Title);
                            sw.Write(item.CreatedOn);
                            sw.Write(item.Comments);
                            sw.Write(item.AssignedTo);
                            sw.Write(item.Priority);
                            sw.Write(item.Status);
                            sw.Write(item.StatusChangedOn);
                            sw.WriteLine();
                        }
                        return tasks;
                    }
                }
            }
            return new List<TaskModel>();
        }
        public static List<StatusModel> GetStatusData()
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            var StatusData = File.ReadAllText(path + @"Statuses.json");
            var statuses = JsonSerializer.Deserialize<List<StatusModel>>(StatusData);

            var result = statuses?.Any();
            var isNotEmpty = result.HasValue ? true : false;
            if (isNotEmpty)
            {
                using (StreamWriter sw = new StreamWriter(path + @"Statuses.data"))
                {
                    if (statuses != null)
                    {
                        foreach (var item in statuses)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Name);
                            sw.WriteLine();
                        }
                        return statuses;
                    }
                }
            }
            return new List<StatusModel>();
        }
        public static List<PriorityModel> GetPriorityData()
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            var priorityData = File.ReadAllText(path + @"Priorities.json");
            var priorities = JsonSerializer.Deserialize<List<PriorityModel>>(priorityData);

            var result = priorities?.Any();
            var isNotEmpty = result.HasValue ? true : false;
            if (isNotEmpty)
            {
                using (StreamWriter sw = new StreamWriter(path + @"Priorities.data"))
                {
                    if (priorities != null)
                    {
                        foreach (var item in priorities)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Name);
                            sw.WriteLine();
                        }
                        return priorities;
                    }
                }
            }
            return new List<PriorityModel>();
        }
        public static List<UserModel> GetUserData()
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            var userData = File.ReadAllText(path + @"Users.json");
            var users = JsonSerializer.Deserialize<List<UserModel>>(userData);

            if (users != null)
            {
                using (StreamWriter sw = new StreamWriter(path + @"Users.data"))
                {
                    foreach (var item in users)
                    {
                        sw.Write(item.Id);
                        sw.Write(item.Name);
                        sw.WriteLine();
                    }
                }
                return users;
            }
            return new List<UserModel>();
        }
        public static bool UpdateTaskData([FromForm] TaskViewModel model)
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = @"/Users/amatt/source/repos/TaskApp/Task/Data/";

            var _model = model;
            
            var _userName = "";
            var _priority = "";
            var _status = "";

            // get user, priority, status and task data from json files

            // get user
            var userData = File.ReadAllText(path + @"Users.json");
            var users = JsonSerializer.Deserialize<List<UserModel>>(userData);

            if (users != null)
            {
                int index = users.FindIndex(x => x.Id.ToString() == _model.SelectedUser);
                if (index == -1) return false;

                _userName = users[index].Name;
            }
            else
            {
                return false;
            }

            //get priority
            var priorityData = File.ReadAllText(path + @"Priorities.json");
            var priorities = JsonSerializer.Deserialize<List<UserModel>>(priorityData);

            if (priorities != null)
            {

                int index = priorities.FindIndex(x => x.Id.ToString() == _model.SelectedPriority);
                if (index == -1) return false;

                _priority = priorities[index].Name;
            }
            else
            {
                return false;
            }

            //get status
            var statusData = File.ReadAllText(path + @"Statuses.json");
            var statuses = JsonSerializer.Deserialize<List<UserModel>>(statusData);

            if (statuses != null)
            {

                int index = statuses.FindIndex(x => x.Id.ToString() == _model.SelectedStatus);
                if (index == -1) return false;

                _status = statuses[index].Name;
            }
            else
            {
                return false;
            }

            // get task data
            var taskData = File.ReadAllText(path + @"Tasks.json");
            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(taskData);
            if (tasks != null)
            {
                var task = tasks.Where(x => x.Id == model.Id).FirstOrDefault();
                if (task != null)
                {
                    // update task data
                    var index = tasks.FindIndex(x => x.Id == _model.Id);
                    if (index == -1) return false;
                    tasks[index].Title = _model.Title;
                    tasks[index].Comments = _model.Comments;
                    tasks[index].AssignedTo = _userName;
                    tasks[index].Priority = _priority;
                    tasks[index].Status = _status;
                    tasks[index].StatusChangedOn = DateTime.Now.ToString("MM-dd-yyyy");

                    using (StreamWriter sw = new StreamWriter(path + @"Tasks.data"))
                    {
                        foreach (var item in tasks)
                        {
                            sw.Write(item.Id);
                            sw.Write(item.Title);
                            sw.Write(item.CreatedOn);
                            sw.Write(item.Comments);
                            sw.Write(item.AssignedTo);
                            sw.Write(item.Priority);
                            sw.Write(item.Status);
                            sw.Write(item.StatusChangedOn);
                            sw.WriteLine();
                        }
                    }

                    // rewrite updated task json file
                    //if (File.Exists(path + @"Tasks.json")) File.Delete(path + @"Tasks.json");
                    File.WriteAllText(path + @"tasks.json", JsonSerializer.Serialize<List<TaskModel>>(tasks));

                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
