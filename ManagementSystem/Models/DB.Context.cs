﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManagementProjectEntities : DbContext
    {
        public ManagementProjectEntities()
            : base("name=ManagementProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<w_admin> w_admin { get; set; }
        public virtual DbSet<w_room_info> w_room_info { get; set; }
        public virtual DbSet<w_system_params> w_system_params { get; set; }
        public virtual DbSet<w_announcement> w_announcement { get; set; }
        public virtual DbSet<w_tenant> w_tenant { get; set; }
    }
}
