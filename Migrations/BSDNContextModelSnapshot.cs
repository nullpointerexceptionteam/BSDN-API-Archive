﻿// <auto-generated />
using System;
using BSDN_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BSDN_API.Migrations
{
    [DbContext(typeof(BSDNContext))]
    partial class BSDNContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BSDN_API.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<int>("UserId");

                    b.Property<int>("ViewNumber");

                    b.HasKey("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("BSDN_API.Models.ArticleTag", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("TagId");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTags");
                });

            modelBuilder.Entity("BSDN_API.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BSDN_API.Models.ResourceFile", b =>
                {
                    b.Property<int>("ResourceFileId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Filename")
                        .HasMaxLength(512);

                    b.HasKey("ResourceFileId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ResourceFiles");
                });

            modelBuilder.Entity("BSDN_API.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpiresTime");

                    b.Property<string>("SessionToken")
                        .HasMaxLength(512);

                    b.Property<int>("SessionUserId");

                    b.HasKey("SessionId");

                    b.HasIndex("SessionToken")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BSDN_API.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagName")
                        .HasMaxLength(64);

                    b.HasKey("TagId");

                    b.HasIndex("TagName")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BSDN_API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("Nickname")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(256);

                    b.Property<DateTime>("SignDate");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BSDN_API.Models.UserFollow", b =>
                {
                    b.Property<int>("FollowerId");

                    b.Property<int>("FollowingId");

                    b.HasKey("FollowerId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("UserFollows");
                });

            modelBuilder.Entity("BSDN_API.Models.Article", b =>
                {
                    b.HasOne("BSDN_API.Models.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BSDN_API.Models.ArticleTag", b =>
                {
                    b.HasOne("BSDN_API.Models.Article", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BSDN_API.Models.Tag", "Tag")
                        .WithMany("ArticleTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BSDN_API.Models.Comment", b =>
                {
                    b.HasOne("BSDN_API.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BSDN_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BSDN_API.Models.ResourceFile", b =>
                {
                    b.HasOne("BSDN_API.Models.Article", "Article")
                        .WithMany("ResourceFiles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BSDN_API.Models.UserFollow", b =>
                {
                    b.HasOne("BSDN_API.Models.User", "Follower")
                        .WithMany("UserFollowers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BSDN_API.Models.User", "Following")
                        .WithMany("UserFollowings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
