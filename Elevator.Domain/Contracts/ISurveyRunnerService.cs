namespace Elevator.Domain.Contracts
{
    public interface ISurveyRunnerService
    {
        /// <summary>
        /// This method is called by runtime to start the results of the survey
        /// </summary>
        public void ExecuteSurvey();
    }
}
