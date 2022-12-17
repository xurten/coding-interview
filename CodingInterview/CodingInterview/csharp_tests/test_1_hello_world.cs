using NUnit.Framework;
//Task 1
//Writing “Hello, World!” program.
namespace CodingInterview
{
    public class Class1
    {

        private static string GetHelloWorld()
        {
            return "Hello World!";
        }

        [Test]
        public void CheckGetHelloWorldFunction()
        {
            var ExpectedString = "Hello World!";
            Assert.AreEqual(GetHelloWorld(), ExpectedString);
        }
    }

}