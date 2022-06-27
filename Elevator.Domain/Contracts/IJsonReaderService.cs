using Elevator.Domain.Entities;
using System.Collections.Generic;

namespace Elevator.Domain.Contracts
{
    public interface IJsonReaderService
    {
        /// <summary>
        /// Reads input.json file and assign to the UserResponse class for use in other methods.
        /// </summary>
        /// <returns></returns>
        public List<UserResponse> UserResponses();
    }
}
