using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;

namespace FitnessAppSeleniumTests.tests.strengthTraining
{
    public class StrengthTrainingDataProvider
    {
        private static readonly StrengthTrainingType trainingType =
            new StrengthTrainingType() { Name = StringUtils.RandomEntityName() };

        public static StrengthTraining StrengthTraining()
        {
            return new StrengthTraining()
            {
                Reps = "10",
                Weight = "100",
                Sets = "10",
                TrainingType = trainingType
            };
        }

        public static StrengthTraining EditedStrengthTraining()
        {
            return new StrengthTraining()
            {
                Reps = "12",
                Weight = "120",
                Sets = "4",
                TrainingType = trainingType
            };
        }
    }
}
