using System;
namespace BoilerPlate.Models
{
    public partial class UserModel : KeyedModel<int>
    {
        public UserModel()
        {
        }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsActive { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> PartnerAsClientId { get; set; }
        public Nullable<int> AccountExecutiveId { get; set; }
        public string AlternateUserName { get; set; }
        public string AdditionalEmail { get; set; }
        public string DirectPhone { get; set; }
        public string CellPhone { get; set; }
        public string EncompassId { get; set; }
        public string BizContactId { get; set; }
        public string AccountExecutive_Email { get; set; }
        public string PartnerAsClient_Email { get; set; }
        public string PartnerAsClient_Name { get; set; }
        public string AccountExecutive_Name { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
    }
}