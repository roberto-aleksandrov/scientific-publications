using Newtonsoft.Json;
using ScientificPublications.Application.Common.Models.Mediatr;

namespace ScientificPublications.WebUI.Models.BindingModels
{
    public class BindingModel
    {
        [JsonIgnore]
        public UserInfo UserInfo { get; set; }
    }
}
