﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;

namespace AutomatedTests
{
    public class TestForTowns
    {
        [Fact]
        public async Task Towns_TransitionToEndPoint_GettingListOfTowns()
        {
            //arrange
            using var client = new HttpClient();

            var basePath = AppContext.BaseDirectory;
            var path = basePath.Substring(0, basePath.Length - 18);

            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var baseAdrress = config.GetSection("AppSettings").GetSection("BaseAddress").Value;

            var requestContent = new StringContent("{\"Email\" : \"admnexadel@gmail.com\", \"Password\" : \"Qwerty123!\"}", Encoding.UTF8, "application/json");

            var responseFromlogin = await client.PostAsync(baseAdrress + "login", requestContent);
            var token = responseFromlogin.Content.ReadAsStringAsync().Result;

            token = token.Substring(0, token.Length - 2).Remove(0, 10);

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseAdrress + "towns"),
                Headers = {
                    { HttpRequestHeader.Authorization.ToString(), "bearer " + token },
                },
            };

            //act
            var response = await client.SendAsync(httpRequestMessage);
            var result = await response.Content.ReadAsStringAsync();

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("townName", result);
        }
    }
}