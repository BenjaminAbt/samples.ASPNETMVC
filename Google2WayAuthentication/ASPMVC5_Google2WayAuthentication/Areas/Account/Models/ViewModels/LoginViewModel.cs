using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Encoded Secret to display barcode for app scanning
        /// </summary>
        public string EncodedSecretForBareCode { get; set; }

        /// <summary>
        /// Name of Application displayed in Google Authenicator App
        /// </summary>
        public string AppIdentifyName { get; set; }
    }
}