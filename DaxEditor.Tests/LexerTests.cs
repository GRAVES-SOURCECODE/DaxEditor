﻿namespace DaxEditor.Test
{
    using Babel.ParserGenerator;
    using NUnit.Framework;

    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void GetText_SingleLine()
        {
            Babel.Parser.ErrorHandler handler = new Babel.Parser.ErrorHandler();
            Babel.Lexer.Scanner scanner = new Babel.Lexer.Scanner();
            scanner.Handler = handler;

            scanner.SetSourceText("CREATE MEASURE t[B]=Random()");
            var text = scanner.GetText(new LexLocation(1, 20, 1, 28));
            Assert.IsFalse(handler.Errors, "Error happened");
            Assert.AreEqual("Random()", text);
        }

        [Test]
        public void GetText_MultiLine()
        {
            Babel.Parser.ErrorHandler handler = new Babel.Parser.ErrorHandler();
            Babel.Lexer.Scanner scanner = new Babel.Lexer.Scanner();
            scanner.Handler = handler;

            scanner.SetSourceText(@"CREATE MEASURE t[B]=Random()
+ 1 +
2");
            var text = scanner.GetText(new LexLocation(1, 20, 3, 1));
            Assert.IsFalse(handler.Errors, "Error happened");
            Assert.AreEqual(@"Random()
+ 1 +
2", text);


        }

    }
}
