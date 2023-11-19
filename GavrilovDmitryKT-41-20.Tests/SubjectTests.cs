using GavrilovDmitryKT_41_20.Models;

namespace GavrilovDmitryKT_41_20.Tests

{
    public class SubjectTests
    {
        [Fact]
        public void isValid_SubjectTitle_True()
        {
            // Arrange
            var subject = new Subject
            {
                Id = 1,
                Title = "География",
                Type = "осн.",
                TotalTime = 80
            };

            // Act
            var result = subject.IsValidSubjectTitle();

            // Assert
            Assert.True(result);
        }

    }
}