
function getAjaxRequest(url, idHtml,data,mode) 
{
    AjaxLocked=true;
    
    jQuery.ajax({
        url: url,
        data: data,
        type: "POST",
        
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
    
    getAjaxRequest('/Home/GetSubscriptionStatus','User-All-Data',data,'replace')

}

function GetScroll(scrollNumber,userAddress) 
{
  
    var data = {"scrollNumber": scrollNumber,"address":userAddress};
    
    getAjaxRequest('/Home/UpdateGoals','allGoals',data,'after')   
    
}
