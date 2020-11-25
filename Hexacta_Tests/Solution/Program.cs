using System;
using Solution.Repos;
using Solution.Repos.Interfaces;
using Solution.Services;
using Solution.Services.Interfaces;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            ITransitionRepository transitions = new TransitionRepository();
            IStatusRepository statuses = new StatusRepository();
            ISubtypeRepository subtypes = new SubtypeRepository();

            IStatusService service = new StatusService(transitions, statuses, subtypes);

            var initialDefaultStatuses = service.GetInitialStatuses(SubtypeRepository.DefaultSubtype);
            var initialValidationStatuses = service.GetInitialStatuses(SubtypeRepository.ValidationSubtype);

            Console.WriteLine("------ Initial Default Statuses ------");

            foreach (var defaultStatus in initialDefaultStatuses)
                Console.WriteLine(defaultStatus);

            Console.WriteLine("------ Initial Validation Statuses ------");

            foreach (var validationStatus in initialValidationStatuses)
                Console.WriteLine(validationStatus);

            Console.ReadLine();
        }
    }
}
