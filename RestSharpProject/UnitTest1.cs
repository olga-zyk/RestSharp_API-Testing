using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace RestSharpProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            var request = new RestRequest("robotModels/", Method.GET);

            var response = client.Execute(request);
        }
    }
}
