using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CareShiftAPI.Tests
{
    public class ShiftConflictTests
    {
        [Fact]
        public void SameWorkerSameDate_ShouldBeConflict()
        {
            //Arrange -set up the data
            var existingShiftDate = new DateTime(2025, 6, 1);
            var newShiftDate = new DateTime(2025, 6, 1);

            //Act - run the logic being tested
            bool isConflict = existingShiftDate.Date == newShiftDate.Date;

            //Assert - verify the result
            Assert.True(isConflict);
        }

        [Fact]
        public void SameWorkerDifferentDate_ShouldNotBeConflict()
        {
            var existingShiftDate = new DateTime(2025, 6, 1);
            var newShiftDate = new DateTime(2025, 6, 2);

            bool isConflict = existingShiftDate.Date == newShiftDate.Date;

            Assert.False(isConflict);
        }
    }
}
