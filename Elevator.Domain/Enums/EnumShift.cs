using System.ComponentModel;

namespace Elevator.Domain.Enums
{
    public enum EnumShift
    {
        [Description("M")] Moorning = 1,
        [Description("V")] Afternoon = 2,
        [Description("N")] Night = 3
    }
}
