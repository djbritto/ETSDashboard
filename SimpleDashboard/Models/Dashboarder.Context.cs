﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleDashboard.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdventureEntities : DbContext
    {
        public AdventureEntities()
            : base("name=AdventureEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fixed_top_ups> fixed_top_ups { get; set; }
    
        public virtual ObjectResult<prc_sum_fixed_Result> prc_sum_fixed()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_sum_fixed_Result>("prc_sum_fixed");
        }
    
        public virtual ObjectResult<Nullable<double>> prc_date_fixed()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("prc_date_fixed");
        }
    
        public virtual ObjectResult<prc_sum_apps_usage_Result> prc_sum_apps_usage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_sum_apps_usage_Result>("prc_sum_apps_usage");
        }
    
        public virtual ObjectResult<prc_sum_apps_usage_date_Result> prc_sum_apps_usage_date()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_sum_apps_usage_date_Result>("prc_sum_apps_usage_date");
        }
    
        public virtual ObjectResult<prc_sum_apps_usage_date1_Result> prc_sum_apps_usage_date1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_sum_apps_usage_date1_Result>("prc_sum_apps_usage_date1");
        }
    
        public virtual ObjectResult<prc_comb_master_Result> prc_comb_master()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_comb_master_Result>("prc_comb_master");
        }
    
        public virtual ObjectResult<prc_top5_mobile_Result> prc_top5_mobile()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_top5_mobile_Result>("prc_top5_mobile");
        }
    
        public virtual ObjectResult<prc_top5_fixed_Result> prc_top5_fixed()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_top5_fixed_Result>("prc_top5_fixed");
        }
    
        public virtual ObjectResult<prc_mobile_sum_apps_usage_Result> prc_mobile_sum_apps_usage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_mobile_sum_apps_usage_Result>("prc_mobile_sum_apps_usage");
        }
    
        public virtual ObjectResult<prc_combined_vol_Result> prc_combined_vol()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_combined_vol_Result>("prc_combined_vol");
        }
    
        public virtual ObjectResult<prc_m_sum_apps_usage_Result> prc_m_sum_apps_usage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_m_sum_apps_usage_Result>("prc_m_sum_apps_usage");
        }
    
        public virtual ObjectResult<prc_get_peek_count_Result> prc_get_peek_count()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_get_peek_count_Result>("prc_get_peek_count");
        }
    }
}