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
            var Expected_String = "Hello World!";
            Assert.AreEqual(GetHelloWorld(), Expected_String);
        }
    }

}