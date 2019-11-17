using AddressBook.Enums;
using System.Linq;

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
            var addressBooks = getAddressBookService.GetAddressBooks();
            return addressBooks.Count(x => x.Gender == GenderType.Male);
        }
    }
}