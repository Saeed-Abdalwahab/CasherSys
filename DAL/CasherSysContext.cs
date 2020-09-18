using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
  public  class CasherSysContext : IdentityDbContext
    {
        public CasherSysContext(DbContextOptions<CasherSysContext> options):base(options)
        {
                
        }
        public virtual DbSet<Item> items { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<itemCategory> itemCategories { get; set; }
        public virtual DbSet<ItemDetails> ItemDetails { get; set; }
        public virtual DbSet<LoafType> LoafTypes { get; set; }
    }
}
