using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;


namespace RestSharpProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListAllRobotModels()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            var request = new RestRequest("robotModels/", Method.GET);

            var response = client.Execute(request);

            // deserialize json to dictionary using RestSharp Deserializer (string)
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var output_data = output["data"];
            Console.WriteLine(output["data"] + Environment.NewLine);
            Console.WriteLine(output_data + Environment.NewLine);

            //TODO: add exception

            // using Json.NET Deserializer (object {Newtonsoft.Json.Linq.JObject})
            var json_object = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(json_object + Environment.NewLine);

            //TODO: add exception

            // using Json.NET Deserializer (Newtonsoft.Json.Linq.JObject)
            JObject json_data = JObject.Parse(response.Content);
            Console.WriteLine(json_data);

            //TODO: add exception


            //TODO: finally add Assert
        }
    }
}
