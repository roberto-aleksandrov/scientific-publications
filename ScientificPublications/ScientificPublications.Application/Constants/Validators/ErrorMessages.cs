using FluentValidation.Resources;

namespace ScientificPublications.Application.Constants.Validators
{
    public static class ErrorMessages
    {
        public const string EntityExists = "Already exists";

        public const string EntityDoesNotExists = "Does not exists";

        public const string Unauthorized = "Unauthorized";

        public const string NotUnique = "{PropertyName} must be unique!";

    }
}
