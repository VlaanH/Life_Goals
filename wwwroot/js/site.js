
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

function getETHBalance(address,goalID,donateValue)
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
     web3.eth.getBalance(address, function(err, result) {
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
            
            console.log(web3.utils.fromWei(result, "ether") + " ETH")
            
            document.getElementById(`value_progress_${goalID}`).innerHTML=balance+"ETH";


            
            var procent = `${GetPercentDonate(balance,donateValue)}`;
            document.getElementById(`progress_percent_${goalID}`).innerHTML=procent;

        }document.getElementById(`progress-bar_${goalID}`).style.width=procent;
    })

 
  
}

function GetPercentDonate(balance,donateValue)
{
    if (donateValue!=0)
    {
        return (balance / donateValue * 100 )+"%";
    }
    else 
    {
        return 0+"%";
    }
   

}


function SetQrAddress(address) 
{

    document.getElementById('Address').value=address;
   
    document.getElementById('addressText').innerHTML=address;

    document.getElementById('addressTextType').innerHTML="Ethereum address:";
    document.getElementById('MainDialog').innerHTML="Donate";
    document.getElementById('DialogDiscript').innerHTML="You are about to close your account. This action is irreversible. It will permanently delete your account along with its associated data. Are you sure you want to continue?";
    
    makeCode()


}
function SetQrPrivateKey(address)
{

    document.getElementById('Address').value=address;

    document.getElementById('addressText').innerHTML=address;

    document.getElementById('addressTextType').innerHTML="Ethereum PrivateKey:";
    document.getElementById('MainDialog').innerHTML="PrivateKey";
    document.getElementById('DialogDiscript').innerHTML="You are about to close your account. This action is irreversible. It will permanently delete your account along with its associated data. Are you sure you want to continue?";

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