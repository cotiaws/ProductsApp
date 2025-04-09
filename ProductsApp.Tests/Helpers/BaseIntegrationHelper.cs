using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Tests.Helpers
{
    public class BaseIntegrationHelper : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;

        public BaseIntegrationHelper(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
    }
}
