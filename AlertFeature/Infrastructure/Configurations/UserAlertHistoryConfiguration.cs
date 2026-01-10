using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class UserAlertHistoryConfiguration : IEntityTypeConfiguration<UserAlertHistory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAlertHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AlertInfo)
            .WithMany(x => x.AlertHistory)
            .HasForeignKey(x => x.AlertId);
        }
    }
}
