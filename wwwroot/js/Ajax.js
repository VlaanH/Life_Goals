
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
    
    getAjaxRequest('/Home/GetSubscriptionStatus','User-All-Data',data,'replace',false)

}

function GetScroll(scrollNumber,userAddress) 
{
  
    var data = {"scrollNumber": scrollNumber,"address":userAddress};
    
    getAjaxRequest('/Home/UpdateGoals','allGoals',data,'after',true)   
    
}

function GetSubscribers()
{

    var data = {"address":AddressPage};

    getAjaxRequest('/Home/GetSubscribers','Update-User-dialog',data,'replace',false)

}

function GetSubscriptions()
{
    var data = {"address":AddressPage};

    getAjaxRequest('/Home/GetSubscriptions','Update-User-dialog',data,'replace',false)

}