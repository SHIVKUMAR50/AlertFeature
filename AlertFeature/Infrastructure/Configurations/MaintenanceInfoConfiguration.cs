using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class MaintenanceInfoConfiguration : IEntityTypeConfiguration<MaintenanceInfo>
    {
        public void Configure(EntityTypeBuilder<MaintenanceInfo> builder)
        {
            builder.HasOne(x => x.AlertInfo)
                .WithOne(x => x.MaintenanceInfo)
                .HasForeignKey<MaintenanceInfo>(x => x.AlertId);
        }
    }
}
