using System.Linq;
using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Interview.Repository;
using Interview.Entity;
using Interview.Exceptions;
using System.Threading.Tasks;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private IRepository<User> _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Repository<User>();
        }

        [Test]
        public async Task ShouldReturnAllUsers()
        {
            // Given


            // When
            var users = await _userRepository.All();

            // Then
            Assert.NotNull(users);
            Assert.IsInstanceOf<IEnumerable<User>>(users);
        }

        [Test]
        public async Task ShouldAddAUserAndHandleDuplicate()
        {
            // Given
            var user = new User
            {
                UserName = "test",
                Id = 1
            };

            var exceptionMessage = $"Duplicate Entity with Id: {user.Id} found";

            // When
            _userRepository.Save(user);

            var users = await _userRepository.All();

            // Then
            Assert.NotNull(users);
            Assert.True(users.Contains(user));

            var ex = Assert.Throws<EntityExistsException>(() => _userRepository.Save(user));

            // Then
            Assert.NotNull(ex);
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ShouldAddAUser()
        {
            // Given
            var user = new User
            {
                UserName = "test",
                Id = 1
            };

            // When
            _userRepository.Save(user);

            var users = await _userRepository.All();

            // Then
            Assert.NotNull(users);
            Assert.True(users.Contains(user));
        }

        [Test]
        public void ShouldDeleteAUserAndHandleException()
        {
            // Given
            var user = new User
            {
                UserName = "test",
                Id = 1
            };

            var userIdToFind = 2;
            var exceptionMessage = $"Entity with Id {userIdToFind} Not Found";

            // When
            _userRepository.Save(user);
            var ex = Assert.Throws<EntityNotFoundException>(() => _userRepository.Delete(userIdToFind));

            // Then
            Assert.NotNull(ex);
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ShouldDeleteAUser()
        {
            // Given
            var user = new User
            {
                UserName = "test",
                Id = 1
            };

            // When
            _userRepository.Save(user);
            _userRepository.Delete(user.Id);

            var users = await _userRepository.All();

            // Then
            Assert.NotNull(users);
            Assert.False(users.Contains(user));
        }

        [Test]
        public void ShouldFindAUserById()
        {
            // Given
            var users = new List<User>
            {
                new User
                {
                    UserName = "test",
                    Id = 1
                },
                new User
                {
                    UserName = "test1",
                    Id = 2
                },
                new User
                {
                    UserName = "test3",
                    Id = 3
                }
            };

            // When
            users.ForEach(user => _userRepository.Save(user));

            var foundUser = _userRepository.FindById(users[1].Id);

            // Then
            Assert.NotNull(foundUser);
            Assert.AreEqual(foundUser, users[1]);
        }
    }
}