using Entity.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public static class DefaultDbInitializer
    {
        public static void Initialize(DefaultDbContext context)
        {
            context.Database.EnsureCreated();

            /*if (!context.Teachers.Any())
            {
                var teachers = new Teacher[]
                {
                    new Teacher{Name = "Teacher1"},
                    new Teacher{Name = "Teacher2"},
                    new Teacher{Name = "Teacher3"}
                };
                foreach (Teacher t in teachers)
                {
                    context.Teachers.Add(t);
                }
                context.SaveChanges();
            }

            if (!context.Classes.Any())
            {
                var classes = new Class[]
                {
                    new Class{Name = "Class1", TeacherID = 1},
                    new Class{Name = "Class2", TeacherID = 2},
                    new Class{Name = "Class3", TeacherID = 1}
                };
                foreach (Class t in classes)
                {
                    context.Classes.Add(t);
                }
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student { FirstMidName = "Carson",   LastName = "Alexander", ClassID = 1,
                        EnrollmentDate = DateTime.Parse("2010-09-01") },
                    new Student { FirstMidName = "Meredith", LastName = "Alonso", ClassID = 2,
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Arturo",   LastName = "Anand", ClassID = 3,
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", ClassID = 1,
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Yan",      LastName = "Li", ClassID = 2,
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Peggy",    LastName = "Justice", ClassID = 3,
                        EnrollmentDate = DateTime.Parse("2011-09-01") },
                    new Student { FirstMidName = "Laura",    LastName = "Norman", ClassID = 1,
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Nino",     LastName = "Olivetto", ClassID = 2,
                        EnrollmentDate = DateTime.Parse("2005-09-01") }
                };

                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();
            }*/

        }
    }
}
