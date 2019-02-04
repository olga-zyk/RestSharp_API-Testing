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

            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            } catch (Exception error)
            {
                Console.WriteLine(error);
            }

            // deserialize json to dictionary using RestSharp Deserializer (Dictionary<string, string>)
            var deserialize = new JsonDeserializer();
            Dictionary<string, string> output = null;
            string output_data = null;
            try
            {
                output = deserialize.Deserialize<Dictionary<string, string>>(response);
                output_data = output["data"];
            } catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(output["data"] + Environment.NewLine);
            Console.WriteLine(output_data + Environment.NewLine);

            // using Json.NET Deserializer (object {Newtonsoft.Json.Linq.JObject})
            Object json_object = null;
            try
            {
                json_object = JsonConvert.DeserializeObject(response.Content);

            } catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_object + Environment.NewLine);

            // using Json.NET Deserializer (Newtonsoft.Json.Linq.JObject)
            JObject json_data = null;
            try
            {
                 json_data = JObject.Parse(response.Content);
            } catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_data);


            //TODO: finally add Assert
        }
    }
}
