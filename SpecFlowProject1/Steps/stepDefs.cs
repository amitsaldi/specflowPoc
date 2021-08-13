using RestSharp;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using NUnit.Framework;
using Newtonsoft.Json;
using SpecFlowProject1.Model;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class stepDefs
    {

        
        private readonly ScenarioContext _scenarioContext;
        private string _url;
        private string _path;
        private string _accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiJhcGk6Ly85NTYzNjIxMy1mOTkzLTRmYjgtYTBkZS00MzE5NTdkMjljMmUiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9jYmE4Y2EwMy04Yjk1LTQ0OGQtYjI1OS05OGE0NGQxMTJmN2MvIiwiaWF0IjoxNjI4ODE1NTEyLCJuYmYiOjE2Mjg4MTU1MTIsImV4cCI6MTYyODgxOTQxMiwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhUQUFBQWRXL1prSTl2U3V3THFybktYck9mcVBqN2dhUS9aQXFvcG55UVNnSmhXejlIMTE3bWg0OEJsOUdZS2hmUG5SOVNwcGN0eGtDYTU1ZnVRUzVzQlIwNWZ3PT0iLCJhbXIiOlsicHdkIiwid2lhIiwibWZhIl0sImFwcGlkIjoiOTU2MzYyMTMtZjk5My00ZmI4LWEwZGUtNDMxOTU3ZDI5YzJlIiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJTYWxkaSIsImdpdmVuX25hbWUiOiJBbWl0IiwiaXBhZGRyIjoiNTguOTYuNjYuNzkiLCJuYW1lIjoiQW1pdCBTYWxkaSIsIm9pZCI6IjczYzJhMjM1LTNkMjktNGU2ZS05Y2VlLTk2MDZmODcyY2MyYiIsIm9ucHJlbV9zaWQiOiJTLTEtNS0yMS03NzA4MzI5ODMtMjkyOTk1ODg1My0xODAyMDk3NjQ0LTM5NTM0NSIsInJoIjoiMC5BUW9BQThxb3k1V0xqVVN5V1ppa1RSRXZmQk5pWTVXVC1iaFBvTjVER1ZmU25DNEtBQ2MuIiwicm9sZXMiOlsicm9sZXMucHJvZHVjdHMud3JpdGUiXSwic2NwIjoicHJvZHVjdHMucmVhZCBwcm9kdWN0cy53cml0ZSIsInN1YiI6IlFOemg3MXU3aFpfcTJqZDZBYTdwdUxiQnpUUl9mWXpkYlpUZGVBQUtWN2MiLCJ0aWQiOiJjYmE4Y2EwMy04Yjk1LTQ0OGQtYjI1OS05OGE0NGQxMTJmN2MiLCJ1bmlxdWVfbmFtZSI6IkFtaXQuU2FsZGlAa21hcnQuY29tLmF1IiwidXBuIjoiQW1pdC5TYWxkaUBrbWFydC5jb20uYXUiLCJ1dGkiOiI3SmlfcHFHbTdFV21vVmQ5Qkx1NEFRIiwidmVyIjoiMS4wIn0.SijTS4G4w8UoCVERDdvcQUgVDrNRCTtsIBvciPuadGDXQ2HHpK-Lob2t9ZQtuulXPhatcDOp9GCb_yowsrVd10vUJeQmuYCYwblv0Xn785X5xmICtwkKBTBOsgU1mJmSuEM3D3xuDKd8PbbGHGfRbSkYnAi2PmqAc9XGywA6JtyhRdDTLe0CfLQXB239bjxIj0EeWQNFU6P0KOns0pX2X8HBFArPb3ekJUz6cmFf4AxelwtajjWF2OVAfQvi0kOFYPxNF-c2KU9RfcWfGzk3qelShHUAekMH3xmhhIhgNha5nQsLo9AKP4mJLpS1fmkEO9UV67WtOGHr7oDT4bL4KQ";


        public stepDefs(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the url is ""(.*)""")]
        public void GivenTheUrlIs(string baseURL)
        {
            this._url = baseURL;
        }

        [Given(@"I perform a POST operation for (.*)")]
        public void GivenIPerformAPOSTOperation(string path)
        {
          
            Console.WriteLine("path is " + path);
            IRestClient client = new RestClient(this._url);
            //Building the Request
            IRestRequest request = new RestRequest(path, Method.POST, DataFormat.Json);

            var attributes = new List<posts>() { new posts() { Category = "Planning", SubCategory = "Flexible", AttributeName = "KEY TREND", AttributeValue = "ASSYMETRIC" } };

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("Authorization", "Bearer " + this._accessToken, ParameterType.HttpHeader);
            request.AddJsonBody(attributes);

            //Make the API request and get response
            IRestResponse response = client.Execute(request);
            _scenarioContext.Add("restResponse", response);
        }


        [Given(@"I perform a GET operation for (.*)")]
        public void GivenIPerformAGETOperationForApiVAttributes(string path)
        {
            IRestClient client = new RestClient(this._url);
            //Building the Request
            IRestRequest request = new RestRequest(path, Method.GET, DataFormat.Json);
            //request headers
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("api-version", "1.0");
            request.AddParameter("Authorization", "Bearer " + this._accessToken, ParameterType.HttpHeader);

            //Make the API request and get response
            IRestResponse response = client.Execute(request);
            _scenarioContext.Add("restResponse", response);
        }

        [Then(@"I should have the response with status code (.*)")]
        public void ThenIShouldHaveTheResponseWithStatusCode(int statusCode)
        {
            
            int statCode = (int)_scenarioContext.Get<IRestResponse>("restResponse").StatusCode;
            //statCode.Should().Be(statusCode);
            Assert.AreEqual(statusCode, statCode, "Status code is not " + statusCode);
        }

        [Then(@"the header should contain")]
        public void ThenTheHeaderShouldContain(Table table)
        {
            // Creating a dictionary and adding all headers and their values
            Dictionary<string, string> HeadersList = new Dictionary<string, string>();
            IRestResponse restResponse = _scenarioContext.Get<IRestResponse>("restResponse");
            foreach (var KeyPairs in from item in restResponse.Headers
                                     let KeyPairs = item.ToString().Split('=')
                                     select KeyPairs)
            {
                HeadersList.Add(KeyPairs[0], KeyPairs[1]);
            }

            foreach (TableRow row in table.Rows)
            {
                Assert.AreEqual(row[1], HeadersList[row[0]], row[0] +" not matching");
            }
                
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
           
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
           
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
           
        }
    }
}
