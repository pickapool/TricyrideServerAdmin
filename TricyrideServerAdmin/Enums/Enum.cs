namespace TricyrideServerAdmin.Enums
{
    public class Enum
    {
        public enum accountType
        {
            Driver,
            Commuter
        }
        public enum CommuteStatus
        {
            InProgress,
            Cancelled,
            Done,
        }
        public enum Action
        {
            Add,
            Edit,
            Reject,
            Approve,
            Remove,
            Delete
        }
    }
}
