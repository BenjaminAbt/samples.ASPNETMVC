using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerfTest
{
    class Program
    {
        private static Regex RegExpressionWhiteSpaces;


        private const String s = @"\r\n<bla>   </bla>\r\n<bla>  </bla>\r\n<bla></bla>\r\n";


        private static void Main( string[ ] args )
        {

            RegExpressionWhiteSpaces = new Regex(
                // %# Collapse ws everywhere but in blacklisted elements.
              @"(?>" + //             # Match all whitespans other than single space.
              @"[^\S ]\s*" + //     # Either one [\t\r\n\f\v] and zero or more ws,
              @"| \s{2,}" + //        # or two or more consecutive-any-whitespace.
              @")" + // # Note: The remaining regex consumes no text at all...
              @"(?=" + //             # Ensure we are not in a blacklist tag.
              @"(?:" + //           # Begin (unnecessary) group.
              @"(?:" + //         # Zero or more of...
              @"[^<]+" + //    # Either one or more non-"<"
              @"| <" + //         # or a < starting a non-blacklist tag.
              @"(?!/?(?:textarea|pre)\b)" + //
              @")*" + //         # (This could be "unroll-the-loop"ified.)
              @")" + //             # End (unnecessary) group.
              @"(?:" + //           # Begin alternation group.
              @"<" + //           # Either a blacklist start tag.
              @"(?>textarea|pre)\b" + //
              @"| \z" + //          # or end of file.
              @")" + //             # End alternation group.
              @")" //  # If we made it here, we are not in a blacklist tag.
                //@"(?>[^\S ]\s*|\s{2,})(?=(?:(?:[^<]+|<(?!/?(?:textarea|pre)\b))*)(?:<(?>textarea|pre)\b|\z))"
            , RegexOptions.Multiline | RegexOptions.Compiled );

            var f = File.ReadAllText( "heisecontent.htm" );
            var c = f.Split( '\n' ).Count( );

            var t = RegExpressionWhiteSpaces.Replace( f, "XX" );
            var r = t.Split( '\n' ).Count( );
            Console.WriteLine( "HI" );
        }


        //private static void Main( string[ ] args )
        //{
        //    var fileContent = File.ReadAllText( "heisecontent.htm" );

        //    // First call -> compile
        //    var fc = Stopwatch.StartNew( );
        //    RegExpressionWhiteSpaces.Replace( fileContent, string.Empty );
        //    fc.Stop( );

        //    // Länge des erzeugten strings = 24000
        //    Console.WriteLine( "String length: " + fileContent.Length );
        //    var c = 10;
        //    var sw = Stopwatch.StartNew( );
        //    for ( var i = 0 ; i < c ; i++ )
        //    {

        //        RegExpressionWhiteSpaces.Replace( fileContent, string.Empty );
        //    }

        //    sw.Stop( );

        //    Console.WriteLine( "First Call: " + fc.Elapsed.TotalMilliseconds + " Each: " + sw.Elapsed.TotalMilliseconds / c );
        //    Console.Read( );
        //}
    }
}
