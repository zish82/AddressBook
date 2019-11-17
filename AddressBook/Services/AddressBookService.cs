using System;

namespace Tests
{
    public class AddressBookService
    {
        private IGetAddressBook getAddressBookService;

        public AddressBookService(IGetAddressBook getAddressBookService)
        {
            this.getAddressBookService = getAddressBookService;
        }

        public int GetNumberOfMales()
        {
            return 0;
        }
    }
}