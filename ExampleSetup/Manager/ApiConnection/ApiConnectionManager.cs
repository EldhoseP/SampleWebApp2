using System;
namespace ExampleSetup.Manager.ApiConnection
{
    public interface ApiConnectionManager
    {
        global::System.Threading.Tasks.Task<global::ExampleSetup.Models.TokenResult> ReturnAPIKey(string api, String aquiredtoken);
    }
}
