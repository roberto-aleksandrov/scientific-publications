using FluentValidation.Resources;

namespace ScientificPublications.Application.Common.Constants.Validators
{
    public static class ErrorMessages
    {
        public const string EntityExists = "Already exists";

        public const string EntityDoesNotExists = "Does not exists";

        public const string Unauthorized = "Unauthorized";

        public const string NotUnique = "{PropertyName} must be unique!";

        public const string InvalidInclude = "Invalid include clause.";

        public const string Invalid = "Invalid";
    }
}
