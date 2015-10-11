using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SchwabenCode.Authentication;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models.SubmitModels;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models.ViewModels;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing;
using SchwabenCode.Web.Mvc.Routing;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SampleUser _sampleUser;
        private readonly GoogleTwoWayAuthenticator _googleTwoWayAuthenticator;

        /// <summary>
        /// This name will appear on the Google App!
        /// </summary>
        private const string ApplicationName = "MVCSampleApplication";

        public AccountController( )
        {
            _sampleUser = new SampleUser( );
            _googleTwoWayAuthenticator = new GoogleTwoWayAuthenticator( );
        }

        public ActionResult Index( )
        {
            return Redirect( RouteCache.Get( Url, RouteNames.AccountArea.Account_Login ) );
        }

        /// <summary>
        /// Gets called by regular request of /Account/Login
        /// </summary>
        public ActionResult Login( )
        {
            // Create ViewModel for Login
            var vm = CreateLoginViewModel( );

            // To increase performance use the correct path instead of reflection features!
            return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
        }

        /// <summary>
        /// Gets called by Login Form Submit
        /// </summary>
        /// <param name="submitModel">All input-Fields</param>
        [HttpPost]
        public ActionResult Login( LoginSubmitModel submitModel )
        {
            // Create ViewModel for Login
            var vm = CreateLoginViewModel( );

            // check logical errors of submitmodel
            IReadOnlyCollection<ValidationResult> errors;
            if ( !submitModel.IsValid( out errors ) )
            {
                CopyErrorsToViewModel( vm, errors );
                return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
            }

            // here: no logical errors!
            SampleUser currentUser;

            if ( false ) // use myUserRepository.UserNameExists() here
            {
                // User not found!
                vm.ErrorMessages.Add( "Username and/or password not found!" );
                return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
            }

            // User found
            currentUser = _sampleUser;

            // Check users password!
            if ( false ) // use submitModel.Password != currentUser.Password here!
            {
                // Invalid password
                vm.ErrorMessages.Add( "Username and/or password not found!" );
                return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
            }

            // Password is correct. Yay!

            // Retrive current authcode
            var currentTimebasedPassword = _googleTwoWayAuthenticator.GetCurrentTimeBasedPassword( currentUser.Secret );
            if ( currentTimebasedPassword != submitModel.AuthCode )
            {
                vm.ErrorMessages.Add( "Invalid AuthCode. Login failed!" );
                return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
            }

            // Login succeeded!
            // FormsAuthentication.SetAuthCookie( currentUser.Username, false );

            vm.SuccessMessages.Add( "Yaaay! Login succeeded!" );
            // or use redirect here!
            //AddTempSuccess( "Yaaay! Login succeeded!" );
            //return Redirect(RouteCache.Get(Url, RouteNames.Home);

            // To increase performance use the correct path instead of reflection features!
            return View( "~/Areas/Account/Views/Account/Login.cshtml", vm );
        }

        /// <summary>
        /// Creates the <see cref="LoginViewModel"/>
        /// </summary>
        private LoginViewModel CreateLoginViewModel( )
        {
            // Create specific viewModel
            var vm = GetViewModel<LoginViewModel>( );

            // Add application identity name for google authenticator app
            vm.AppIdentifyName = _sampleUser.Username + "@" + ApplicationName;

            // For qrcode generation you have to deliver the encodeded secret to the viewmodel
            vm.EncodedSecretForBareCode = _googleTwoWayAuthenticator.EncodeSecret( this._sampleUser.Secret );

            return vm;
        }
    }
}
