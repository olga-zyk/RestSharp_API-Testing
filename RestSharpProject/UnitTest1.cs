using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
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
            }
            catch (Exception error)
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
            }
            catch (Exception error)
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

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_object + Environment.NewLine);

            // using Json.NET Deserializer (Newtonsoft.Json.Linq.JObject)
            JObject json_data = null;
            try
            {
                json_data = JObject.Parse(response.Content);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_data);


            //TODO: finally add Assert
        }

        [TestMethod]
        public void GetSpecificRobotModelById()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            IRestRequest request = null;
            try
            {
                request = new RestRequest("robotModels/{id}", Method.GET);
                request.AddUrlSegment("id", "fafefec8-4b09-4f5f-92a1-200e91a728eb");

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            JObject json_data = null;
            try
            {
                json_data = JObject.Parse(response.Content);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_data);

        }

        [TestMethod]
        public void RobotModelFilter()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            IRestRequest request = null;
            try
            {
                request = new RestRequest("robotModels/", Method.GET);
                //request.AddParameter("filter[name]", "T-800");
                //request.AddParameter("filter[code]", "8264");

                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "filter[name]", "R2D2" },
                    { "filter[code]", "r2d2" }
                };

                foreach (var param in parameters)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            JObject json_data = null;
            try
            {
                json_data = JObject.Parse(response.Content);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(json_data);
        }

        [TestMethod]
        public void CreateNewRobotModel()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            IRestRequest request = null;
            try
            {
                request = new RestRequest("robotModels/", Method.POST);
                request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.81 Safari/537.36");
                request.AddHeader("Connection", "keep-alive");
                request.AddParameter("application/vnd.api+json", "{ \"data\": { \"type\": \"robotModels\", \"attributes\": {\"name\": \"ISO\", \"code\": \"9901\" } } }", ParameterType.RequestBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        [TestMethod]
        public void DeleteRobotModel()
        {
            var client = new RestClient("http://jsonapi-robot-wars.herokuapp.com/");

            IRestRequest request = null;
            try
            {
                request = new RestRequest("robotModels/{id}", Method.DELETE);
                request.AddUrlSegment("id", "c3e27c64-b44d-459a-9b71-18197aa4cc51");

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            if (response.IsSuccessful)
            {
                Console.WriteLine("Selected robot was deleted successfully");
            }


        }

    }

}
