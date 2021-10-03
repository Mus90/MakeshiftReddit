using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace MakeshiftReddit.Models.Entities
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> option) : base(option)
        {

        }

        public DbSet <Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostVotes> PostVotes { get; set; }
        public DbSet<CommentVotes> CommentVotes { get; set; }


    }
}
