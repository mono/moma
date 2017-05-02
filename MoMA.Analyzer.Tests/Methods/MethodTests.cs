using NUnit.Framework;

namespace MoMA.Analyzer.Methods.Tests
{
    [TestFixture]
    public class MethodTests
    {

        [TestCase("System.Int32 MyCompany.MyProduct.MyModule::MyMethod(System.String)", "int MyMethod(string)")]
        [TestCase("System.Int32 MyCompany.MyProduct.MyModule::MyMethod(System.String, System.Collections.Generic.IDictionary`2<System.String,System.Object>,System.String,System.Object)", "int MyMethod(string, IDictionary`2<string, Object>, string, Object)")]
        public void ToString(string methodSignature, string expectedResult)
        {
            var method = new Method(methodSignature);
            Assert.AreEqual(expectedResult, method.ToString());
        }
    }
}