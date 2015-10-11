using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models.SubmitModels
{
    /// <summary>
    /// Holds all input values of the form submit
    /// </summary>
    public class LoginSubmitModel : BaseSubmitModel
    {
        #region Properties
        /// <summary>
        /// Username for Login
        /// </summary>
        public String Username { get; set; }

        /// <summary>
        /// Password (plaintext) for login
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// AuthCode showed by Google App. It should be always a number but you should use handle all user input!
        /// You have not neet to check the number, because you will use Equals() to verify password.
        /// </summary>
        public String AuthCode { get; set; }
        #endregion

        #region Validation Implementation
        /// <summary>
        /// My exemplary validation implementation for this submitmodel
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ValidationResult> Validate( )
        {
            #region Check Username Input
            if ( String.IsNullOrEmpty( Username ) )
            {
                yield return new ValidationResult( "Field 'Username' is missing." );
            }
            #endregion

            #region Check Password Input
            if ( String.IsNullOrEmpty( Password ) )
            {
                yield return new ValidationResult( "Field 'Password' is missing." );
            }
            #endregion

            #region Check AuthCode Input
            if ( String.IsNullOrEmpty( AuthCode ) )
            {
                yield return new ValidationResult( "Field 'AuthCode' is missing." );
            }
            else
            {
                if ( AuthCode.Length != 6 )
                {
                    // Google Authenticator App always generates an AuthCode Length = 6
                    yield return new ValidationResult( "Field 'AuthCode' seems to be invalid. Required Length: 6" );
                }
            }
            #endregion
        }
        #endregion
    }
}