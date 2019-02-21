using System;
using IMLokesh.Random;
using Xunit;

namespace IMLokesh.Tests
{
    public class RandomTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(50)]
        public void RandomLowerCaseString(int length)
        {
            var str = RandomHelper.RandomString(length, true);
            Assert.True(str.Length == length);
            Assert.True(str.ToLowerInvariant() == str);
        }
    }
}
