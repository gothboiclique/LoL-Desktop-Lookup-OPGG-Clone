using RiotNet;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cain_s_League_Tool
{
    
    public class RiotClientSetUpClass
    { 
        public static IRiotClient client = new RiotClient(new RiotClientSettings
        {
            ApiKey = "RGAPI-d8a114da-7037-462e-b85a-50d7d6ccfb0b"
        });
    }
}
