using ScientificPublications.WebUI.Models.BindingModels.AuthorsAliases;
using ScientificPublications.WebUI.Models.BindingModels.User;
using System.Collections.Generic;

namespace ScientificPublications.WebUI.Models.BindingModels.Authors
{
    public class CreateAuthorBindingModel : BindingModel
    {
        public RegisterUserBindingModel RegisterUser { get; set; }

        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
