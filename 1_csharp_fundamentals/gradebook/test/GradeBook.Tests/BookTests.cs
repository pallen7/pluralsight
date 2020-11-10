using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(85.6, result.Average, 1); // 3rd parameter is precision. This is 1 dp
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void OnlyValidValuesAdded()
        {
            // Arrange
            var book = new Book("");
            book.AddGrade(105);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(0, result.Average);
        }
    }
}
