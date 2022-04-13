function getAjaxPage(url, idHtml,address)
{

    jQuery.ajax({
                url: url,
                data: address,
                type: "POST",
                success: function (callback) {
                    jQuery("#" + idHtml).html(callback);
    
                    if (address!=null)
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

function PageAjaxTransition(ajaxUrl,address)
{

    var addressJson={"address":address};

    var thisPage=window.location.pathname+window.location.search;

    if (address==null)
    {
        SetBackground("default");
        getAjaxPage(/AjaxPageTransition/+ajaxUrl, "MainFrame");

        const transitionUrl="/home/"+ajaxUrl;
        
        if (thisPage!==transitionUrl)
            history.pushState({'PageName': ajaxUrl}, null, transitionUrl);
    }
    else 
    {
        ScrollNumber=2;
        getAjaxPage(/AjaxPageTransition/+ajaxUrl, "MainFrame",addressJson);

        const transitionUrl="/home/"+ajaxUrl+"?address="+address;
        
        if (thisPage!==transitionUrl)
            history.pushState({'PageName': ajaxUrl,'address':address}, null, transitionUrl);
        
            
        
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
                    PageAjaxTransition(namePage,userAddress);
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
        PageAjaxTransition(event.state.PageName,event.state.address,true)
    }

};