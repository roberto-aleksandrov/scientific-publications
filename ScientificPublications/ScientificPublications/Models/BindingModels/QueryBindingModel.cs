namespace ScientificPublications.WebUI.Models.BindingModels
{
    public class QueryBindingModel : BindingModel
    {
        public string Include { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }
    }
}
