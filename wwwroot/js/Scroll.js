//first page is loaded along with the page
var ScrollNumber=2;


function GoalDivEmpty()
{
    if ($('#allGoals').find('*').length == 0)
        return true;
    else
        return false;

}

var DoubleScrollProtection=false;
function GoalsLoadingOnScroll(scrollNumber)
{
    
    GetScroll(scrollNumber,AddressPage);
    
    console.log("pg "+scrollNumber);

    ScrollNumber=scrollNumber+1;

   
}

window.onscroll = function () {

   
    
    var clientHeight = document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
    var documentHeight = document.documentElement.scrollHeight ? document.documentElement.scrollHeight : document.body.scrollHeight;
    var scrollTop = window.pageYOffset ? window.pageYOffset : (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);

    if ((documentHeight - 100 - clientHeight) <= scrollTop && GoalDivEmpty()===false && DoubleScrollProtection===false)
    {     
        DoubleScrollProtection=true;

        GoalsLoadingOnScroll(ScrollNumber);
        
    }
    
  
}

function UpdateScrollView()
{

    GoalsDiveClear();
    GoalsLoadingOnScroll(1);

}