using Microsoft.EntityFrameworkCore;
using MyLogbook.Abstractions;
using MyLogbook.Entities;


namespace MyLogbook.Repositories
{
    public class GroupRepository : DbRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }
    }
}
