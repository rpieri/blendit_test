namespace BlendIt.Test.Shared.Commands
{
    public sealed class CommandResult
    {
        public CommandResult(bool success) => Success = success;
        public CommandResult(bool success, object data) : this(success) => Data = data;
        public CommandResult(bool success, string message) : this(success) => Message = message;
        public CommandResult(bool success, string message, object data) : this(success, message) => Data = data;
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public bool HasAProblem => !Success;
        public void SetData(object data) => Data = data;
    }
}
