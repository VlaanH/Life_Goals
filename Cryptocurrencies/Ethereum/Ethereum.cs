using System.Globalization;
using System.Threading.Tasks;
using Nethereum.RPC.Eth;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace LifeGoals.Cryptocurrencies
{
    public class Ethereum : Cryptocurrencies
    {
  

        public override string webUrl { get; set; }

        public override async Task<string> GetBalance(string publicAddress)
        {
            var publicKey = publicAddress;
            var web3 = new Nethereum.Web3.Web3(webUrl);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(publicKey);
            var etherAmount = Web3.Convert.FromWei(balance.Value);

            if (etherAmount.ToString().Length > 12)
            {
                return etherAmount.ToString(new CultureInfo("en-us")).Remove(12); 
            }
            else
            {
                return etherAmount.ToString(new CultureInfo("en-us"));
            }
            
        }

        public override CurrenciesKeyObject GenerateAddress()
        {
            EthECKey key = EthECKey.GenerateKey();

            return new CurrenciesKeyObject() {PrivateKey = key.GetPrivateKey(),PublicAddress = key.GetPublicAddress()};
        }
    }
}