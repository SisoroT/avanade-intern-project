using System;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;

namespace gavanade.function
{
    public static class price_table
    {
        private static readonly HttpClient client = new HttpClient();
        [FunctionName("price_table")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing request for database.");

            string result = "";
            string responseMessage = "";
            string searchString = "";
            string price = "";

            // create list with all states
            List<string> states = new List<string> { "Alaska", "Alabama", "Arkansas", "Arizona", "California", "Colorado", "Connecticut", "District of Columbia", "Delaware", "Florida", "Georgia", "Hawaii", "Iowa", "Idaho", "Illinois", "Indiana", "Kansas", "Kentucky", "Louisiana", "Massachusetts", "Maryland", "Maine", "Michigan", "Minnesota", "Missouri", "Mississippi", "Montana", "North Carolina", "North Dakota", "Nebraska", "New Hampshire", "New Jersey", "New Mexico", "Nevada", "New York", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Virginia", "Vermont", "Washington", "Wisconsin", "West Virginia", "Wyoming" };
            // create list with all national and state prices
            List<string> prices = new List<string>();

            int index = 0;
            log.LogInformation("Processing past prices.");

            // webscrape state averages page from AAA
            var response = await client.GetAsync(
                "https://gasprices.aaa.com/state-gas-price-averages/"
            );
            responseMessage = await response.Content.ReadAsStringAsync();

            // loop through AAA response and find each state average
            for (int i = 0; i < 51; i++)
            {
                // search for the state average in string returned from AAA
                searchString = "<td class=\"regular\" style=\"display: table-cell;\">$";
                index = responseMessage.IndexOf(searchString) + searchString.Length;

                // if searchstring not found, return an error
                if (index <= 0)
                {
                    log.LogInformation("Failed to find search string");
                    continue;
                }
                price = responseMessage.Substring(index);
                price = price.Substring(0, price.IndexOf(" ") - 1);
                // add each price to the prices list
                prices.Add(price);
                responseMessage = responseMessage.Substring(index);
            }
            log.LogInformation($"{prices.Count}");
            log.LogInformation($"{states.Count}");

            // combine state names and prices into one string
            for (int i = 0; i < prices.Count; i++)
            {
                result += $"{states[i]}`${prices[i]}`";
            }

            result = result.Substring(0, result.Length - 1);
            return new OkObjectResult(result);
        }
    }
}