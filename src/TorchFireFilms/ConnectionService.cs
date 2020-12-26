using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorchFireFilms
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConfiguration _configuration;

        public ConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDefaultConnectionString()
        {
            return _configuration.GetConnectionString("Default");
        }
    }
}
