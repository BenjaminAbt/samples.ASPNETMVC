using System.Web.Mvc;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account
{
    public partial class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Account";
            }
        }


    }
}