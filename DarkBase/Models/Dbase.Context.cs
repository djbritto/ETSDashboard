﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DarkBase.Models
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
        public virtual DbSet<eprobe_fin_dest> eprobe_fin_dest { get; set; }
    
        public virtual ObjectResult<prc_data_summary_Result> prc_data_summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_data_summary_Result>("prc_data_summary");
        }
    
        public virtual ObjectResult<prc_voice_summary_Result> prc_voice_summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_voice_summary_Result>("prc_voice_summary");
        }
    
        public virtual ObjectResult<prc_isup_summary_Result> prc_isup_summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_isup_summary_Result>("prc_isup_summary");
        }
    
        public virtual ObjectResult<prc_top_apps_summary_Result> prc_top_apps_summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_top_apps_summary_Result>("prc_top_apps_summary");
        }
    
        public virtual ObjectResult<prc_sum_apps_usage_date1_Result> prc_sum_apps_usage_date1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_sum_apps_usage_date1_Result>("prc_sum_apps_usage_date1");
        }
    
        public virtual ObjectResult<prc_iptv_count_Result> prc_iptv_count()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_iptv_count_Result>("prc_iptv_count");
        }
    
        public virtual ObjectResult<prc_top5_mobile_Result> prc_top5_mobile()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_top5_mobile_Result>("prc_top5_mobile");
        }
    
        public virtual ObjectResult<prc_top5_fixed_Result> prc_top5_fixed()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_top5_fixed_Result>("prc_top5_fixed");
        }
    
        public virtual ObjectResult<prc_combined_vol_Result> prc_combined_vol()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_combined_vol_Result>("prc_combined_vol");
        }
    
        public virtual ObjectResult<prc_ets_probe_data_Result> prc_ets_probe_data()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_ets_probe_data_Result>("prc_ets_probe_data");
        }
    
        public virtual ObjectResult<prc_probe_ets_sum_Result> prc_probe_ets_sum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_probe_ets_sum_Result>("prc_probe_ets_sum");
        }
    
        public virtual ObjectResult<prc_eprobe_ctc_Result> prc_eprobe_ctc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_eprobe_ctc_Result>("prc_eprobe_ctc");
        }
    
        public virtual ObjectResult<prc_eprobe_avg_Result> prc_eprobe_avg()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prc_eprobe_avg_Result>("prc_eprobe_avg");
        }
    
        public virtual ObjectResult<ets_eprobe_avg_server_Result> ets_eprobe_avg_server()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ets_eprobe_avg_server_Result>("ets_eprobe_avg_server");
        }
    }
}
