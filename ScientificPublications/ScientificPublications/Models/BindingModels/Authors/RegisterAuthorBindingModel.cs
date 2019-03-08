using ScientificPublications.WebUI.Models.BindingModels.User;

namespace ScientificPublications.WebUI.Models.BindingModels.Authors
{
    public class RegisterAuthorBindingModel : BindingModel
    {
        public RegisterUserBindingModel RegisterUser { get; set; }

        public CreateAuthorBindingModel CreateAuthor { get; set; }
    }
}
