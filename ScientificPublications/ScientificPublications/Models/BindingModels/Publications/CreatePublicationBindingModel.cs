using System.Collections.Generic;

namespace ScientificPublications.WebUI.Models.BindingModels.Publications
{
    public class CreatePublicationBindingModel : BindingModel
    {
        public string Text { get; set; }

        public ICollection<AuthorPublicationBindingModel> AuthorsPublications { get; set; }
    }
}
