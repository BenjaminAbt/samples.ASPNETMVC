using System;
using System.Collections.Generic;
using System.Linq;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models
{
    /// <summary>
    /// Base for all ViewModels
    /// </summary>
    public abstract class BaseViewModel
    {
        /// <summary>
        /// Creates the Instance and creates empty lists for message collections.
        /// </summary>
        protected BaseViewModel( )
        {
            this.ErrorMessages = new List<string>( );
            this.SuccessMessages = new List<string>( );
        }

        /// <summary>
        /// Error Messages. 
        /// </summary>
        /// <remarks>Cannot be null, just empty.</remarks>
        public List<String> ErrorMessages { get; private set; }

        /// <summary>
        /// Success Messages. 
        /// </summary>
        /// <remarks>Cannot be null, just empty.</remarks>
        public List<String> SuccessMessages { get; private set; }

        /// <summary>
        /// Returns true if any message collection (<see cref="ErrorMessages"/> or <see cref="SuccessMessages"/>) contains an element.
        /// </summary>
        public Boolean HasMessages
        {
            get { return ErrorMessages.Any( ) || SuccessMessages.Any( ); }
        }
    }
}