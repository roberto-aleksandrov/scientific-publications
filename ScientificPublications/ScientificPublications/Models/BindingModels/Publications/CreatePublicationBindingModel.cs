using System.Collections.Generic;

namespace ScientificPublications.WebUI.Models.BindingModels.Publications
{
    public class CreatePublicationBindingModel : BindingModel
    {
        public string Title { get; set; }

        public string Text { get; set; }
        
        public ICollection<int> AuthorIds { get; set; }
    }
}
