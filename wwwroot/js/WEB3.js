window.userAddress = null;
window.onload = async () => {
    // Init Web3 connected to ETH network
    owner(false);
    if (window.ethereum) 
    {
        window.web3 = new Web3(window.ethereum);
        // Load in Localstore key
        window.userAddress = window.localStorage.getItem("userAddress");
        await ShowWeb3NetAndAccount();
        window.ethereum.on('accountsChanged', function (accounts)
        {
            loginWithEth();
        });
        window.ethereum.on('networkChanged', function()
        {
            ShowWeb3NetAndAccount();
        });
        InitContract();
    } 
    
    RedirectToYourPage();
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
async function SetNetName() 
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


async function ShowWeb3NetAndAccount() 
{
    if (!window.userAddress) 
    {
        hidden("web3Net",true);
        hidden("logoutButton",true);
       
        hidden("btnLoginWithEth",false);
        
        return false;
    }
    
    // document.getElementById("userAddress").innerText = `ETH Address: ${truncateAddress(window.userAddress)}`;
    hidden("web3Net",false);
    hidden("logoutButton",false);
    
    hidden("btnLoginWithEth",true);
   
    await SetNetName(await web3.eth.net.getId());

}


async function logout() 
{
    window.userAddress = null;
    window.localStorage.removeItem("userAddress");
    
    await ShowWeb3NetAndAccount();
    RedirectToYourPage();
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
            await ShowWeb3NetAndAccount();
        } 
        catch (error) 
        {
            console.error(error);
        } 
        
        RedirectToYourPage();
       
    } 
    else 
    {
       alert("MetaMask not installed.");
    }
}




function pageAccessControl()
{
    if (PageName!=null)
    {
        if (PageName=="Profile")
        {
            if (AddressPage==userAddress)
            {
                console.log("owner");
                owner(true);
            }
            else
            {
                owner(false);
            }
        }
        else if(PageName=="Feed") 
        {
            //your goals are not displayed in the feed yet
            owner(false);
        }
        
    }
    
}


function RedirectToYourPage()
{
    if (typeof StatusPage !== 'undefined')
    {
        if(StatusPage==="non" && IsAuthorizationWeb3()===false)
        {
            PageAjaxTransition("Register");
        }
        else if (StatusPage==="non")
        {
            PageAjaxTransition(PageName,userAddress);
        }
        else if(StatusPage==="NotFound" & userAddress==AddressPage)
        {
            PageAjaxTransition("Register");
        }
        else
        {
            pageAccessControl();
            if (StatusPage!=="NotFound")
            {
                GetSubscriptionStatus();
            }
            
        }

        
    }
}


const CONTRACT_ADDRESS = '0xFB982341b86028E4dC9EbADc70fa7f01263D5479';
window.ABI = [{"inputs":[{"internalType":"uint256","name":"verificationCost","type":"uint256"}],"stateMutability":"payable","type":"constructor"},{"inputs":[{"internalType":"string","name":"Titles","type":"string"},{"internalType":"string","name":"Body","type":"string"},{"internalType":"string","name":"DonateValue","type":"string"},{"internalType":"address","name":"PublicAddress","type":"address"}],"name":"AddDonateGoal","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"Titles","type":"string"},{"internalType":"string","name":"Body","type":"string"}],"name":"AddGoal","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"Titles","type":"string"},{"internalType":"string","name":"Body","type":"string"}],"name":"AddMessage","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"uint256","name":"goalId","type":"uint256"},{"internalType":"uint256","name":"status","type":"uint256"}],"name":"ChangeGoalStatus","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"nickname","type":"string"},{"internalType":"string","name":"Description","type":"string"},{"internalType":"string","name":"Background","type":"string"},{"internalType":"string","name":"Imag","type":"string"}],"name":"CreateAccount","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"uint256","name":"goalId","type":"uint256"},{"internalType":"bool","name":"important","type":"bool"}],"name":"DoImportant","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"background","type":"string"}],"name":"SetBackground","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"description","type":"string"}],"name":"SetDescription","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"string","name":"imag","type":"string"}],"name":"SetImag","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"address","name":"subscribeTo","type":"address"}],"name":"SubscribeToUser","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[{"internalType":"address","name":"unfollowTo","type":"address"}],"name":"UnfollowUser","outputs":[],"stateMutability":"payable","type":"function"},{"inputs":[],"name":"allGoals","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"allUserSubscriptions","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"allUsers","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"price","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"withdraw","outputs":[],"stateMutability":"payable","type":"function"}]

var contract;
function InitContract()
{
    contract = new window.web3.eth.Contract(window.ABI, CONTRACT_ADDRESS);
}

async function Web3CreateAccount(nickname,description,background,image)
{
    
    const symbol = await contract.methods.CreateAccount(nickname,description,background,image).send({ from: window.userAddress,value: web3.utils.toWei("100000000000", "wei")});

    await new Promise(r => setTimeout(r, 2100));
    
    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    window.location.href = "/?address="+userAddress;
    console.log(symbol);
}

async function Web3ChangeGoalStatus(id,status,ajaxUpdate)
{
    
    const symbol = await contract.methods.ChangeGoalStatus(id,status).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));
    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    updateForm(ajaxUpdate);

    console.log(symbol);
    
}
async function Web3CDoImportant(id,status,ajaxUpdate)
{
    
    const symbol = await contract.methods.DoImportant(id,status).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));
    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    updateForm(ajaxUpdate);
    updateGoalLine();
    console.log(symbol);

}

async function Web3AddGoal(Titles,Body)
{
    const symbol = await contract.methods.AddGoal(Titles,Body).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));
    
    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);

    UpdateScrollView();

    console.log(symbol);

}
async function Web3AddMessage(Titles,Body)
{
    const symbol = await contract.methods.AddMessage(Titles,Body).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);

    UpdateScrollView();

    console.log(symbol);

}

async function Web3AddDonateGoal(titles,body,donateValue,publicAddress) 
{
    const symbol = await contract.methods.AddDonateGoal(titles,body,donateValue,publicAddress).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);

    UpdateScrollView();
  
    
    console.log(symbol);
}

async function Web3SetBackground(background) 
{
    const symbol = await contract.methods.SetBackground(background).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);

    console.log(symbol);
}

async function Web3SetDescription(description)
{
    const symbol = await contract.methods.SetDescription(description).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);

    console.log(symbol);
}
async function Web3SetImag(imag)
{
    const symbol = await contract.methods.SetImag(imag).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
}
async function Web3SubscribeToUser(subscribeTo) 
{
    const symbol = await contract.methods.SubscribeToUser(subscribeTo).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));
    
    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    
    GetSubscriptionStatus();

    console.log(symbol);
}
async function Web3UnfollowUser(unfollowTo)
{
    const symbol = await contract.methods.UnfollowUser(unfollowTo).send({ from: window.userAddress});

    await new Promise(r => setTimeout(r, 2100));

    alert(`Contract ${CONTRACT_ADDRESS} Symbol: ${symbol.status}`);
    
    GetSubscriptionStatus();

    console.log(symbol);
}