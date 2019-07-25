﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SendARaven.Controllers.service;

namespace SendARaven.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    partial class EntityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SendARaven.Models.ChannelEntity", b =>
                {
                    b.Property<string>("TenantId")
                        .HasColumnName("tenantId")
                        .HasMaxLength(128);

                    b.Property<string>("ChannelName")
                        .HasColumnName("channelName")
                        .HasMaxLength(128);

                    b.Property<int>("ChannelProvider")
                        .HasColumnName("channelProvider");

                    b.Property<int>("ChannelType")
                        .HasColumnName("channelType");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<string>("TemplateId")
                        .HasColumnName("templateId")
                        .HasMaxLength(128);

                    b.HasKey("TenantId", "ChannelName");

                    b.ToTable("channel_entity");

                    b.HasData(
                        new
                        {
                            TenantId = "tenant_1",
                            ChannelName = "mail",
                            ChannelProvider = 0,
                            ChannelType = 1,
                            Status = 1,
                            TemplateId = "mail_sendgrid"
                        },
                        new
                        {
                            TenantId = "tenant_1",
                            ChannelName = "sms-t",
                            ChannelProvider = 1,
                            ChannelType = 0,
                            Status = 1,
                            TemplateId = "sms_msg91"
                        });
                });

            modelBuilder.Entity("SendARaven.Models.TenantDetailsEntity", b =>
                {
                    b.Property<string>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tenantId");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnName("apiKey")
                        .HasMaxLength(128);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("companyName")
                        .HasMaxLength(128);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(128);

                    b.HasKey("TenantId");

                    b.ToTable("developer");

                    b.HasData(
                        new
                        {
                            TenantId = "tenant_1",
                            ApiKey = "key_1",
                            CompanyName = "Microsoft",
                            Email = "chaitanyachawla@yahoo.co.in"
                        });
                });

            modelBuilder.Entity("SendARaven.Models.UserEntity", b =>
                {
                    b.Property<string>("TenantId")
                        .HasColumnName("tenantId");

                    b.Property<string>("UserId")
                        .HasColumnName("userId");

                    b.Property<string>("atr")
                        .IsRequired()
                        .HasColumnName("attributes");

                    b.HasKey("TenantId", "UserId");

                    b.ToTable("myuser");

                    b.HasData(
                        new
                        {
                            TenantId = "tenant_1",
                            UserId = "user_1",
                            atr = "{\"City\":\"Bangalore\"}"
                        },
                        new
                        {
                            TenantId = "tenant_1",
                            UserId = "user_2",
                            atr = "{\"City\":\"Bangalore\"}"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
