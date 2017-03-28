using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Entity;

namespace Entity.Migrations.Default
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20170328161337_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Class", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumStudent");

                    b.Property<long>("TeacherID");

                    b.HasKey("ID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Entity.Default.Teacher", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Entity.Login", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Entity.Student", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ClassID");

                    b.Property<string>("Email");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("FullName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entity.Class", b =>
                {
                    b.HasOne("Entity.Default.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Student", b =>
                {
                    b.HasOne("Entity.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
