using AddressBook.Enums;
using System;
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

        public Person OldestPerson()
        {
            var addressBooks = getAddressBookService.GetAddressBooks();
            return addressBooks.OrderBy(x => x.DateOfBirth).First();
        }

        /// <summary>
        /// This method only checks if person1 is older than person2, not vice versa
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns></returns>
        public object HowManyDaysOlder(string person1, string person2)
        {
            var addressBooks = getAddressBookService.GetAddressBooks();
            var p1 = addressBooks.Single(x => x.Name == person1);
            var p2 = addressBooks.Single(x => x.Name == person2);

            var days = (p2.DateOfBirth - p1.DateOfBirth).Days;

            return days > 0 ? days : 0;
        }
    }
}