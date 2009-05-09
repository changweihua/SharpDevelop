// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.NRefactory;
using ICSharpCode.PythonBinding;
using NUnit.Framework;

namespace PythonBinding.Tests.Converter
{
	[TestFixture]
	public class WhileLoopConversionTestFixture
	{		
		string csharp = "class Foo\r\n" +
						"{\r\n" +
						"\tpublic void CountDown()\r\n" +
						"\t{\r\n" +
						"\t\tint i = 10;\r\n" +
						"\t\twhile (i > 0) {\r\n" +
						"\t\t\ti--;\r\n" +
						"\t\t}\r\n" +
						"\t}\r\n" +
						"}";
				
		[Test]
		public void ConvertedPythonCode()
		{
			NRefactoryToPythonConverter converter = new NRefactoryToPythonConverter(SupportedLanguage.CSharp);
			string python = converter.Convert(csharp);
			string expectedPython = "class Foo(object):\r\n" +
									"\tdef CountDown(self):\r\n" +
									"\t\ti = 10\r\n" +
									"\t\twhile i > 0:\r\n" +
									"\t\t\ti -= 1";
			
			Assert.AreEqual(expectedPython, python);
		}
	}
}

