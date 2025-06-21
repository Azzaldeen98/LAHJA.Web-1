namespace Shared.Failures.Operation
{
    public class ClientTaskCanceledFailure : OperationFailure
    {
        public ClientTaskCanceledFailure(string message = "تم إلغاء العملية.") : base(message) { }
    }
}
