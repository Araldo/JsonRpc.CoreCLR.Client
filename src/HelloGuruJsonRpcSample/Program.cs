using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using JsonRpc.CoreCLR.Client;

namespace HelloGuruJsonRpcSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = CallTestService();
            test.Wait();
        }

        public static async Task CallTestService()
        {
            Uri rpcEndpoint = new Uri("http://gurujsonrpc.appspot.com/guru");
            JsonRpcWebClient rpc = new JsonRpcWebClient(rpcEndpoint);

            var response = await rpc.InvokeAsync<JValue>("guru.test", new string[]
            {
                "World"
            });

            System.Console.WriteLine("RPC Reply: {0}", response.Result);
        }
    }
}