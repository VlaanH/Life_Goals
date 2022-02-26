namespace lifeGoals.Cryptocurrencies.Ethereum
{
    public static class AddressManagement
    {
        public static string AddressNormalization(string badAddress)
        {
            if (badAddress != null)
            {
                badAddress = badAddress.ToLower();
                if (badAddress.Length==42)
                {
                    badAddress=badAddress.Remove(0,2);
                }
            }
           

            return badAddress;
        }

    }
}