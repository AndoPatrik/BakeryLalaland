using BakeryLalaland.Model;

namespace BakeryLalaland.Interfaces
{
    class CurrentUserSingleton
    {
        public static Customer _customer;

        private static CurrentUserSingleton Instance { get; set; }

        private CurrentUserSingleton()
        {
            _customer = new Customer();
        }

        public static CurrentUserSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CurrentUserSingleton();
            }

            return Instance;
        }

        public void SetCurrentUser(Customer customer)
        {
            _customer = customer;
        }

        public string GetName()
        {
            return _customer.Name;
        }

        public string GetId()
        {
            return _customer.Id;
        }

        public string GetPassword()
        {
            return _customer.Password;
        }

        public string GetConfrimPassword()
        {
            return _customer.ConfirmPassword;
        }

        public string GetCity()
        {
            return _customer.City;
        }

        public string GetStreet()
        {
            return _customer.Street;
        }

        public int GetStreetNumber()
        {
            return _customer.Number;
        }

        public int GetPostalCode()
        {
            return _customer.PostalCode;
        }

        public int GetPhoneNum()
        {
            return _customer.PhoneNumber;
        }
    }
}
