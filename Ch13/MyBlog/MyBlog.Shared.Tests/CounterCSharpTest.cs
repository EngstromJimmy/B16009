using Bunit;
using Bunit.TestDoubles;
using System;
using Xunit;
using static Bunit.ComponentParameterFactory;

namespace MyBlog.Shared.Tests
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class CounterCSharpTests : TestContext
    {
        //<CounterStartsAtZero>
        [Fact]
        public void CounterStartsAtZero()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Assert that content of the paragraph shows counter at zero
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }
        //</CounterStartsAtZero>
        //<ClickingButtonIncrementsCounter>
        [Fact]
        public void ClickingButtonIncrementsCounter()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Act - click button to increment counter
            cut.Find("button").Click();

            // Assert that the counter was incremented
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
        //</ClickingButtonIncrementsCounter>
    }
}
