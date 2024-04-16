using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.Models;

namespace TWC_DatabaseLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ProjectTag> ProjectTags { get; set; }
        public virtual DbSet<UserTag> UserTags { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
