using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HtmlMinifyExample
{
    /// <summary>
    /// Minifies the HTML code. Removes all whitespaces
    /// </summary>
    public class HtmlMinifyStream : MemoryStream
    {
        #region Properties and Fields
        /// <summary>
        /// Regex; Pattern by http://stackoverflow.com/questions/8762993/remove-white-space-from-entire-html-but-inside-pre-with-regular-expressions
        /// </summary>
        private static readonly Regex RegExpressionWhiteSpaces = new Regex( @"(?<=\s)\s+(?![^<>]*</pre>)", RegexOptions.Compiled );
        // Regex instances are read-only => Thread-safe and can be static

        /// <summary>
        /// Stream to minify.
        /// Do not dispose by yourself!
        /// </summary>
        private readonly Stream _responseStream;
        #endregion

        #region Constructor
        /// <summary>
        /// Create new minify stream based on the current response stream. Overwrites contents
        /// </summary>
        public HtmlMinifyStream( Stream responseStream )
        {
            this._responseStream = responseStream;
        }
        #endregion

        /// <summary>
        /// Override close method and implement minification
        /// </summary>
        public override void Close()
        {
            // Minify
            var minified = Encoding.UTF8.GetBytes( RegExpressionWhiteSpaces.Replace( Encoding.UTF8.GetString( this.ToArray( ) ), String.Empty ) );

            // write data to stream
            _responseStream.Write( minified, 0, minified.Length );
            // flush all
            _responseStream.Flush( );


            base.Close( );
        }
    }
}