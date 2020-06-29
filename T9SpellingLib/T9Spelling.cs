using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9SpellingLib
{
    public class T9Spelling
    {
        public string MainProcess(string input_str)
        {
            string ret_value = "ERROR";

            string      checking_result = "ERROR";
            int         lines_num       = 0;
            string[]    lines           = null;

            if( CheckInputStr(input_str, ref checking_result, ref lines_num, ref lines) )
            {
                ret_value = Processing(lines_num, lines);
            }
            else
            {
                ret_value = checking_result;
            }

            return ret_value;
        }

        private bool CheckInputStr(string input_str, ref string result, ref int lines_num, ref string[] lines)
        {
            bool ret_value = false;

            if (input_str.Length == 0)
            {
                result      = "Input string is empty";
            }
            else
            {
                string[] delimiter_strings = { "\n", "\r\n" };
                string[] data = input_str.Split(delimiter_strings, System.StringSplitOptions.None);

                if (int.TryParse(data[0], out lines_num))
                {
                    if (lines_num >= 1 && lines_num <= 100)
                    {
                        if( data.Length == lines_num + 1)
                        {
                            bool    bad_line_length = false;
                                    lines           = new string[lines_num];

                            for( int i = 0; i < lines_num; i++ )
                            {
                                if( data[i + 1].Length == 0 || data[i + 1].Length > 1000)
                                {
                                    bad_line_length = true;
                                    break;
                                }

                                lines[i] = data[i + 1];
                            }

                            if( !bad_line_length )
                            { 
                                result      = "Ok";
                                ret_value   = true;
                            }
                            else
                            {
                                result = "Line length error (must be from 1 to 1000)";
                            }
                        }
                        else
                        {
                            result      = "Wrong number of lines";
                        }
                    }
                    else
                    {
                        result = (lines_num < 1) ? "Lines number must be positive" : "Too large lines number";
                    }
                }
                else
                {
                    result      = "Invalid input format";
                }

            }

            return ret_value;
        }

        private void FillDictionary(Dictionary<char, string> dictionary)
        {
            dictionary.Add('a', "2");
            dictionary.Add('b', "22");
            dictionary.Add('c', "222");
            dictionary.Add('d', "3");
            dictionary.Add('e', "33");
            dictionary.Add('f', "333");
            dictionary.Add('g', "4");
            dictionary.Add('h', "44");
            dictionary.Add('i', "444");
            dictionary.Add('j', "5");
            dictionary.Add('k', "55");
            dictionary.Add('l', "555");
            dictionary.Add('m', "6");
            dictionary.Add('n', "66");
            dictionary.Add('o', "666");
            dictionary.Add('p', "7");
            dictionary.Add('q', "77");
            dictionary.Add('r', "777");
            dictionary.Add('s', "7777");
            dictionary.Add('t', "8");
            dictionary.Add('u', "88");
            dictionary.Add('v', "888");
            dictionary.Add('w', "9");
            dictionary.Add('x', "99");
            dictionary.Add('y', "999");
            dictionary.Add('z', "9999");
            dictionary.Add(' ', "0");
        }

        private string Processing(int lines_num, string[] input_str)
        {
            string ret_value = "ERROR";

            if( lines_num > 0 && input_str.Length == lines_num )
            {
                Dictionary<char, string>    dictionary  = new Dictionary<char, string>();
                                            ret_value   = "";
                
                FillDictionary(dictionary);

                bool break_now = false;

                for ( int i = 0; i < lines_num; i++ )
                {
                    if( i != 0 )
                    {
                        ret_value += "\n";
                    }

                    ret_value += "Case #" + Convert.ToString(i + 1) + ": ";

                    string number_sequence = "";

                    foreach (char symbol in input_str[i])
                    {
                        string number_sequence_cur = "";

                        if (dictionary.TryGetValue(symbol, out number_sequence_cur))
                        {
                            if (number_sequence.Length != 0)
                            {
                                if (number_sequence[number_sequence.Length - 1] == number_sequence_cur[0])
                                {
                                    number_sequence += ' ';
                                }
                            }

                            number_sequence += number_sequence_cur;
                        }
                        else
                        {
                            break_now = true;
                            break;
                        }
                    }

                    if (!break_now)
                    {
                        ret_value += number_sequence;
                    }
                    else
                    {
                        ret_value = "Wrong symbol format";
                        break;
                    }
                }

                dictionary.Clear();
            }

            return ret_value;
        }
    }
    
}