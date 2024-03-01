using JsonStorageManager.QueueProcessor;

namespace JsonStorageManagerUnitTests
{
    public class ValidatorTests
    {
        private readonly Validator _validator = new Validator();

        [Theory]
        [InlineData("{\"x\" : 3}", true)]
        [InlineData("{", false)]
        public void Return_true_for_valid_json(
            string json, 
            bool expectedResult)
        {
            // act
            var result = _validator.IsValid(json);

            // assert
            Assert.Equal(expectedResult, result);
        }
    }
}