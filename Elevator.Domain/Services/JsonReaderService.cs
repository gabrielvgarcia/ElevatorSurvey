using Elevator.Domain.Contracts;
using Elevator.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Elevator.Domain.Services
{
    public class JsonReaderService : IJsonReaderService
    {
        public List<UserResponse> UserResponses() => JsonConvert.DeserializeObject<List<UserResponse>>(File.ReadAllText("../../../input.json"));
    }
}
