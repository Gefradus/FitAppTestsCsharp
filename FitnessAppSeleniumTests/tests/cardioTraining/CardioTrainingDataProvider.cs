using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.tests.cardioTrainingType;

namespace FitnessAppSeleniumTests.tests.cardioTraining
{
    public class CardioTrainingDataProvider 
    {
        private readonly static CardioTrainingType cardioTrainingType = CardioTrainingTypeDataProvider.CardioTrainingType();

        public static CardioTraining CardioTraining()
        {
            return new CardioTraining()
            {
                CardioTrainingType = cardioTrainingType,
                KcalBurned = "100",
                TimeInMinutes = "2000"
            };
        }

        public static CardioTraining EditedCardioTraining()
        {
            return new CardioTraining()
            {
                CardioTrainingType = cardioTrainingType,
                KcalBurned = "200",
                TimeInMinutes = "4000"
            };
        }
    }
}
