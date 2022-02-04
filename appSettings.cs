namespace LifeGoals
{
    public class appSettings
    {
        public static string ContractAddressVerification = "0xFB982341b86028E4dC9EbADc70fa7f01263D5479";

        public static string ContractAbiVerification = 
            "[{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"verificationCost\",\"type\":\"uint256\"}]," +
            "\"stateMutability\":\"payable\",\"type\":\"constructor\"},{\"inputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"Titles\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Body\",\"type\":\"string\"}," +
            "{\"internalType\":\"string\",\"name\":\"DonateValue\",\"type\":\"string\"},{\"internalType\":\"address\"," +
            "\"name\":\"PublicAddress\",\"type\":\"address\"}],\"name\":\"AddDonateGoal\",\"outputs\":[]," +
            "\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"Titles\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Body\",\"type\":\"string\"}]," +
            "\"name\":\"AddGoal\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"Titles\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Body\",\"type\":\"string\"}],\"name\":\"AddMessage\"," +
            "\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"goalId\"," +
            "\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"status\",\"type\":\"uint256\"}],\"name\":\"ChangeGoalStatus\"," +
            "\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"nickname\"," +
            "\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Description\",\"type\":\"string\"},{\"internalType\":\"string\"," +
            "\"name\":\"Background\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Imag\",\"type\":\"string\"}]," +
            "\"name\":\"CreateAccount\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"}," +
            "{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"goalId\",\"type\":\"uint256\"},{\"internalType\":\"bool\"," +
            "\"name\":\"important\",\"type\":\"bool\"}],\"name\":\"DoImportant\",\"outputs\":[],\"stateMutability\":\"payable\"," +
            "\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"background\",\"type\":\"string\"}]," +
            "\"name\":\"SetBackground\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"description\",\"type\":\"string\"}],\"name\":\"SetDescription\",\"outputs\":[],\"stateMutability\":\"payable\"," +
            "\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"imag\",\"type\":\"string\"}],\"name\":\"SetImag\"," +
            "\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\"," +
            "\"name\":\"subscribeTo\",\"type\":\"address\"}],\"name\":\"SubscribeToUser\",\"outputs\":[],\"stateMutability\":\"payable\"," +
            "\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"unfollowTo\",\"type\":\"address\"}]," +
            "\"name\":\"UnfollowUser\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[]," +
            "\"name\":\"allGoals\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}]," +
            "\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"allUserSubscriptions\"," +
            "\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\"," +
            "\"type\":\"function\"},{\"inputs\":[],\"name\":\"allUsers\",\"outputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[]," +
            "\"name\":\"price\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}]," +
            "\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"withdraw\",\"outputs\":[]," +
            "\"stateMutability\":\"payable\",\"type\":\"function\"}]";

    }
}