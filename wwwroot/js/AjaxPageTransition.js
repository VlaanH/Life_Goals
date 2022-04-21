function getAjaxPage(url, idHtml,address)
{

    jQuery.ajax({
                url: url,
                data: address,
                type: "POST",
                success: function (callback) {
                    jQuery("#" + idHtml).html(callback);
                    
                    if (typeof address !== 'undefined')
                        if (address.address!=null)
                        {
                            pageAccessControl();
                            GetSubscriptionStatus();
                        }
                    
                },
                error: function () {
                    alert("Error ger response from server");
                }
    
            });
}
function AddHistory(transitionUrl,dataHistory) 
{
    var thisPage=window.location.pathname+window.location.search;
    
    if (thisPage!==transitionUrl)
        history.pushState(dataHistory, null, transitionUrl);
    else
    {
        document.addEventListener("DOMContentLoaded", () => {
            history.replaceState(dataHistory, null, transitionUrl);
        });

    }
}


function PageAjaxTransition(ajaxUrl,address,isAddressPage=false)
{

    var addressJson={"address":address};
    
    var dataHistory,transitionUrl;
    
    if (isAddressPage===false)
    {
        SetBackground("default");
        getAjaxPage(/AjaxPageTransition/+ajaxUrl, "MainFrame");

        transitionUrl="/home/"+ajaxUrl;

        dataHistory={'PageName': ajaxUrl};
        
    }
    else 
    {
        ScrollNumber=2;
        getAjaxPage(/AjaxPageTransition/+ajaxUrl, "MainFrame",addressJson);

        transitionUrl="/home/"+ajaxUrl+"?address="+address;

        dataHistory={'PageName': ajaxUrl,'address':address};
        
    }
    
    
    if (isAddressPage)
    {
        if (address!=null)
        {
            AddHistory(transitionUrl,dataHistory,isAddressPage)
        }
    }
    else 
    {
        AddHistory(transitionUrl,dataHistory,isAddressPage)
    }
   
    
    return false;
}

$(window).on('load', function()
{

    $('a').bind('click', function()
    {
        var namePage = $(this).attr("page");
        var isAddressTeg=$(this).attr("Address");
        
        if (namePage!=null)
        {
            
            if (isAddressTeg==="true")
            {
                if (userAddress!=null)
                    PageAjaxTransition(namePage,userAddress,true);
                else
                    PageAjaxTransition("Register"); 
                    
            }
            else
            {
                PageAjaxTransition(namePage);
            }
        
        }
        
        return false;   
    });
   
});
window.onpopstate = function(event)
{

    if (event.state==null)
    {
        window.location=document.location;

    }
    else
    {
        SetBackground("default");
        PageAjaxTransition(event.state.PageName,event.state.address,true)
    }

};