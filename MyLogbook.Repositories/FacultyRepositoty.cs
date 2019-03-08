using Microsoft.EntityFrameworkCore;
using MyLogbook.Abstractions;
using MyLogbook.Entities;


namespace MyLogbook.Repositories
{
    public class FacultyRepositoty : DbRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepositoty(DbContext context) : base(context)
        {
        }
    }
}
