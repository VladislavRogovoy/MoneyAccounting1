using System;

namespace BusinessLogicLayer.Exceptions
{
    [Serializable]
    public class CategoryException : Exception
    {
        public CategoryException(string message)
            : base(message)
        {
        }
    }
}
