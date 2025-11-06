using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;
using Application.Mappers;

namespace ApplicationTest
{
    [TestClass]
    public sealed class MapperCatTest
    {
        [TestMethod]
        public void ToEntity_IsCorrect_AssertEquals()
        {
            Cat entity = new Cat("a", "b", "c", null, new DateOnly(2022, 1, 1), new DateOnly(2022, 1, 2), null);
            CatDto dto = new CatDto("a", "b", "c", "d", "e", new DateOnly(2022, 1, 2), null, new DateOnly(2022, 1, 1));
            Assert.AreEqual(entity, dto.ToEntity());
        }
        
    }
}
