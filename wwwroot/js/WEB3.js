window.userAddress = null;
window.onload = async () => {
    // Init Web3 connected to ETH network
    if (window.ethereum) 
    {
        window.web3 = new Web3(window.ethereum);
    } 
    else 
    {
        hidden("InstallingMetamask",false);
        alert("No ETH brower extension detected.");
    }

    // Load in Localstore key
    window.userAddress = window.localStorage.getItem("userAddress");
    showWeb3Net();
};

function hidden(id,isHidden)
{
    if (isHidden)
    {
        document.getElementById(id).classList.add("hidden");
    }
    else
    {
        document.getElementById(id).classList.remove("hidden");
    }
}

window.ethereum.on('networkChanged', function(networkId)
{
    showWeb3Net();
});

function IsAuthorizationWeb3()
{
    try 
    {
        if (window.userAddress.length!=null)
        {
            return true;
        }   
    }
    catch (e) 
    {
        return false;
    }
    
   
}
async function SetNetName(netID) 
{
    var id = await web3.eth.net.getId();
    if (id==80001)
    {
        document.getElementById("web3NetName").innerText="Polygon mumbai";
        document.getElementById("web3NetImg").src="/img/polygon-.svg";
        
    }
    else if(id==137)
    {
        document.getElementById("web3NetName").innerText="Polygon mainnet"
        document.getElementById("web3NetImg").src="/img/polygon-.svg";
    }
    else 
    {
        document.getElementById("web3NetName").innerText="Not Polygon net"
        document.getElementById("web3NetImg").src="/img/X.png";
    }
}


async function showWeb3Net() 
{
    if (!window.userAddress) 
    {
        hidden("web3Net",true);
        hidden("logoutButton",true);
        hidden("getContractInfo",true);
        hidden("btnLoginWithEth",false);
        
        return false;
    }
    
    // document.getElementById("userAddress").innerText = `ETH Address: ${truncateAddress(window.userAddress)}`;
    hidden("web3Net",false);
    hidden("logoutButton",false);
    hidden("getContractInfo",false);
    hidden("btnLoginWithEth",true);
   
    await SetNetName(await web3.eth.net.getId());

}


function logout() 
{
    window.userAddress = null;
    window.localStorage.removeItem("userAddress");
    showWeb3Net();
}


async function loginWithEth() 
{
    if (window.web3)
    {
        try 
        {
           
            const selectedAccount = await window.ethereum
                .request
                ({
                    method: "eth_requestAccounts",
                })
                .then((accounts) => accounts[0])
                .catch(() => 
                {
                    throw Error("No account selected!");
                });
            window.userAddress = selectedAccount;
            window.localStorage.setItem("userAddress", selectedAccount);
            showWeb3Net();
        } catch (error) 
        {
            console.error(error);
        }
    } else 
    {
        alert("MetaMask not installed.");
    }
}



const CONTRACT_ADDRESS = '0x603359F21E704B5b06B8F796b4Dd89f6e733f7f3';
async function SendUserIdSmartContract()
{
   
    const contract = new window.web3.eth.Contract(window.ABI, CONTRACT_ADDRESS);

    const symbol = await contract.methods.AddVerifyProfile(userId).send({ from: window.userAddress,value: web3.utils.toWei("0.0001", "ether") });


    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    console.log(symbol);
}

window.ABI = [{"inputs":[{"internalType":"uint256","name":"verificationCost","type":"uint256"}],"stateMutability":"payable","type":"constructor"},{"inputs":[{"internalType":"string","name":"Titles","type":"string"},{"internalType":"string","name":"Body","type":"string"},{"internalType":"bool","name":"Important","type":"bool"},{"internalType":"bool","name":"IsDonate","type":"bool"},{"internalType":"string","name":"DonateValue","type":"string"},{"internalType":"address","name":"PublicAddress","type":"address"},{"internalType":"uint256","name":"StageImplementation","type":"uint256"}],"name":"AddDonateGoal","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"UserID","type":"string"}],"name":"AddVerifyProfile","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"uint256","name":"goalId","type":"uint256"},{"internalType":"uint256","name":"status","type":"uint256"}],"name":"ChangeGoalStatus","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"uint256","name":"goalId","type":"uint256"},{"internalType":"bool","name":"important","type":"bool"}],"name":"DoImportant","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[],"name":"allGoals","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"allVerificationUser","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"price","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"withdraw","outputs":[],"stateMutability":"nonpayable","type":"function"}]

