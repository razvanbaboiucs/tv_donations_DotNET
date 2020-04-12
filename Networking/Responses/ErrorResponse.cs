using System;

namespace Networking.Responses
{
    [Serializable]
    public class ErrorResponse : IResponse
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }
}