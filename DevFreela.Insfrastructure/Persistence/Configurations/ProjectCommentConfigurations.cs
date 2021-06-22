using DevFreela.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                 .HasKey(p => p.Id);


            builder
                .HasOne(c => c.Project)
                .WithMany(p => p.ProjectComments)
                .HasForeignKey(c => c.IdProject);

            builder
               .HasOne(c => c.User)
               .WithMany(u => u.ProjectComments)
               .HasForeignKey(c => c.IdUser);
        }
    }
}
