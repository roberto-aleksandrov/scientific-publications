using System.Collections.Generic;

namespace ScientificPublications.WebUI.Models.BindingModels.Authors
{
    public class CreateAuthorBindingModel
    {
        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
