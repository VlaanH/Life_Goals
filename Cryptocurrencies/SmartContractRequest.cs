using System.Threading.Tasks;
using Nethereum.Web3;
namespace LifeGoals.Cryptocurrencies
{
    public class SmartContractRequest : polygonMumbai
    {
        
        public async Task<string> GetStringFunction(string contractAddress,string abi,string nameFunction)
        {
            var web3 = new Web3(webUrl);

            
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var function = contract.GetFunction(nameFunction);
            return await function.CallAsync<string>();

        }
    }

    
}