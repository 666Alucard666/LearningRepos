// <auto-generated />
using System;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220207123916_FixedRequiredFields")]
    partial class FixedRequiredFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Core.Models.ChatPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("DefaultStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ChatPermission");
                });

            modelBuilder.Entity("Core.Models.ChatPermissionRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int?>("ChatPermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("ChatPermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("ChatPermissionRole");
                });

            modelBuilder.Entity("Core.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastEdited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Core.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Core.Models.ServerPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("DefaultStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServerPermission");
                });

            modelBuilder.Entity("Core.Models.ServerPermissionRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ServerPermissionId")
                        .HasColumnType("int");

                    b.Property<bool>("ServerPermissionStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("ServerPermissionId");

                    b.ToTable("ServerPermissionRole");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.UserServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.HasIndex("UserId");

                    b.ToTable("UserServer");
                });

            modelBuilder.Entity("Core.Models.UserServerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserServerId");

                    b.ToTable("UserServerRole");
                });

            modelBuilder.Entity("Core.Models.Chat", b =>
                {
                    b.HasOne("Core.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Core.Models.ChatPermissionRole", b =>
                {
                    b.HasOne("Core.Models.Chat", "Chat")
                        .WithMany("ChatPermissionRoles")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ChatPermission", "ChatPermission")
                        .WithMany()
                        .HasForeignKey("ChatPermissionId");

                    b.HasOne("Core.Models.Role", "Role")
                        .WithMany("ChatPermissionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("ChatPermission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Models.Message", b =>
                {
                    b.HasOne("Core.Models.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.HasOne("Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.HasOne("Core.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Core.Models.ServerPermissionRole", b =>
                {
                    b.HasOne("Core.Models.Role", "Role")
                        .WithMany("ServerPermissionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ServerPermission", "ServerPermission")
                        .WithMany("ServerPermissionRoles")
                        .HasForeignKey("ServerPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("ServerPermission");
                });

            modelBuilder.Entity("Core.Models.UserServer", b =>
                {
                    b.HasOne("Core.Models.Server", "Server")
                        .WithMany("UserServers")
                        .HasForeignKey("ServerId");

                    b.HasOne("Core.Models.User", "User")
                        .WithMany("UserServers")
                        .HasForeignKey("UserId");

                    b.Navigation("Server");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.UserServerRole", b =>
                {
                    b.HasOne("Core.Models.Role", "Role")
                        .WithMany("UserServerRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.UserServer", "UserServer")
                        .WithMany("UserServerRoles")
                        .HasForeignKey("UserServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserServer");
                });

            modelBuilder.Entity("Core.Models.Chat", b =>
                {
                    b.Navigation("ChatPermissionRoles");
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.Navigation("ChatPermissionRoles");

                    b.Navigation("ServerPermissionRoles");

                    b.Navigation("UserServerRoles");
                });

            modelBuilder.Entity("Core.Models.Server", b =>
                {
                    b.Navigation("UserServers");
                });

            modelBuilder.Entity("Core.Models.ServerPermission", b =>
                {
                    b.Navigation("ServerPermissionRoles");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Navigation("UserServers");
                });

            modelBuilder.Entity("Core.Models.UserServer", b =>
                {
                    b.Navigation("UserServerRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
