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
            Web3AddDonateGoal(title,body,donateValue,address)
        }
        else
        {
            Web3AddGoal(title,body);
        }
    }
    else
    {
        Web3AddMessage(title,body);
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
function SubscribeToUser()
{
    Web3SubscribeToUser(AddressPage);
}
function UnfollowUser()
{
    Web3UnfollowUser(AddressPage);
}