using Microsoft.Extensions.DependencyInjection;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;
using TestSwaggerData.Repositories;

namespace TestSwaggerData
{
    public class Seed
    {
        public void Fill(IServiceProvider serviceProvider)
        {
            using var service = serviceProvider.CreateScope();

            FillPriority(service);
            FillUser(service);
        }

        private void FillUser(IServiceScope service)
        {
            var userRepository = service.ServiceProvider.GetService<IUserRepository>()!;
            if (!userRepository.Any())
            {
                User user = new User()
                {
                    Name = "Admin"
                };
                userRepository.Create(user);
            }
        }

        private void FillPriority(IServiceScope service)
        {
            var priorityRepository = service.ServiceProvider.GetService<IPriorityRepository>()!;
            if (!priorityRepository.Any())
            {
                var lowPriority = new Priority
                {
                   Level = TaskPriority.Low,                   
                   ToDoItems = new List<ToDoItem>()
                };
                priorityRepository.Create(lowPriority);

                var mediumPriority = new Priority
                {
                    Level = TaskPriority.Medium,
                    ToDoItems = new List<ToDoItem>()
                };
                priorityRepository.Create(mediumPriority);

                var highPriority = new Priority
                {
                    Level = TaskPriority.High,
                    ToDoItems = new List<ToDoItem>()
                };
                priorityRepository.Create(highPriority);
            }
        }
    }
}
