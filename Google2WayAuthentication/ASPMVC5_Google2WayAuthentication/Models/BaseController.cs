using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Models
{
    public class BaseController : Controller
    {
        #region Error Handling
        /// <summary>
        /// Copies the errors to the view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        protected void CopyMessagesToViewModel( BaseViewModel viewModel )
        {
            if ( viewModel != null )
            {
                if ( this.TempData[ "ErrorMessages" ] != null )
                {
                    var list = ( ( IEnumerable<string> )this.TempData[ "ErrorMessages" ] ) ?? new List<string>( );
                    viewModel.ErrorMessages.AddRange( list );
                    this.TempData[ "ErrorMessages" ] = null;
                }


                if ( this.TempData[ "SuccessMessages" ] != null )
                {
                    var list = ( IEnumerable<string> )this.TempData[ "SuccessMessages" ] ?? new List<string>( );
                    viewModel.SuccessMessages.AddRange( list );
                    this.TempData[ "SuccessMessages" ] = null;
                }
            }
        }


        /// <summary>
        /// Copy Messages to Error Collection of given ViewModel
        /// </summary>
        protected void CopyErrorsToViewModel( BaseViewModel viewModel, IEnumerable<ValidationResult> errors )
        {
            if ( viewModel != null && errors != null )
            {
                viewModel.ErrorMessages.AddRange( errors.Select( e => e.ErrorMessage ) );
            }
        }

        /// <summary>
        /// Adds an error to the error messages collection
        /// </summary>
        public void AddTempError( string text, params object[ ] args )
        {
            AddMessage( "ErrorMessages", text, args );
        }

        /// <summary>
        /// Adds a success entry to the success messages collection
        /// </summary>
        public void AddTempSuccess( string text, params object[ ] args )
        {
            AddMessage( "SuccessMessages", text, args );
        }

        /// <summary>
        /// Adds a message to the given collection
        /// </summary>
        /// <param name="target">Name of the collection</param>
        private void AddMessage( String target, string text, params object[ ] args )
        {
            var message = string.Format( text, args );
            if ( this.TempData[ target ] == null )
            {
                this.TempData[ target ] = new List<string> { message };
            }
            else
            {
                ( ( List<string> )this.TempData[ target ] ).Add( message );
            }
        }
        #endregion

        /// <summary>
        /// Creates a given ViewModel and puts all messages from the session into the message collection (<see cref="CopyErrorsToViewModel"/>)
        /// </summary>
        /// <typeparam name="T">Specific ViewModel</typeparam>
        protected T GetViewModel<T>( ) where T : BaseViewModel, new( )
        {
            var viewModel = new T( );
            CopyMessagesToViewModel( viewModel );
            return viewModel;
        }

    }
}
