var Controller="/"+"AjaxDataUpdate"
function getAjaxRequest(url, idHtml,data,mode,isScroll) 
{
    AjaxLocked=true;
    
    jQuery.ajax({
        url: url,
        data: data,
        type: "POST",
        async: true,
        success: function (callback) 
        {
            if (mode==='replace')
            {
                jQuery("#" + idHtml).html(callback);
            }
            else 
            {
                jQuery("#" + idHtml).append(callback);
            }
           if (isScroll)
           {
               DoubleScrollProtection=false;
           }
            
        },
        error: function () 
        {
            alert("Error ger response from server");
        }

    })
}

function GetSubscriptionStatus()
{
    
    var data = {"pageVisitor": userAddress,"address":AddressPage};
    
    getAjaxRequest(Controller+'/GetSubscriptionStatus','User-All-Data',data,'replace',false)

}

function GetScroll(scrollNumber,userAddress) 
{
  
    var data = {"scrollNumber": scrollNumber,"address":userAddress,"status":StatusPage};
    
    getAjaxRequest(Controller+'/UpdateGoals','allGoals',data,'after',true)   
    
}

function GetSubscribers()
{

    var data = {"address":AddressPage};

    getAjaxRequest(Controller+'/GetSubscribers','Update-User-dialog',data,'replace',false)

}

function GetSubscriptions()
{
    var data = {"address":AddressPage};

    getAjaxRequest(Controller+'/GetSubscriptions','Update-User-dialog',data,'replace',false)

}

function updateGoalLine() 
{
    var data = {"address":AddressPage};

    getAjaxRequest(Controller+'/GoalLineUpdate','goalsLine',data,'replace',false)
}