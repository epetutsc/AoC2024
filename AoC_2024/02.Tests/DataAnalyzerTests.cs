using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Tests
{
    public class DataAnalyzerTests
    {
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 2, 1 }, true)]
        [InlineData(new int[] { 1, 2, 7, 8, 9 }, false)]
        [InlineData(new int[] { 9, 7, 6, 2, 1 }, false)]
        [InlineData(new int[] { 1, 3, 2, 4, 5 }, true)]
        [InlineData(new int[] { 8, 6, 4, 4, 1 }, true)]
        [InlineData(new int[] { 1, 3, 6, 7, 9 }, true)]
        public void TestSafety(int[] report, bool expected)
        {
            var analyzer = new DataAnalyzer();
            var result = analyzer.IsSafe(report);
            result.Should().Be(expected);
        }
    }
}
