using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IMLokesh.Random;
using Xunit;

namespace IMLokesh.Tests
{
    public class RandomTests
    {
        [Fact]
        public void RandomLowerCaseString()
        {
            var length = RandomIntWithMaxValue();
            var str = RandomHelper.RandomString(length, true);
            Assert.True(str.Length == length);
            Assert.True(str.ToLowerInvariant() == str);
        }

        [Fact]
        public int RandomIntWithMaxValue()
        {
            var i = RandomHelper.RandomInt(100);
            Assert.True(i >= 0 && i < 100);
            return i;
        }
    }
}
