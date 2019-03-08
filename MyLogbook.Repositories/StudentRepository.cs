using Microsoft.EntityFrameworkCore;
using MyLogbook.Abstractions;
using MyLogbook.Entities;


namespace MyLogbook.Repositories
{
    public class StudentRepository : DbRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
