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
    public class ReleaseInfoConfiguration : IEntityTypeConfiguration<ReleaseInfo>
    {
        public void Configure(EntityTypeBuilder<ReleaseInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AlertInfo)
                .WithOne(x => x.ReleaseInfo)
               .HasForeignKey<ReleaseInfo>(x=>x.AlertId);
        }
    }
}
