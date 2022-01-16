function imageBinding(input,ImageID)
{

    var img = new Image();
    img.src = input.value;
    img.onload = function(){document.getElementById(ImageID).src = input.value};
    img.onerror = function(){document.getElementById(ImageID).src='/UserImages/standardUser.png'};
    
}
function DoImportant(id,status,ajaxUpdate) 
{
    Web3CDoImportant(id,status,ajaxUpdate);
}
function SetDescription()
{
    var description = document.getElementById('SettingsDescription').value.replace(/"/g, "“");
    Web3SetDescription(description);
    
}
function SetUserBackground()
{
    var imag = document.getElementById('SettingsBackground').value;

    Web3SetBackground(imag);
}
function SetImag() 
{
    var imag = document.getElementById('SettingsImage').value;
    
    Web3SetImag(imag);
}

function AddGoal()
{
    var isGoal= document.getElementById('isGoal').checked;
    var isDonate = document.getElementById('isDonate').checked;
    var title = document.getElementById('CreateGoalTitle').value.replace(/"/g, "“");
    var body = document.getElementById('CreateGoalBody').value.replace(/"/g, "“");
    var donateValue = document.getElementById('CreateGoalDonateValue').value;
    var address = document.getElementById('CreateGoalAddress').value;
    if (isGoal)
    {
        if (isDonate)
        {
            Web3AddDonateGoal(title,body,donateValue,address,"create_goal")
        }
        else
        {
            Web3AddGoal(title,body,"create_goal");
        }
    }
    else 
    {
        Web3AddMessage(title,body,"create_goal");
    }
    
}


function CreateAccount() 
{
   var nickname = document.getElementById("RegNickname").value.replace(/"/g, "“");
   var background = document.getElementById("RegBackground").value.replace(/"/g, "“");
   var profileImage = document.getElementById("RegProfileImage").value.replace(/"/g, "“");
   var description = document.getElementById("RegDescription").value.replace(/"/g, "“");
 
    
   Web3CreateAccount(nickname,description,background,profileImage);
}
function ChangeGoalStatus(id,status,ajaxUpdate) 
{
    Web3ChangeGoalStatus(id,status,ajaxUpdate);
    
}
function GoalLoadingOnScroll(scrollNumber)
{
    document.getElementById('ScrollNumber').value=scrollNumber;
    updateForm("Scroll");
    ScrollNumber++;
}
var ScrollNumber=1;

window.onscroll = function () {
    
    new Promise(r => setTimeout(r, 350));
    var clientHeight = document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
    var documentHeight = document.documentElement.scrollHeight ? document.documentElement.scrollHeight : document.body.scrollHeight;
    var scrollTop = window.pageYOffset ? window.pageYOffset : (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);

    if ((documentHeight - 10 - clientHeight) <= scrollTop) 
    {
       
        GoalLoadingOnScroll(ScrollNumber);

    }
}

function updateGoalLine()
{
    
    $( "#goalsLineForm" ).submit();
    
}
(function($) {
    'use strict';

    var $accountDeleteDialog = $('#Donate-dialog');

    $('#cancel').on('click', function() {
        $accountDeleteDialog[0].close();
    });

})(jQuery);

function showDialog()
{

    $( "#Donate-dialog" )[0].showModal();

}

var qrcode = new QRCode("qrcodeAddress", {
   
    width: 140,
    height: 140,
    colorDark : "#000000",
    colorLight : "#ffffff",
    
});;

function makeCode ()
{
    var elText = document.getElementById("Address");
    qrcode.makeCode(elText.value);
    
}

makeCode();

function getETHBalance(address,goalID,donateValue,maxValue)
{

    if (typeof web3 !== 'undefined') 
    {
        web3 = new Web3(web3.currentProvider);
    } 
    else 
    {
        var web3 = new Web3('https://rinkeby.infura.io/v3/755e3f58cf2e49128530c4058b2bdb04');
    }

    var balance;
     web3.eth.getBalance(address, function(err, result)
     {
        if (err) 
        {
            console.log(err)
        } else
        {
            var balance = web3.utils.fromWei(result, "ether");
            if (balance.length>11)
            {
                balance= balance.substring(0,11);
                
                if (balance==0)
                {
                    balance=0; 
                }
                
                
            }
            
           
            
            document.getElementById(`value_progress_${goalID}`).innerHTML=balance+"ETH";


            
            var procent = `${GetPercentDonate(balance,donateValue)}`;
            var procentMaxValue = `${GetPercentDonate(maxValue,donateValue)}`;
            
            document.getElementById(`progress_percent_${goalID}`).innerHTML=(procent+"%");

        }
         
         
        document.getElementById(`progress-bar-Max-Value_${goalID}`).style.width=(procentMaxValue-procent)+"%";
        document.getElementById(`progress-bar_${goalID}`).style.width=procent+"%";
    })

 
  
}

function GetPercentDonate(balance,donateValue)
{
    if (donateValue!=0)
    {
        return ((balance / donateValue * 100 ).toString()).substring(0,5);
    }
    else 
    {
        return 0;
    }
    
}
function dependencyOnCheckbox(chbox,itemId)
{
    
    if (chbox.checked)
    {
        document.getElementById(itemId).hidden=false;
    }
    else
    {
        document.getElementById(itemId).hidden=true;
       
    }
    
}
function ArrayHiddenClass(class_,isHidden)
{
    if (isHidden)
    {
        var goalPointsStatus = document.getElementsByClassName(class_);

        for (i=0;i<goalPointsStatus.length;i++)
        {
            goalPointsStatus[i].classList.add("hidden");
        }
    }
    else 
    {
        var goalPointsStatus = document.getElementsByClassName(class_);

        for (i=0;i<goalPointsStatus.length;i++)
        {
            goalPointsStatus[i].classList.remove("hidden");
        } 
    }
}

async function owner(isOwner) 
{
    if (isOwner)
    {
       
        hidden("CreateGoal",false);
        hidden("settingsProfile",false);
        ArrayHiddenClass("goalPoints",false);
        ArrayHiddenClass("ImportantButton",false);
        ArrayHiddenClass("ImportantSvg",true);
        
    }
    else 
    {
        hidden("CreateGoal",true);
        hidden("settingsProfile",true);
        ArrayHiddenClass("goalPoints",true);
        ArrayHiddenClass("ImportantButton",true);
        ArrayHiddenClass("ImportantSvg",false);
        
    }
}

function SetQrAddress(address) 
{

    document.getElementById('Address').value=address;
   
    document.getElementById('addressText').innerHTML=address;

    document.getElementById('addressTextType').innerHTML="Ethereum address:";
    document.getElementById('MainDialog').innerHTML="Donate";
    document.getElementById('DialogDiscript').innerHTML="It is an Ethereum cryptocurrency wallet. Ethereum is the community-run technology powering the cryptocurrency ether (ETH) and thousands of decentralized applications."
    makeCode()


}
function SetQrPrivateKey(address)
{

    document.getElementById('Address').value=address;

    document.getElementById('addressText').innerHTML=address;

    document.getElementById('addressTextType').innerHTML="Ethereum PrivateKey:";
    document.getElementById('MainDialog').innerHTML="PrivateKey";
    document.getElementById('DialogDiscript').innerHTML="It is an Ethereum cryptocurrency wallet. Ethereum is the community-run technology powering the cryptocurrency ether (ETH) and thousands of decentralized applications."

    makeCode()


}


function SetBackground(image)
{
    document.body.style.backgroundImage=`url('${image}')`;
}
function updateForm(id)
{

    $( `#${id}` ).submit();
    
}