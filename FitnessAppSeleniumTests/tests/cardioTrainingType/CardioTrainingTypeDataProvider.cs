using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;

namespace FitnessAppSeleniumTests.tests.cardioTrainingType
{
    public class CardioTrainingTypeDataProvider
    {
        public static CardioTrainingType CardioTrainingType()
        {
            return new CardioTrainingType()
            {
                Name = StringUtils.RandomEntityName(),
                Expenditure = "15"
            };
        }
    }
}
