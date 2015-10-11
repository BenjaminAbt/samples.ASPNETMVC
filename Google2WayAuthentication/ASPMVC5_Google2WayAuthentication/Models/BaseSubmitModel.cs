using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models
{
    /// <summary>
    /// Base for all SubmitModels.
    /// </summary>
    /// <remarks>Every submit should be result in a submit model.</remarks>
    public abstract class BaseSubmitModel
    {
        /// <summary>
        /// Implement your submitmodel validation (only logical errors!) here
        /// </summary>
        /// <returns>Collection of errors</returns>
        public abstract IEnumerable<ValidationResult> Validate( );

        /// <summary>
        /// Implementation for easy submit model validation
        /// </summary>
        /// <param name="errors">Contains errors if validations fails.</param>
        /// <returns>false if validations fails. see <see cref="errors"/> for specfic error(s)</returns>
        public Boolean IsValid( out IReadOnlyCollection<ValidationResult> errors )
        {
            errors = Validate( ).ToList( );
            return ( errors.Count == 0 );
        }
    }
}