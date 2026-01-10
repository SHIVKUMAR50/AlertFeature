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
    public class AlertInfoConfiguration : IEntityTypeConfiguration<AlertInfo>
    {
        public void Configure(EntityTypeBuilder<AlertInfo> builder)
        {
            builder.HasOne(x => x.AlertCategory)
                .WithMany(x => x.Alerts)
                .HasForeignKey(x => x.AlertCategoryId);

        }
    }
}
