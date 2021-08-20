using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LoadData
    {
        public static async Task LoadUsers(DataContext context)
        {
            if(await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/users.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        public static async Task LoadCourses(DataContext context)
        {
            if(await context.Courses.AnyAsync()) return;

            var courseData = await File.ReadAllTextAsync("Data/courses.json");
            var courses = JsonSerializer.Deserialize<List<Course>>(courseData);

            await context.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }
}