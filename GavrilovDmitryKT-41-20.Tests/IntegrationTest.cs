using GavrilovDmitryKT_41_20.Database;
using GavrilovDmitryKT_41_20.Interfaces.SubjectInterfaces;
using GavrilovDmitryKT_41_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GavrilovDmitryKT_41_20.Tests
{
    public class IntegrationTests
    {
        public readonly DbContextOptions<SubjectDbContext> _dbContextOptions;

        public IntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<SubjectDbContext>()
                .UseInMemoryDatabase(databaseName: "subject_db")
                .Options;
        }

        [Fact]
        public async Task ItemCountCheck()
        {
            // Arrange
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var subject = new List<Subject>
            {
                new Subject
                {
                    Id = 1,
                    Title = "Физика",
                    Type = "осн.",
                    TotalTime = 50,
                },
                new Subject
                {
                    Id = 2,
                    Title = "Литература",
                    Type = "осн.",
                    TotalTime = 70,
                },
                new Subject
                {
                    Id = 3,
                    Title = "Физ.Культура",
                    Type = "осн.",
                    TotalTime = 80,
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subject);
            await ctx.SaveChangesAsync();

            // Act
            var subjectResult = await subjectService.GetSubjectAsync(CancellationToken.None);

            // Assert
            Assert.Equal(3, subjectResult.Length);
        }

        [Fact]
        public async Task GetSubjectId()
        {
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var subject = new Subject
            {
                Id = 3,
                Title = "Физ.Культура",
                Type = "осн.",
                TotalTime = 80,
            };

            await ctx.Set<Subject>().AddAsync(subject);
            await ctx.SaveChangesAsync();
            var subjectResult = await subjectService.GetSubjectAsync(subject.Id, CancellationToken.None);
            Assert.Equal(subject.Title, subjectResult.Title);

        }

        [Fact]
        public async Task AddSubject()
        {
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var subject = new Subject
            {
                Id = 11,
                Title = "Философия",
                Type = "осн.",
                TotalTime = 80,
            };

            await subjectService.AddSubjectAsync(subject);
            var addSubject = await ctx.Set<Subject>().SingleOrDefaultAsync(s => s.Title == "Философия");
            Assert.NotNull(addSubject);
        }

        [Fact]
        public async Task UpdateSubject()
        {
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var subject = new Subject
            {
                Id = 4,
                Title = "Астрономия",
                Type = "доп.",
                TotalTime = 40,
            };

            await ctx.Set<Subject>().AddAsync(subject);
            await ctx.SaveChangesAsync();
            subject.Title = "Испанский";
            subject.Type = "доп.";
            subject.TotalTime = 60;
            await subjectService.UpdateSubjectAsync(subject, CancellationToken.None);
            Assert.Equal("Испанский", subject.Title);
        }

        [Fact]
        public async Task DeleteSubject()
        {
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var subject = new List<Subject>
            {
                new Subject
                {
                    Id = 1,
                    Title = "Физика",
                    Type = "осн.",
                    TotalTime = 50,
                },
                new Subject
                {
                    Id = 2,
                    Title = "Литература",
                    Type = "осн.",
                    TotalTime = 70,
                },
                new Subject
                {
                    Id = 3,
                    Title = "Физ.Культура",
                    Type = "осн.",
                    TotalTime = 80,
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subject);
            await ctx.SaveChangesAsync();

            var subjectId = 1; // ID of the subject to delete
            var subjectResult = await subjectService.GetSubjectAsync(subjectId, CancellationToken.None);
            await subjectService.DeleteSubjectAsync(subjectResult, CancellationToken.None);
            var subjectsResult = await subjectService.GetSubjectAsync(CancellationToken.None);
            Assert.Equal(2, subjectsResult.Length);
            Assert.DoesNotContain(subjectsResult, s => s.Id == subjectId);
        }

    }
}
