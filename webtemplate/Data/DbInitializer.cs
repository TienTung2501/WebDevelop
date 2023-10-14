﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using webtemplate.Models;

namespace webtemplate.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.
            GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Majors.Any())
                {
                    return;
                }
                var majors = new Major[]
                {
                 new Major{MajorName="IT"},
                 new Major{MajorName="Economics"},
                 new Major{MajorName="Mathematics"}
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();
                var learners = new Learner[]
                {
                                        new Learner
                    { 
                        LastName = "Carson",
                        FirstMidName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"),
                        MajorID = 1
                    },
                    new Learner
                    {
                        LastName = "Meredith",
                        FirstMidName = "AlonSo",
                        EnrollmentDate = DateTime.Parse("2002-09-01"),
                        MajorID = 2
                    },

                }; foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }
                context.SaveChanges();
                var courses = new Course[]{
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "MicroEconomic", Credits = 3 },
                    new Course { CourseID = 4041, Title = "MacroEconomic", Credits = 3 },
                };
                foreach( var course in courses)
                {
                    context.Courses.Add(course);
                }
                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerID=1,CourseID=1050,Grade=5.5f },
                    new Enrollment { LearnerID=1,CourseID=4022,Grade=7.5f },
                    new Enrollment { LearnerID=2,CourseID=1050,Grade=3.5f },
                    new Enrollment { LearnerID=2,CourseID=4041,Grade=7f },
                    
                    
                };
                foreach(var enrollment in enrollments)
                    context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }
        }
    }
}
