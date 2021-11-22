
function updateGoalLine()
{
    
    $( "#goalsLineForm" ).submit();
    
}
function CopyReefLink(id) 
{

  
    var copyText = id;

    /* Select the text field */
    copyText.select();

    /* Copy the text inside the text field */
    document.execCommand("copy");

}

