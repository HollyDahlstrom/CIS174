using FirstResponsiveWebAppDahlstrom.Models;
using Xunit;
using System;

// Name: Holly Dahlstrom
// Class: DMACC CIS 174
// Date: 1/30/2026
// Assignment: First Responsive Web App Dahlstrom - Unit Testing  

namespace FirstResponsiveWebAppDahlstromTests
{
    public class BirthdayModelTests
    {
        // Test AgeThisYear() with normal birth year
        [Fact]
        public void AgeThisYear_ReturnsCorrectAge()
        {
            // Arrange
            var model = new BirthdayModel { BirthYear = 2000 };

            // Act
            var age = model.AgeThisYear();

            // Assert
            Assert.Equal(DateTime.Now.Year - 2000, age);
        }

        // Test AgeThisYear() with null birth year
        [Fact]
        public void AgeThisYear_NullBirthYear_ReturnsNull()
        {
            // Arrange
            var model = new BirthdayModel { BirthYear = null };

            // Act
            var age = model.AgeThisYear();

            // Assert
            Assert.Null(age);
        }

        // Test AgeToday() when birthday already occurred this year
        [Fact]
        public void AgeToday_BirthdayAlreadyOccurred_ReturnsCorrectAge()
        {
            // Arrange
            var today = DateTime.Today;
            var birthDate = today.AddYears(-25).AddDays(-1); 
            var model = new BirthdayModel
            {
                BirthYear = birthDate.Year,
                BirthMonth = birthDate.Month,
                BirthDay = birthDate.Day
            };

            // Act
            var age = model.AgeToday();

            // Assert
            Assert.Equal(25, age);
        }

        // Test AgeToday() when birthday has not yet occurred this year
        [Fact]
        public void AgeToday_BirthdayNotOccurredYet_ReturnsCorrectAge()
        {
            // Arrange
            var today = DateTime.Today;
            var birthDate = today.AddYears(-25).AddDays(1); 
            var model = new BirthdayModel
            {
                BirthYear = birthDate.Year,
                BirthMonth = birthDate.Month,
                BirthDay = birthDate.Day
            };

            // Act
            var age = model.AgeToday();

            // Assert
            Assert.Equal(24, age);
        }

        // Test AgeToday() with null values
        [Fact]
        public void AgeToday_NullValues_ReturnsNull()
        {
            // Arrange
            var model = new BirthdayModel
            {
                BirthYear = null,
                BirthMonth = null,
                BirthDay = null
            };

            // Act
            var age = model.AgeToday();

            // Assert
            Assert.Null(age);
        }

        // Test AgeToday() with invalid date (Feb 30)
        [Fact]
        public void AgeToday_InvalidDate_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var model = new BirthdayModel
            {
                BirthYear = 2024,
                BirthMonth = 2,
                BirthDay = 30  
            };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => model.AgeToday());
        }

        // Test AgeThisYear() with a future birth year
        [Fact]
        public void AgeThisYear_FutureBirthYear_ReturnsNegativeAge()
        {
            // Arrange
            var nextYear = DateTime.Now.Year + 1;
            var model = new BirthdayModel { BirthYear = nextYear };

            // Act
            var age = model.AgeThisYear();

            // Assert
            Assert.Equal(-1, age);  // Next year minus current year = -1
        }
    }
}