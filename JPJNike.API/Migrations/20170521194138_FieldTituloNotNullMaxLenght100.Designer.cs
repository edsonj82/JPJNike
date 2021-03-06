﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JPJNike.API.Data;

namespace JPJNike.API.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20170521194138_FieldTituloNotNullMaxLenght100")]
    partial class FieldTituloNotNullMaxLenght100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JPJNike.API.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tag")
                        .HasMaxLength(20);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("JPJNike.API.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<int>("Quantidade");

                    b.Property<int>("Series");

                    b.HasKey("Id");

                    b.ToTable("Exercicio");
                });
        }
    }
}
