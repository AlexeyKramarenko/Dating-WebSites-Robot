using System;

namespace Infrastructure.Models
{
    public class OperationResult
    {
        public bool Success { get; }
        public string Result { get; }

        private OperationResult(bool success, string result)
        {
            if (success && result == null)
                throw new ArgumentException($"'{nameof(result)}' should not be null.");

            Success = success;
            Result = result;
        }

        public static OperationResult Created(string result)
        {
            return new OperationResult(true, result);
        }

        public static OperationResult Fail()
        {
            return new OperationResult(false, default);
        }
    }
}
