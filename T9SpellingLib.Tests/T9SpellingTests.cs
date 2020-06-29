using System;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T9SpellingLib.Tests
{
    [TestClass]
    public class T9SpellingTests
    {
        [TestMethod]
        public void TestEmptyString()
        {
            string  input_str    = "";
            string  exp_value    = "Input string is empty";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestBadStringBeginSymAndNum()
        {
            string  input_str    = "a4\nabs";
            string  exp_value    = "Invalid input format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestBadStringBeginNumAndSym()
        {
            string  input_str    = "4a\nabs";
            string  exp_value    = "Invalid input format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestBadStringBeginSymsAndNewString()
        {
            string  input_str    = "ba\nabs";
            string  exp_value    = "Invalid input format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestBadStringBeginNewStringAndSyms()
        {
            string  input_str    = "\nabs";
            string  exp_value    = "Invalid input format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestBadStringBeginSymsOnly()
        {
            string  input_str    = "abs";
            string  exp_value    = "Invalid input format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLinesNumberLess()
        {
            string  input_str    = "4\nsdf\nwerw\nsdaf";
            string  exp_value    = "Wrong number of lines";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLinesNumberGreater()
        {
            string  input_str    = "4\nsdf\nwerw\nsdaf\nwerf\nfagf";
            string  exp_value    = "Wrong number of lines";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLinesNumberNegative()
        {
            string  input_str    = "-5\nsdf\nwerw\nsdaf\nwerf\nfagf";
            string  exp_value    = "Lines number must be positive";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLinesNumberPositive()
        {
            string  input_str    = "101\nsdf\nwerw\nsdaf\nwerf\nfagf";
            string  exp_value    = "Too large lines number";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLineLengthTooShort()
        {
            string  input_str    = "3\n\ndsaf\nxcb";
            string  exp_value    = "Line length error (must be from 1 to 1000)";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongLineLengthTooLarge()
        {
            string  input_str    = "1\n";
            for( int i = 0; i < 1001; i++ )
            {
                input_str += 'a';
            }
            string  exp_value    = "Line length error (must be from 1 to 1000)";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongUpCaseSyms()
        {
            string  input_str    = "2\naSf\ndsfaw";
            string  exp_value    = "Wrong symbol format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestWrongOtherSyms()
        {
            string  input_str    = "2\na,f\ndsfaw";
            string  exp_value    = "Wrong symbol format";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }

        [TestMethod]
        public void TestDataFromTask()
        {
            string  input_str    = "4\nhi\nyes\nfoo  bar\nhello world";
            string  exp_value    = "Case #1: 44 444\nCase #2: 999337777\nCase #3: 333666 6660 022 2777\nCase #4: 4433555 555666096667775553";

            T9Spelling  spelling    = new T9Spelling();
            string      ret_value   = spelling.MainProcess(input_str);

            Assert.AreEqual(exp_value, ret_value);
        }
        
        [TestMethod]
        public void TestDataFromFile()
        {
            string  file_path_in    = "../../test.in";
            string  file_path_out   = "../../test.out";

            if( File.Exists(file_path_in) && File.Exists(file_path_out) )
            {
                string  input_str       = File.ReadAllText(file_path_in);
                string  exp_value       = File.ReadAllText(file_path_out);
                        exp_value       = exp_value.Replace("\r\n", "\n");

                T9Spelling  spelling    = new T9Spelling();
                string      ret_value   = spelling.MainProcess(input_str);

                Assert.AreEqual(exp_value, ret_value);
            }
            else
            {
                Assert.Fail("Input or output file not found");
            }
        }
    }
}
