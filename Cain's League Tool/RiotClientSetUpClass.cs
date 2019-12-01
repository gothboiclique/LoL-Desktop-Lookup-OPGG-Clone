using RiotNet;

namespace Cain_s_League_Tool
{
    
    public class RiotClientSetUpClass
    { 
        public static IRiotClient client = new RiotClient(new RiotClientSettings
        {
            ApiKey = "RGAPI-b4103816-b805-4577-a959-1293abe6e630"
        });
    }

    // https://developer.riotgames.com/
    // Regenerate a new key every 24 Hours :)
}
