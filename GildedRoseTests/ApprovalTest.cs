using System;
using System.IO;
using System.Reflection;
using System.Text;
using NFluent;
using NUnit.Framework;
using GildedRoseKata;

namespace GildedRoseTests
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ThirtyDays.txt");
            var lines = File.ReadAllLines(path);

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            var outputLines = output.Replace("\r\n", "\n").Split('\n');
            for (var i = 0; i < Math.Min(lines.Length, outputLines.Length); i++) 
            {
                Check.That(lines[i]).IsEqualTo(outputLines[i]);
            }
        }
    }
}
