using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Services
{
    public interface IGreeter
    {
        string GetWelcomeMessage();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
                
        }
        public string GetWelcomeMessage()
        {
            return _configuration["Greeting"];
        }
    }
}
