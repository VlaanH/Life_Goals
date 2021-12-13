namespace LifeGoals
{
    public class appSettings
    {
        public static string ContractAddressVerification = "0xfb2d60378C4be18F6559f29352E29f62828e5e98";

        public static string ContractAbiVerification =
            " [{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"verificationCost\",\"type\":\"uint256\"}]," +
            "\"stateMutability\":\"payable\",\"type\":\"constructor\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"UserID\",\"type\":\"string\"}]," +
            "\"name\":\"VerifyProfile\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"}," +
            "{\"inputs\":[],\"name\":\"allUserID\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}]," +
            "\"stateMutability\":\"view\",\"type\":\"function\"}," +
            "{\"inputs\":[],\"name\":\"price\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}]," +
            "\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"withdraw\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";

        
        
    }
}