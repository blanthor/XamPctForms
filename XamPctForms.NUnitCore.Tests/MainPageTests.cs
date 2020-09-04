using NUnit.Framework;

namespace XamPctForms.NUnitCore.Tests
{
    public class MainPageTests
    {
        private MainPageViewModel viewModel;
        [SetUp]
        public void Setup()
        {
            viewModel = new XamPctForms.MainPageViewModel();
        }

        [Test]
        public void ShouldAllow_Abc35()
        {
            //Arrange
            string subject = "Abc35";

            //Act
            bool valid = viewModel.IsValidPassword(subject);

            //Assert
            Assert.IsTrue(valid);
        }

        //TODO: don't allow abc35 ABC35 333333 aaaa3 AaAaAa3
    }
}