//first page is loaded along with the page
var ScrollNumber=2;


function GoalDivEmpty()
{
    if ($('#allGoals').find('*').length == 0)
        return true;
    else
        return false;

}


function GoalsLoadingOnScroll(scrollNumber)
{
    document.getElementById('ScrollNumber').value=scrollNumber;
    updateForm("Scroll");

    console.log("pg "+scrollNumber);

    ScrollNumber=scrollNumber+1;

}


window.onscroll = function () {

    new Promise(r => setTimeout(r, 350));
    var clientHeight = document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
    var documentHeight = document.documentElement.scrollHeight ? document.documentElement.scrollHeight : document.body.scrollHeight;
    var scrollTop = window.pageYOffset ? window.pageYOffset : (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);

    if ((documentHeight - 10 - clientHeight) <= scrollTop && GoalDivEmpty()===false)
    {

        GoalsLoadingOnScroll(ScrollNumber);

    }
}
function UpdateScrollView()
{

    GoalsDiveClear();
    GoalsLoadingOnScroll(1);

}