using GavrilovDmitryKT_41_20.Database.Helpers;
using GavrilovDmitryKT_41_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavrilovDmitryKT_41_20.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    { 

        private const string TableName = "Subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                    .HasKey(p => p.Id)
                    .HasName($"pk_(TableName)_Id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("subject_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.Title)
               .IsRequired()
               .HasColumnName("subject_title")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Название дисциплины");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("subject_type")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Тип дисциплины");

            builder.Property(p => p.TotalTime)
               .IsRequired()
               .HasColumnName("subject_totaltime")
               .HasColumnType(ColumnType.Int)
               .HasComment("Суммарное время дисциплины");
        }
    }
}
