using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Configurattions;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PostId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreateTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property(x => x.Content).HasColumnName("Content");
        builder.Property(x => x.AuthorId).HasColumnName("Author_Id");
        builder.Property(x => x.CategoryId).HasColumnName("Category_Id");


        builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x=>x.Category)
            .WithMany(x=>x.Posts)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);



        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Navigation(x => x.Author).AutoInclude();
        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.Comments).AutoInclude();

    }
}
