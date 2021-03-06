﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGS.Kanban.Domain;
using System;

namespace PGS.Kanban.Domain.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20180418172327_AddCards")]
    partial class AddCards
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGS.Kanban.Domain.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("PGS.Kanban.Domain.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ListId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PGS.Kanban.Domain.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("PGS.Kanban.Domain.Models.Card", b =>
                {
                    b.HasOne("PGS.Kanban.Domain.Models.List", "List")
                        .WithMany("Cards")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PGS.Kanban.Domain.Models.List", b =>
                {
                    b.HasOne("PGS.Kanban.Domain.Models.Board", "Board")
                        .WithMany("Lists")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
