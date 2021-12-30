namespace LifeGoals
{
    public class appSettings
    {
        public static string ContractAddressVerification = "0x603359F21E704B5b06B8F796b4Dd89f6e733f7f3";

        public static string ContractAbiVerification =
            "[{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"verificationCost\",\"type\":\"uint256\"}]," +
            "\"stateMutability\":\"payable\",\"type\":\"constructor\"},{\"inputs\":[{\"internalType\":\"string\"," +
            "\"name\":\"Titles\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"Body\",\"type\":\"string\"}" +
            ",{\"internalType\":\"bool\",\"name\":\"Important\",\"type\":\"bool\"},{\"internalType\":\"bool\",\"name\":" +
            "\"IsDonate\",\"type\":\"bool\"},{\"internalType\":\"string\",\"name\":\"DonateValue\",\"type\":\"string\"}," +
            "{\"internalType\":\"address\",\"name\":\"PublicAddress\",\"type\":\"address\"},{\"internalType\":\"uint256\"," +
            "\"name\":\"StageImplementation\",\"type\":\"uint256\"}],\"name\":\"AddDonateGoal\",\"outputs\":[],\"stateMutability\"" +
            ":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"UserID\",\"type\":\"string\"}]," +
            "\"name\":\"AddVerifyProfile\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\"" +
            ":\"uint256\",\"name\":\"goalId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"status\",\"type\":\"uint256\"}]," +
            "\"name\":\"ChangeGoalStatus\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\"" +
            ":\"uint256\",\"name\":\"goalId\",\"type\":\"uint256\"},{\"internalType\":\"bool\",\"name\":\"important\",\"type\":\"bool\"}],\"name\":" +
            "\"DoImportant\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"allGoals\",\"outputs\"" +
            ":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":" +
            "[],\"name\":\"allVerificationUser\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}]," +
            "\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"price\",\"outputs\":[{\"internalType\":\"uint256\"," +
            "\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"withdraw\"" +
            ",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";


    }
}