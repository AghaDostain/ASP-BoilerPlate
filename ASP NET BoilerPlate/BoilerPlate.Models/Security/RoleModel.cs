namespace BoilerPlate.Models
{
    public partial class RoleModel : KeyedModel<int>
    {
        public RoleModel()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        }
}