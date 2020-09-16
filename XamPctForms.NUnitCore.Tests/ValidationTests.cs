using NUnit.Framework;
using XamPctForms.Model.Validation;

namespace XamPctForms.NUnitCore.Tests
{
    public class ValidationTests
    {
        private AddUserViewModel viewModel;
        [SetUp]
        public void Setup()
        {
            viewModel = new XamPctForms.AddUserViewModel();
        }

        [Test]
        public void ShouldAllow_Abc35()
        {
            //Arrange
            var validation = new AllowedCharactersRule<string>();
            
            //Act
            bool valid = validation.Check("Abc35");

            //Assert
            Assert.IsTrue(valid);
        }

        [Test]
        public void ShouldNotAllow_Blank()
        {
            //Arrange
            viewModel.Password.Value = "";

            //Act
            bool valid = viewModel.ValidatePassword();

            //Assert
            Assert.IsFalse(valid);
        }
        [Test]
        public void MustHaveAtLeastOneNumberAndLetter()
        {
            //Arrange
            string subject = "Abcdef";
            var validator = new AtLeastOneNumberAndLetterEachRule<string>();

            //Act
            bool valid = validator.Check(subject);

            //Assert
            Assert.IsFalse(valid);
        }
        [Test]
        public void MoreThan12ShouldFail()
        {
            //Arrange
            viewModel.Password.Value = "Xamarin1234567890";

            //Act
            bool valid = viewModel.ValidatePassword();

            //Assert
            Assert.IsFalse(valid);
        }
        [Test]
        public void LessThanFiveShouldFail()
        {
            //Arrange
            viewModel.Password.Value = "Ac12";

            //Act
            bool valid = viewModel.ValidatePassword(); ;

            //Assert
            Assert.IsFalse(valid);
        }
        [Test]
        public void RepeatedLettersShouldFail()
        {
            //Arrange
            viewModel.Password.Value = "aaaaa";

            //Act
            bool valid = viewModel.ValidatePassword(); ;

            //Assert
            Assert.IsFalse(valid);
        }
        [Test]
        public void RepeatedSequenceShouldFail()
        {
            //Arrange
            string subject = "ab1ab1";
            var validator = new NoRepeatingSequencRule<string>();

            //Act
            bool valid = validator.Check(subject);

            //Assert
            Assert.IsFalse(valid);
        }

        //TODO: don't allow  333333 aaaa3 AaAaAa3
    }
}