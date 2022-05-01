using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.model.entity
{
    public class StrengthTraining
    {
        public StrengthTrainingType TrainingType { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public string Weight { get; set; }
    }
}
