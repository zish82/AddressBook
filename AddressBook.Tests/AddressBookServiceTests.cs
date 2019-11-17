using AddressBook.Enums;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class AddressBookServiceTests
    {
        private List<Person> people;
        private const int DanaLaneYearsOld = 2;

        [SetUp]
        public void Setup()
        {
            people = new List<Person> {
                   new Person { Name = "John Snow", Gender = GenderType.Male, DateOfBirth = DateTime.Now},
                   new Person { Name = "Zee A", Gender = GenderType.Male, DateOfBirth = DateTime.Now},
                   new Person { Name = "Dana Lane", Gender = GenderType.Female, DateOfBirth = DateTime.Now.AddYears(-DanaLaneYearsOld)},
                   new Person { Name = "Chuk jackson", Gender = GenderType.Male, DateOfBirth = DateTime.Now}
            };
        }

        [Test]
        public void HowManyMalesAreInAddressBook()
        {
            var service = new Mock<IGetAddressBook>();
            service.Setup(x => x.GetAddressBooks()).Returns(people);
            var addressBookService = new AddressBookService(service.Object);

            var numberOfMales = addressBookService.GetNumberOfMales();

            numberOfMales.Should().Be(3);
        }

        [Test]
        public void WhoIsTheOldest()
        {            
            var service = new Mock<IGetAddressBook>();
            service.Setup(x => x.GetAddressBooks()).Returns(people);
            var addressBookService = new AddressBookService(service.Object);

            var person = addressBookService.OldestPerson();

            person.Name.Should().BeEquivalentTo("Dana Lane");
        }

        [Test]
        public void HowManyDaysOlder()
        {            
            var service = new Mock<IGetAddressBook>();
            service.Setup(x => x.GetAddressBooks()).Returns(people);
            var addressBookService = new AddressBookService(service.Object);

            var days = addressBookService.HowManyDaysOlder("Dana Lane", "Zee A");

            days.Should().Be(365 * DanaLaneYearsOld - 1);
        }
    }
}