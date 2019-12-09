using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent8_12Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string key = Console.ReadLine();
            if (key.Contains("8a"))
            {
                string Advent8 = Properties.Resources.Advent8;
                int Width = 25;
                int Height = 6;
                //Test
                //Advent8 = "123456789012";

                //Width = 3;
                //Height = 2;
                //Test
                int NumLayers = Advent8.Length / (Width * Height);
                Console.WriteLine("Length of Input: " + Advent8);
                Console.WriteLine("Number of Layers: " + (Advent8.Length / (Width * Height)).ToString());
                Console.WriteLine("Layer has the least number of 0: " + "Layerx");
                Console.WriteLine("Layer Value: " + "Result");
                List<string> PictureLayers = new List<string>();
                int LeastZero = int.MaxValue;
                string Result = string.Empty;
                int LeastLayer = 0;
                int NumberOfOne = 0;
                int NumberOfTwo = 0;
                for (int i = 0; i < NumLayers; i++)
                {
                    int NumZeros = int.MaxValue;
                    if (Advent8.Length > i * Width * Height)
                    {
                        PictureLayers.Add(Advent8.Substring(i * Width * Height, Width * Height));
                        NumZeros = Advent8.Substring(i * Width * Height, Width * Height).Count(x => x == '0');
                    }
                    else
                    {
                        PictureLayers.Add(Advent8.Substring(i * Width * Height, Advent8.Length - (i * Width * Height)));
                        NumZeros = Advent8.Substring(i * Width * Height, Width * Height).Count(x => x == '0');
                    }
                    if(NumZeros < LeastZero)
                    {
                        LeastZero = NumZeros;
                        LeastLayer = i;
                        Result = PictureLayers[i];
                    }
                }
                NumberOfOne = Result.Count(x => x == '1');
                NumberOfTwo = Result.Count(x => x == '2');
                Console.WriteLine("Layer has the least number of 0: " + LeastLayer);
                Console.WriteLine("Layer String: " + Result);
                Console.WriteLine("Result Parsing Layer: " + (NumberOfOne * NumberOfTwo));
            }
            else if(key.Contains("8b"))
            {
                string Advent8 = Properties.Resources.Advent8;
                int Width = 25;
                int Height = 6;
                //Test
                //Advent8 = "123456789012";

                //Width = 3;
                //Height = 2;
                //Test
                int NumLayers = Advent8.Length / (Width * Height);
                Console.WriteLine("Length of Input: " + Advent8.Length);
                Console.WriteLine("Number of Layers: " + (Advent8.Length / (Width * Height)).ToString());
                Console.WriteLine("Layer has the least number of 0: " + "Layerx");
                Console.WriteLine("Layer Value: " + "Result");
                List<string> PictureLayers = new List<string>();
                string Result = string.Empty;
                for (int i = 0; i < NumLayers; i++)
                {
                    if (Advent8.Length > i * Width * Height)
                    {
                        PictureLayers.Add(Advent8.Substring(i * Width * Height, Width * Height));
                    }
                    else
                    {
                        PictureLayers.Add(Advent8.Substring(i * Width * Height, Advent8.Length - (i * Width * Height)));
                    }
                }
                // I have layers
                string TopLevel = string.Empty;
                TopLevel = PictureLayers.Count > 0 ? TopLevel = PictureLayers[0] : string.Empty;
                foreach(string str in PictureLayers)
                {
                    for(int i = 0; i < Width * Height; i++)
                    {
                        if (TopLevel[i] < str[i]) // if TopLevel is basically already 1 or 0, keep it chill
                        {

                        }
                        else if (TopLevel[i].Equals('2') && !str[i].Equals('2')) // Top layer = 2, and layer below is not 2
                        {
                            if (TopLevel == null)
                            {
                                throw new ArgumentNullException("input");
                            }
                            char[] chars = TopLevel.ToCharArray();
                            chars[i] = str[i];
                            TopLevel = new string(chars);
                        }
                    }
                }
                int Index = 0;
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("This is the Picture we have been waiting for.");
                Console.WriteLine("___________________________________________________");
                while(Index < Height)
                {
                    Console.WriteLine(TopLevel.Substring(Index*Width, Width));
                    Index++;
                }
                Console.WriteLine("___________________________________________________");
            }
            else if(key.Contains("9a"))
            {
                string[] Advent9Values = Properties.Resources.Advent9.Split(',');
                //string[] Advent9Values = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',');
                //string[] Advent9Values = "1102,34915192,34915192,7,4,7,99,0".Split(',');
                long input = 1;//(key.Contains("5a")) ? 1 : 5; //43210
                Dictionary<long, long> DictionaryOfInt = new Dictionary<long, long>();
                for (int i = 0; i < Advent9Values.Length; i++)
                {
                    DictionaryOfInt[i] = long.Parse(Advent9Values[i]);
                }
                long result = Advent9OpCodeReader(DictionaryOfInt, input);
                Console.WriteLine("Exiting Day 9a: " + result);
            }
            else
            {
                Console.WriteLine("No Input");
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static long Advent9OpCodeReader(Dictionary<long, long> TheCode, long input1, long input2 = 0)
        {
            long i = 0;
            long result = 0;
            bool flag = true;
            long relativeBase = 0;
            List<long> ListOfOutputs = new List<long>();
            while ((LastTwoDigitHelperAdvent5(TheCode[i]) == 1
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 2
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 3
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 4
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 5
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 6
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 7
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 8
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 9)
                && (LastTwoDigitHelperAdvent5(TheCode[i]) != 99))
            {
                long OpCode = LastTwoDigitHelperAdvent5(TheCode[i]);
                string LocCode = First3DigitHelperAdvent5(TheCode[i]).Substring(0, 3);
                if (OpCode == 1)
                {
                    WriteModeAdvent9(TheCode, LocCode, i + 3, 0, ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) + ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase), relativeBase);
                    i += 4;
                }
                else if (OpCode == 2)
                {
                    WriteModeAdvent9(TheCode, LocCode, i + 3, 0, ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) * ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase), relativeBase);
                    i += 4;
                }
                else if (OpCode == 3)
                {
                    // need to input
                    if (flag)
                    {
                        WriteModeAdvent9(TheCode, LocCode, i + 1, 2, input1, relativeBase);
                        flag = false;
                    }
                    else
                    {
                        WriteModeAdvent9(TheCode, LocCode, i + 1, 2, input2, relativeBase);
                    }
                    i += 2;
                }
                else if (OpCode == 4)
                {
                    // need to output
                    
                    ListOfOutputs.Add(ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase));
                    result = ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase);
                    Console.WriteLine(result);
                    i += 2;
                }
                else if (OpCode == 5)
                {
                    i = ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) != 0 ? ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase) : i + 3;
                }
                else if (OpCode == 6)
                {
                    i = ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) == 0 ? ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase) : i + 3;
                }
                else if (OpCode == 7)//sets things to 1 or 0 if compare is lessthan
                {
                    WriteModeAdvent9(TheCode, LocCode, i + 3, 0, ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) < ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase) ? 1 : 0, relativeBase);
                    i += 4;
                }
                else if (OpCode == 8)//sets things to 1 or 0 if  
                {
                    WriteModeAdvent9(TheCode, LocCode, i + 3, 0, ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase) == ReadModeAdvent9(TheCode, LocCode, i + 2, 1, relativeBase) ? 1 : 0, relativeBase);
                    i += 4;
                }
                else if (OpCode == 9)// sets relativebase
                {
                    relativeBase =+ ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase);
                    i += 2;
                }
                else
                {
                    Console.WriteLine("Instruction at was odd for i:" + i);
                }
            }
            if (LastTwoDigitHelperAdvent5(TheCode[i]) == 99 && ListOfOutputs.Count > 0)
            {
                Console.WriteLine("Amplifier ended properly");
                foreach (long test in ListOfOutputs)
                {
                    Console.WriteLine(test);
                }
            }
            return result;
        }
        private static string First3DigitHelperAdvent5(long value)
        {
            string result = value.ToString();
            result = result.PadLeft(5, '0');
            return result;
        }
        private static long LastTwoDigitHelperAdvent5(long value)
        {
            long result = 0;
            if (value.ToString().Length > 2)
            {
                result = long.Parse(value.ToString().Substring(value.ToString().Length - 2));
            }
            else if (value.ToString().Length == 1)
            {
                result = long.Parse(value.ToString().Last().ToString());
            }
            else if (value.ToString().Length == 2)
            {
                result = long.Parse(value.ToString().Substring(0, 2).ToString());
            }
            return result;
        }
        private static long ReadModeAdvent9(Dictionary<long, long> items, string value, long index, int pos, long relativeBase)
        {
            long result = 0;
            if (value.Length > 2)
            {
                bool Immidiate = value[pos] == '1';
                bool Relative = value[pos] == '2';
                if (Immidiate)
                {
                    if (items.ContainsKey(Math.Abs(index)))
                    {
                        result = items[index];
                    }
                    else
                    {
                        items[index] = 0;
                        result = items[index];
                    }
                }
                else if (Relative)
                {
                    if (items.ContainsKey(Math.Abs(items[index] + relativeBase)))
                    {
                        result = items[items[index] + relativeBase];
                    }
                    else
                    {
                        items[items[index] + relativeBase] = 0;
                        result = items[items[index] + relativeBase];
                    }
                }
                else//Positional
                {
                    if (items.ContainsKey(Math.Abs(items[index])))
                    {
                        result = items[Math.Abs(items[index])];
                    }
                    else
                    {
                        items[Math.Abs(items[index])] = 0;
                        result = items[Math.Abs(items[index])];
                    }
                }
            }

            return result;
        }
        private static void WriteModeAdvent9(Dictionary<long, long> items, string value, long index, int pos, long result, long relativeBase)
        {
            if (value.Length > 2)
            {
                bool Immidiate = value[pos] == '1';
                bool Relative = value[pos] == '2';
                if (Immidiate)
                {
                    if (items.ContainsKey(Math.Abs(index)))
                    {
                        items[index] = result;
                    }
                    else
                    {
                        items[index] = 0;
                        items[index] = result;
                    }
                }
                else if (Relative)
                {
                    if (items.ContainsKey(Math.Abs(items[index] + relativeBase)))
                    {
                        items[items[index] + relativeBase] = result;
                    }
                    else
                    {
                        items[items[index] + relativeBase] = 0;
                        items[items[index] + relativeBase] = result;
                    }
                }
                else//Positional
                {
                    if (items.ContainsKey(Math.Abs(items[index])))
                    {
                        items[Math.Abs(items[index])] = result;
                    }
                    else
                    {
                        items[Math.Abs(items[index])] = 0;
                        items[Math.Abs(items[index])] = result;
                    }
                }
            }
        }


        //// Thank you StackOverFlowGuy
        //// https://stackoverflow.com/questions/9367119/replacing-a-char-at-a-given-index-in-string
        //public static string ReplaceAt(this string input, int index, char newChar)
        //{
        //            if (input == null)
        //{
        //    throw new ArgumentNullException("input");
        //}
        //char[] chars = input.ToCharArray();
        //chars[index] = newChar;
        //return new string (chars);
        //}
    }

}
