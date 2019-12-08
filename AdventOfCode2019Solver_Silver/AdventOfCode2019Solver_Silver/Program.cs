using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventSolverOfCodeSilverCo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string key = Console.ReadLine();
            if (key.Contains("1a") || key.Contains("1b"))
            {
                string Advent1 = AdventOfCode2019Solver_Silver.Properties.Resources.Advent1;
                string[] Advent1Values = Advent1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string[] potato = "1,2,3,4,5,6,7,8,9,10".Split(",");
                int sum = 0;
                //string test = "100756";
                //sum = MassToFuelConverterIncludingFuelForFuel(test);
                //Console.WriteLine(sum);

                foreach (string mass in Advent1Values)
                {
                    sum += Advent1SolverMassToFuel(mass);
                }
                Console.WriteLine(sum);
            }
            else if (key.Contains("2a"))
            {
                string[] Advent2Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent2.Split(',', StringSplitOptions.None);
                Dictionary<int, int> DictionaryOfInt = new Dictionary<int, int>();
                int target = 0;
                for (int i = 0; i < Advent2Values.Length; i++)
                {
                    DictionaryOfInt[i] = Convert.ToInt32(Advent2Values[i]);
                }
                Console.WriteLine(Advent2SolverOpCodeNounVerb2(DictionaryOfInt, target));
            }
            else if (key.Contains("2b"))
            {
                string[] Advent2Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent2.Split(',', StringSplitOptions.None);
                Dictionary<int, int> DictionaryOfInt = new Dictionary<int, int>();
                int target = 19690720;
                for (int i = 0; i < Advent2Values.Length; i++)
                {
                    DictionaryOfInt[i] = Convert.ToInt32(Advent2Values[i]);
                }
                Console.WriteLine(Advent2SolverOpCodeNounVerb2(DictionaryOfInt, target));
            }
            else if (key.Contains("3a") || key.Contains("3b"))
            {
                DateTime dt = DateTime.Now;
                string[] Advent3Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent3.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string[] AdventWire1Values = Advent3Values[0].Split(',');
                string[] AdventWire2Values = Advent3Values[1].Split(',');
                //string[] AdventWire1Values = "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(",", StringSplitOptions.None);
                //string[] AdventWire2Values = "U62,R66,U55,R34,D71,R55,D58,R83".Split(",", StringSplitOptions.None);
                //string[] AdventWire1Values = "R8,U5,L5,D3".Split(",", StringSplitOptions.None);
                //string[] AdventWire2Values = "U7,R6,D4,L4".Split(",", StringSplitOptions.None);
                //string[] AdventWire1Values = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(",", StringSplitOptions.None);
                //string[] AdventWire2Values = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(",", StringSplitOptions.None);
                int leastCost = 0;

                List<Wire> Wire1 = Advent3WireCreate(AdventWire1Values);
                List<Wire> Wire2 = Advent3WireCreate(AdventWire2Values);

                Console.WriteLine("Length of Wire 1: " + Wire1.Count);
                Console.WriteLine("Length of Wire 2: " + Wire2.Count);
                Console.WriteLine("GO");
                leastCost = WireIntersector(Wire1, Wire2);
                TimeSpan ts = DateTime.Now - dt;
                Console.WriteLine("TotalTime : " + ts.TotalSeconds.ToString());
            }
            else if (key.Contains("4a") || key.Contains("4b"))
            {
                // looking for all combinations that meet conditions
                // It is a six-digit number.
                // The value is within the range given in your puzzle input.
                // Two adjacent digits are the same(like 22 in 122345).
                // Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                int rangeLow = 165432;
                int rangeHigh = 707912;
                List<int> BruteForce = Enumerable.Range(165432, 707912 - rangeLow).ToList();
                List<int> BruteForceResult = Advent4FilterCombo(BruteForce);
                Console.WriteLine("Total Combos:" + BruteForceResult.Count());
            }
            else if (key.Contains("5a") || key.Contains("5b"))
            {
                //string[] Advent5Values = Properties.Resources.Advent5.Split(',');
                //string[] Advent5Values = Properties.Resources.Advent7.Split(',');
                string[] Advent5Values = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(',');
                int input = 4;//(key.Contains("5a")) ? 1 : 5; //43210
                Dictionary<int, int> DictionaryOfInt = new Dictionary<int, int>();
                for (int i = 0; i < Advent5Values.Length; i++)
                {
                    DictionaryOfInt[i] = int.Parse(Advent5Values[i]);
                }

                int result = Advent5OpCodeReader(DictionaryOfInt, input);
                result = Advent5OpCodeReader(DictionaryOfInt, result);
                Console.WriteLine("exited day5" + result);
            }
            else if (key.Contains("6a"))
            {
                string[] Advent6Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent6.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //string[] Advent6Values = Properties.Resources.Advent6Test.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                Dictionary<string, List<string>> DictionaryOfOrbitChains = new Dictionary<string, List<string>>();
                foreach (string str in Advent6Values)
                {
                    if (!str.Equals(string.Empty))
                    {
                        string[] OrbitingPair = str.Split(')', StringSplitOptions.None);

                        if (!DictionaryOfOrbitChains.ContainsKey(OrbitingPair[0]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[0]] = new List<string>();
                            DictionaryOfOrbitChains[OrbitingPair[0]].Add(OrbitingPair[1]);
                        }
                        else if (DictionaryOfOrbitChains.ContainsKey(OrbitingPair[0]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[0]].Add(OrbitingPair[1]);
                        }
                        if (!DictionaryOfOrbitChains.ContainsKey(OrbitingPair[1]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[1]] = new List<string>();
                        }
                    }
                }
                int totalOrbitLines = 0;
                foreach (KeyValuePair<string, List<string>> Orbit in DictionaryOfOrbitChains)
                {
                    totalOrbitLines += GetOrbitCostAdvent6(DictionaryOfOrbitChains, Orbit.Key, 0);
                }
                Console.WriteLine("Advent 6, total connection: " + totalOrbitLines);
            }
            else if (key.Contains("6b"))
            {
                string[] Advent6Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent6.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //string[] Advent6Values = Properties.Resources.Advent6Test.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                Dictionary<string, List<string>> DictionaryOfOrbitChains = new Dictionary<string, List<string>>();
                foreach (string str in Advent6Values)
                {
                    if (!str.Equals(string.Empty))
                    {
                        string[] OrbitingPair = str.Split(')', StringSplitOptions.None);

                        if (!DictionaryOfOrbitChains.ContainsKey(OrbitingPair[0]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[0]] = new List<string>();
                            DictionaryOfOrbitChains[OrbitingPair[0]].Add(OrbitingPair[1]);
                        }
                        else if (DictionaryOfOrbitChains.ContainsKey(OrbitingPair[0]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[0]].Add(OrbitingPair[1]);
                        }
                        if (!DictionaryOfOrbitChains.ContainsKey(OrbitingPair[1]))
                        {
                            DictionaryOfOrbitChains[OrbitingPair[1]] = new List<string>();
                        }
                    }
                }
                string start = "YOU";
                string end = "SAN";
                string Path1 = GetOrbitPathAdvent6(DictionaryOfOrbitChains, start, start);
                string Path2 = GetOrbitPathAdvent6(DictionaryOfOrbitChains, end, end);
                int totalCost = 0;
                List<string> IndexedPath1 = Path1.Split(',').ToList<string>();
                List<string> IndexedPath2 = Path2.Split(',').ToList<string>();
                for (int i = IndexedPath1.Count - 1; i > 0; i--)
                {
                    if (IndexedPath2.Contains(IndexedPath1[i]))
                    {
                        totalCost = ((IndexedPath1.Count - 1) - i) + ((IndexedPath2.Count - 1) - IndexedPath2.IndexOf(IndexedPath1[i]));
                        totalCost = totalCost - 2; //removing intital jumps
                        break;
                    }
                }
                Console.WriteLine("Path1: " + Path1);
                Console.WriteLine("Path2: " + Path2);
                Console.WriteLine("Cost of Path: " + totalCost);
            }
            else if (key.Contains("7a"))
            {
                string[] Advent7Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent7.Split(',');
                //string[] Advent7Values = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0".Split(',');
                //string[] Advent7Values = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(',');

                List<string> BruteForce = new List<string>();
                BruteForce = AdventOfCode2019Solver_Silver.Properties.Resources.Advent7Helper.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();
                int highestThrust = 0;
                string Combo = string.Empty;
                int Input = 0;
                foreach (string str in BruteForce)
                {
                    Dictionary<int, int> AmpDictionary1 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary2 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary3 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary4 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary5 = new Dictionary<int, int>();
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary1[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary2[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary3[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary4[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary5[i] = int.Parse(Advent7Values[i]);
                    }
                    Input = 0;
                    // Set Settings
                    int result1 = Advent7OpCodeReader(AmpDictionary1, Int32.Parse(str[0].ToString()), Input);
                    int result2 = Advent7OpCodeReader(AmpDictionary2, Int32.Parse(str[1].ToString()), result1);
                    int result3 = Advent7OpCodeReader(AmpDictionary3, Int32.Parse(str[2].ToString()), result2);
                    int result4 = Advent7OpCodeReader(AmpDictionary4, Int32.Parse(str[3].ToString()), result3);
                    int result5 = Advent7OpCodeReader(AmpDictionary5, Int32.Parse(str[4].ToString()), result4);
                    // Generate Thrust
                    if (result5 > highestThrust)
                    {
                        highestThrust = result5;
                        Combo = str;
                    }
                }
                Console.WriteLine("Maximum Thrust: " + highestThrust);
                Console.WriteLine("Combo:" + Combo);
                //Amp1
                //Amp2
                //Amp3
                //Amp4
                //Amp5
                //Advent5OpCodeReader()
            }
            else if (key.Contains("7b"))
            {
                string[] Advent7Values = AdventOfCode2019Solver_Silver.Properties.Resources.Advent7.Split(',');
                //string[] Advent7Values = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0".Split(',');
                //string[] Advent7Values = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(',');
                //string[] Advent7Values = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5".Split(',');
                List<string> BruteForce = new List<string>();
                BruteForce = AdventOfCode2019Solver_Silver.Properties.Resources.Advent7Helper.Replace(",", string.Empty).Replace("0", "5").Replace("1", "6").Replace("2", "7").Replace("3", "8").Replace("4", "9").Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();
                int highestThrust = 0;
                string Combo = string.Empty;
                int Input = 0;
                int Result = 0;
                //BruteForce = new List<string>();
                //BruteForce.Add("98765");
                foreach (string str in BruteForce)
                {
                    Input = 0;
                    // Set Settings
                    Dictionary<int, int> AmpDictionary1 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary2 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary3 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary4 = new Dictionary<int, int>();
                    Dictionary<int, int> AmpDictionary5 = new Dictionary<int, int>();
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary1[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary2[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary3[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary4[i] = int.Parse(Advent7Values[i]);
                    }
                    for (int i = 0; i < Advent7Values.Length; i++)
                    {
                        AmpDictionary5[i] = int.Parse(Advent7Values[i]);
                    }
                    ThurstData Data1 = new ThurstData();
                    Data1.PhaseSetting = Int32.Parse(str[0].ToString());
                    Data1.Input.Add(0);
                    ThurstData Data2 = new ThurstData();
                    Data2.PhaseSetting = Int32.Parse(str[1].ToString());
                    ThurstData Data3 = new ThurstData();
                    Data3.PhaseSetting = Int32.Parse(str[2].ToString());
                    ThurstData Data4 = new ThurstData();
                    Data4.PhaseSetting = Int32.Parse(str[3].ToString());
                    ThurstData Data5 = new ThurstData();
                    Data5.PhaseSetting = Int32.Parse(str[4].ToString());
                    while (!Data5.Finished)
                    {
                        if (!Data1.Finished && !Data1.Waiting)
                        {
                            Data1 = Advent7OpCodeReaderAsync(AmpDictionary1, Data1);
                        }
                        if (Data1.HasOutput)
                        {
                            Data2.Input = new List<int>(Data1.Output);
                            Data1.Output = new List<int>();
                            Data2.Waiting = false;
                            Data1.HasOutput = false;
                        }
                        if (!Data2.Finished && !Data2.Waiting)
                        {
                            Data2 = Advent7OpCodeReaderAsync(AmpDictionary2, Data2);
                        }
                        if (Data2.HasOutput)
                        {
                            Data3.Input = new List<int>(Data2.Output);
                            Data2.Output = new List<int>();
                            Data3.Waiting = false;
                            Data2.HasOutput = false;
                        }
                        if (!Data3.Finished && !Data3.Waiting)
                        {
                            Data3 = Advent7OpCodeReaderAsync(AmpDictionary3, Data3);
                        }
                        if (Data3.HasOutput)
                        {
                            Data4.Input = new List<int>(Data3.Output);
                            Data3.Output = new List<int>();
                            Data4.Waiting = false;
                            Data3.HasOutput = false;
                        }
                        if (!Data4.Finished && !Data4.Waiting)
                        {
                            Data4 = Advent7OpCodeReaderAsync(AmpDictionary4, Data4);
                        }
                        if (Data4.HasOutput)
                        {
                            Data5.Input = new List<int>(Data4.Output);
                            Data4.Output = new List<int>();
                            Data5.Waiting = false;
                            Data4.HasOutput = false;
                        }
                        if (!Data5.Finished && !Data5.Waiting)
                        {
                            Data5 = Advent7OpCodeReaderAsync(AmpDictionary5, Data5);
                        }
                        if (Data5.HasOutput && !Data5.Finished)
                        {
                            Data1.Input = new List<int>(Data5.Output);
                            Data5.Output = new List<int>();
                            Data1.Waiting = false;
                            Data5.HasOutput = false;
                        }
                        if (Data5.Finished)
                        {
                            Result = Data5.Output[0];
                        }
                    }
                    // Generate Thrust
                    if (Result > highestThrust)
                    {
                        highestThrust = Result;
                        Combo = str;
                    }
                }
                Console.WriteLine("Maximum Thrust: " + highestThrust);
                Console.WriteLine("Combo:" + Combo);
                //Amp1
                //Amp2
                //Amp3
                //Amp4
                //Amp5
                //Advent5OpCodeReader()
            }
            else
            {
                Console.WriteLine("No Input");
            }
            Console.ReadLine();
        }
        public class ThurstData
        {
            public List<int> Input = new List<int>();
            public List<int> Output = new List<int>();
            public int Index = 0;
            public int PhaseSetting = 0;
            public bool Started = false;
            public bool Finished = false;
            public bool Waiting = false;
            public bool HasOutput = false;
        }
        private static ThurstData Advent7OpCodeReaderAsync(Dictionary<int, int> TheCode, ThurstData thrustData)
        {
            int i = thrustData.Index;
            List<int> ListOfOutputs = new List<int>();
            while ((LastTwoDigitHelperAdvent5(TheCode[i]) == 1
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 2
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 3
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 4
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 5
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 6
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 7
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 8)
                && (LastTwoDigitHelperAdvent5(TheCode[i]) != 99))
            {
                int OpCode = LastTwoDigitHelperAdvent5(TheCode[i]);
                string LocCode = First3DigitHelperAdvent5(TheCode[i]).Substring(0, 3);
                if (OpCode == 1)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) + ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 2)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) * ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 3)
                {
                    // need to input
                    if (!thrustData.Started)
                    {
                        TheCode[TheCode[i + 1]] = thrustData.PhaseSetting;
                        thrustData.Started = true;
                    }
                    else if (thrustData.Input.Count > 0)
                    {
                        TheCode[TheCode[i + 1]] = thrustData.Input[0];
                        thrustData.Input.RemoveAt(0);
                    }
                    else
                    {
                        thrustData.Index = i;
                        thrustData.Waiting = true;
                        break;//attempt to pause
                    }
                    i += 2;
                }
                else if (OpCode == 4)
                {
                    // need to output
                    ListOfOutputs.Add(ReadModeAdvent5(TheCode, LocCode, i + 1, 2));
                    thrustData.Output.Add(ReadModeAdvent5(TheCode, LocCode, i + 1, 2));
                    i += 2;
                    thrustData.HasOutput = true;
                }
                //jump
                else if (OpCode == 5)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) != 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                //jump
                else if (OpCode == 6)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                else if (OpCode == 7)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) < ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else if (OpCode == 8)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else
                {
                    Console.WriteLine("Instruction at was odd for i:" + i);
                }
            }
            if (LastTwoDigitHelperAdvent5(TheCode[i]) == 99 && ListOfOutputs.Count > 0)
            {
                thrustData.Finished = true;
                thrustData.Index = i;
                Console.WriteLine("Amplifier ended properly");
                foreach (int test in ListOfOutputs)
                {
                    Console.WriteLine(test);
                }
            }
            return thrustData;
        }


        private static int Advent7OpCodeReader(Dictionary<int, int> TheCode, int input1, int input2)
        {
            int i = 0;
            int result = 0;
            bool flag = true;
            List<int> ListOfOutputs = new List<int>();
            while ((LastTwoDigitHelperAdvent5(TheCode[i]) == 1
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 2
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 3
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 4
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 5
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 6
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 7
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 8)
                && (LastTwoDigitHelperAdvent5(TheCode[i]) != 99))
            {
                int OpCode = LastTwoDigitHelperAdvent5(TheCode[i]);
                string LocCode = First3DigitHelperAdvent5(TheCode[i]).Substring(0, 3);
                if (OpCode == 1)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) + ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 2)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) * ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 3)
                {
                    // need to input
                    if (flag)
                    {
                        TheCode[TheCode[i + 1]] = input1;
                        flag = false;
                    }
                    else
                    {
                        TheCode[TheCode[i + 1]] = input2;
                    }
                    i += 2;
                }
                else if (OpCode == 4)
                {
                    // need to output
                    ListOfOutputs.Add(ReadModeAdvent5(TheCode, LocCode, i + 1, 2));
                    result = ReadModeAdvent5(TheCode, LocCode, i + 1, 2);
                    i += 2;
                }
                else if (OpCode == 5)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) != 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                else if (OpCode == 6)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                else if (OpCode == 7)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) < ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else if (OpCode == 8)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else
                {
                    Console.WriteLine("Instruction at was odd for i:" + i);
                }
            }
            if (LastTwoDigitHelperAdvent5(TheCode[i]) == 99 && ListOfOutputs.Count > 0)
            {
                Console.WriteLine("Amplifier ended properly");
                foreach (int test in ListOfOutputs)
                {
                    Console.WriteLine(test);
                }
            }
            return result;
        }
        private static string GetOrbitPathAdvent6(Dictionary<string, List<string>> DictionaryOfOrbitChains, string Orbiter, string traveled)
        {
            string DirectOrbit = string.Empty;
            if (!Orbiter.Equals("COM"))
            {
                foreach (KeyValuePair<string, List<string>> Orbits in DictionaryOfOrbitChains)
                {
                    if (Orbits.Value.Contains(Orbiter))
                    {
                        DirectOrbit = Orbits.Key;
                        break;
                    }
                }
                if (DirectOrbit != string.Empty)
                {
                    traveled = GetOrbitPathAdvent6(DictionaryOfOrbitChains, DirectOrbit, DirectOrbit + "," + traveled);
                }
            }
            return traveled;
        }
        private static int GetOrbitCostAdvent6(Dictionary<string, List<string>> DictionaryOfOrbitChains, string Orbiter, int traveled)
        {
            string DirectOrbit = string.Empty;
            if (!Orbiter.Equals("COM"))
            {
                foreach (KeyValuePair<string, List<string>> Orbits in DictionaryOfOrbitChains)
                {
                    if (Orbits.Value.Contains(Orbiter))
                    {
                        DirectOrbit = Orbits.Key;
                        break;
                    }
                }
                if (DirectOrbit != string.Empty)
                {
                    traveled = GetOrbitCostAdvent6(DictionaryOfOrbitChains, DirectOrbit, traveled + 1);
                }
            }
            return traveled;
        }
        private static int Advent5OpCodeReader(Dictionary<int, int> TheCode, int input)
        {
            int i = 0;
            int result = 0;
            List<int> ListOfOutputs = new List<int>();
            while ((LastTwoDigitHelperAdvent5(TheCode[i]) == 1
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 2
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 3
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 4
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 5
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 6
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 7
                || LastTwoDigitHelperAdvent5(TheCode[i]) == 8)
                && (LastTwoDigitHelperAdvent5(TheCode[i]) != 99))
            {
                int OpCode = LastTwoDigitHelperAdvent5(TheCode[i]);
                string LocCode = First3DigitHelperAdvent5(TheCode[i]).Substring(0, 3);
                if (OpCode == 1)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) + ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 2)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) * ReadModeAdvent5(TheCode, LocCode, i + 2, 1);
                    i += 4;
                }
                else if (OpCode == 3)
                {
                    // need to input
                    TheCode[TheCode[i + 1]] = input;
                    i += 2;
                }
                else if (OpCode == 4)
                {
                    // need to output
                    Console.WriteLine("index: " + i);
                    Console.WriteLine("value at index: " + TheCode[TheCode[i + 1]]);
                    Console.WriteLine("value at postion: " + (ReadModeAdvent5(TheCode, LocCode, i + 1, 2)));
                    ListOfOutputs.Add(ReadModeAdvent5(TheCode, LocCode, i + 1, 2));
                    result = ReadModeAdvent5(TheCode, LocCode, i + 1, 2);
                    i += 2;
                }
                else if (OpCode == 5)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) != 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                else if (OpCode == 6)
                {
                    i = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == 0 ? ReadModeAdvent5(TheCode, LocCode, i + 2, 1) : i + 3;
                }
                else if (OpCode == 7)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) < ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else if (OpCode == 8)
                {
                    TheCode[TheCode[i + 3]] = ReadModeAdvent5(TheCode, LocCode, i + 1, 2) == ReadModeAdvent5(TheCode, LocCode, i + 2, 1) ? 1 : 0;
                    i += 4;
                }
                else
                {
                    Console.WriteLine("Instruction at was odd for i:" + i);
                }
            }
            if (LastTwoDigitHelperAdvent5(TheCode[i]) == 99 && ListOfOutputs.Count > 0)
            {
                Console.WriteLine("Amplifier ended properly");
                foreach (int test in ListOfOutputs)
                {
                    Console.WriteLine(test);
                }
            }
            return result;
        }
        private static int ReadModeAdvent5(Dictionary<int, int> items, string value, int index, int pos)
        {
            int result = 0;
            if (value.Length > 2)
            {
                bool Immidiate = value[pos] == '1';
                if (Immidiate)
                {
                    result = items[index];
                }
                else
                {
                    if (items.ContainsKey(Math.Abs(items[index])))
                        result = items[Math.Abs(items[index])];
                    else
                        result = 0;
                }
            }

            return result;
        }
        private static string First3DigitHelperAdvent5(int value)
        {
            string result = value.ToString();
            result = result.PadLeft(5, '0');
            return result;
        }
        private static int LastTwoDigitHelperAdvent5(int value)
        {
            int result = 0;
            if (value.ToString().Length > 2)
            {
                result = int.Parse(value.ToString().Substring(value.ToString().Length - 2));
            }
            else if (value.ToString().Length == 1)
            {
                result = int.Parse(value.ToString().Last().ToString());
            }
            else if (value.ToString().Length == 2)
            {
                result = int.Parse(value.ToString().Substring(0, 2).ToString());
            }
            return result;
        }
        private static List<int> Advent4FilterCombo(List<int> listOfInts)
        {
            List<int> Result = new List<int>();
            foreach (int value in listOfInts)
            {
                bool cond1 = false;
                bool cond2 = false;
                string parsedValue = value.ToString();
                cond1 = parsedValue[0] <= parsedValue[1]
                    && parsedValue[1] <= parsedValue[2]
                    && parsedValue[2] <= parsedValue[3]
                    && parsedValue[3] <= parsedValue[4]
                    && parsedValue[4] <= parsedValue[5];

                cond2 = (parsedValue[0] == parsedValue[1] && parsedValue[1] != parsedValue[2])
                    || (parsedValue[1] == parsedValue[2] && parsedValue[2] != parsedValue[3] && parsedValue[1] != parsedValue[0])
                    || (parsedValue[2] == parsedValue[3] && parsedValue[3] != parsedValue[4] && parsedValue[2] != parsedValue[1])
                    || (parsedValue[3] == parsedValue[4] && parsedValue[4] != parsedValue[5] && parsedValue[3] != parsedValue[2])
                    || (parsedValue[4] == parsedValue[5] && parsedValue[4] != parsedValue[3]);
                if (cond1 && cond2)
                {
                    Result.Add(value);
                }
            }
            return Result;
        }
        private static int WireIntersector(List<Wire> Wire1, List<Wire> Wire2)
        {
            int smallDistance = 0;
            int leastCostDistance = 0;
            int leastCost = 0;
            foreach (Wire wire1 in Wire1)
            {
                if (wire1.Direction != 0)
                {
                    // x direction can only intersect on movement in the y direction
                    if (wire1.Direction == 1)
                    {
                        var Results = from Wire wire in Wire2
                                      where (wire.Direction == 2)
                                      select wire;
                        if (Results.Count() != 0)
                        {
                            var FilteredResults = from Wire wire in Results // x =  5
                                                  where
                                                 (wire.X <= wire1.X && wire.X >= wire1.X - wire1.Length)
                                                 || (wire.X <= wire1.X - wire1.Length && wire.X >= wire1.X)
                                                  select wire;
                            if (FilteredResults.Count() != 0)
                            {
                                var FinalResults = from Wire wire in FilteredResults
                                                   where
                                                  (wire.Y > wire1.Y && wire.Y - wire.Length < wire1.Y)
                                                  || (wire.Y - wire.Length > wire1.Y && wire.Y < wire1.Y)
                                                   select wire;
                                if (FinalResults.Count() != 0)
                                {
                                    foreach (Wire wire in FinalResults)
                                    {
                                        int manDistance = ManhattanDistance(0, 0, wire.X, wire1.Y);
                                        int wireCost = GetWireCost(Wire1, wire1.Index) + GetWireCost(Wire2, wire.Index);
                                        int wireOverCost = 0;
                                        if (wire1.Length > 0)
                                        {
                                            wireOverCost += Math.Abs(wire1.X - wire.X);
                                        }
                                        else if (wire1.Length < 0)
                                        {
                                            wireOverCost += Math.Abs(wire.X - wire1.X);
                                        }

                                        if (wire.Length > 0)
                                        {
                                            wireOverCost += Math.Abs(wire.Y - wire1.Y);
                                        }
                                        else if (wire.Length < 0)
                                        {
                                            wireOverCost += Math.Abs(wire1.Y - wire.Y);
                                        }
                                        wireCost -= wireOverCost;
                                        if (smallDistance == 0)
                                        {
                                            smallDistance = manDistance;
                                        }
                                        else if (manDistance < smallDistance && manDistance > 0)
                                        {
                                            smallDistance = manDistance;
                                        }

                                        if (leastCostDistance == 0)
                                        {
                                            leastCostDistance = manDistance;
                                            leastCost = wireCost;
                                        }
                                        else if (wireCost < leastCost && wireCost > 0)
                                        {
                                            leastCostDistance = manDistance;
                                            leastCost = wireCost;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (wire1.Direction == 2)
                    {
                        var Results = from Wire wire in Wire2
                                      where (wire.Direction == 1)
                                      select wire;
                        if (Results.Count() != 0)
                        {
                            var FilteredResults = from Wire wire in Results // x =  5
                                                  where
                                                 (wire1.X <= wire.X && wire1.X >= wire.X - wire.Length)
                                                 || (wire1.X <= wire.X - wire.Length && wire1.X >= wire.X)
                                                  select wire;
                            if (FilteredResults.Count() != 0)
                            {
                                var FinalResults = from Wire wire in FilteredResults
                                                   where
                                                  (wire1.Y > wire.Y && wire1.Y - wire1.Length < wire.Y)
                                                  || (wire1.Y - wire1.Length > wire.Y && wire1.Y < wire.Y)
                                                   select wire;
                                if (FinalResults.Count() != 0)
                                {
                                    foreach (Wire wire in FinalResults)
                                    {
                                        int manDistance = ManhattanDistance(0, 0, wire1.X, wire.Y);
                                        int wireCost = GetWireCost(Wire1, wire1.Index) + GetWireCost(Wire2, wire.Index);
                                        int wireOverCost = 0;

                                        if (wire1.Length > 0)
                                        {
                                            wireOverCost += Math.Abs(wire1.Y - wire.Y);
                                        }
                                        else if (wire1.Length < 0)
                                        {
                                            wireOverCost += Math.Abs(wire.Y - wire1.Y);
                                        }

                                        if (wire.Length > 0)
                                        {
                                            wireOverCost += Math.Abs(wire.X - wire1.X);
                                        }
                                        else if (wire.Length < 0)
                                        {
                                            wireOverCost += Math.Abs(wire1.X - wire.X);
                                        }

                                        wireCost -= wireOverCost;
                                        if (smallDistance == 0)
                                        {
                                            smallDistance = manDistance;
                                        }
                                        else if (manDistance < smallDistance && manDistance > 0)
                                        {
                                            smallDistance = manDistance;
                                        }
                                        if (leastCostDistance == 0)
                                        {
                                            leastCostDistance = manDistance;
                                            leastCost = wireCost;
                                        }
                                        else if (wireCost < leastCost && wireCost > 0)
                                        {
                                            leastCostDistance = manDistance;
                                            leastCost = wireCost;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Shortest Distance: " + smallDistance);
            Console.WriteLine("Shortest Cost Distance: " + leastCostDistance);
            Console.WriteLine("Cost of least cost intersection: " + leastCost);
            return leastCost;
        }
        private static int Advent1SolverMassToFuel(string moduleMass)
        {
            int MassOfFuel = 0;
            if (ConvertToResult(moduleMass) <= 0)
            {
                MassOfFuel = 0;
            }
            else
            {
                MassOfFuel = ConvertToResult(moduleMass);
                MassOfFuel += Advent1SolverMassToFuel((Convert.ToInt32(Math.Floor(Convert.ToDouble(moduleMass) / 3)) - 2).ToString());
            }
            return MassOfFuel;
        }
        private static int Advent2SolverOpCodeToPos1(Dictionary<int, int> TheCode)
        {
            int i = 0;
            while ((TheCode[i] == 1 || TheCode[i] == 2) && (TheCode[i] != 99))
            {
                if (TheCode[i] == 1)
                {
                    TheCode[TheCode[i + 3]] = TheCode[TheCode[i + 1]] + TheCode[TheCode[i + 2]];
                    i += 4;
                }
                else if (TheCode[i] == 2)
                {
                    TheCode[TheCode[i + 3]] = TheCode[TheCode[i + 1]] * TheCode[TheCode[i + 2]];
                    i += 4;
                }
            }
            return TheCode[0];
        }
        private static int Advent2SolverOpCodeNounVerb2(Dictionary<int, int> TheInput, int Direction)
        {
            int Noun = 0;
            int Verb = 0;
            int indexMax = 0;
            int index = 0;
            Dictionary<int, string> Coords = new Dictionary<int, string>();
            bool IsDone = false;
            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    Coords[indexMax] = (j.ToString() + "," + i.ToString());
                    indexMax++;
                }
            }
            if (Direction == 0)
            {
                Noun = 12;
                Verb = 2;
                TheInput[1] = Noun;
                TheInput[2] = Verb;
                return Advent2SolverOpCodeToPos1(TheInput);
            }
            else
            {
                int Result = 0;
                Dictionary<int, int> TheTestInput = new Dictionary<int, int>(TheInput);
                while (!IsDone)
                {
                    Result = Advent2SolverOpCodeToPos1(TheTestInput);
                    if (Result != Direction && index < indexMax)
                    {
                        TheTestInput = new Dictionary<int, int>(TheInput);
                        string[] NounVerb = Coords[index].Split(",", StringSplitOptions.None);
                        TheTestInput[1] = int.Parse(NounVerb[0]);
                        TheTestInput[2] = int.Parse(NounVerb[1]);
                        index++;
                    }
                    else if (Result == Direction)
                    {
                        Console.WriteLine("This is the part of 2b " + Coords[index]);
                        Console.WriteLine("Answer is: " + (100 * TheTestInput[1] + TheTestInput[2]));
                        IsDone = true;
                    }
                    else if (index >= indexMax)
                    {
                        IsDone = true;
                        Console.WriteLine("Never Made It");
                    }
                }
                return Result;
            }
        }
        private static int ConvertToResult(string moduleMass)
        {
            return Convert.ToInt32(Math.Floor(Convert.ToDouble(moduleMass) / 3)) - 2;
        }
        private static List<Wire> Advent3WireCreate(string[] WireDirections)
        {
            List<Wire> Wire = new List<Wire>();
            int index = 0;
            foreach (string str in WireDirections)
            {
                string direction = str.Substring(0, 1); //grabs the first character, 0 means start, 1 right, 2 left, 3 Up, 4 down
                int length = Convert.ToInt32(str.Substring(1, str.Length - 1));// grabs the next couple of characters
                if (Wire.Count == 0)
                {
                    if (direction.Equals("R"))
                    {
                        Wire.Add(new Wire(0, 0, 0, 0, 0));
                        index++;
                        Wire.Add(new Wire(Wire[index - 1].X + length, Wire[index - 1].Y, length, 1, index));
                        index++;
                    }
                    else if (direction.Equals("L"))
                    {
                        Wire.Add(new Wire(0, 0, 0, 0, 0));
                        index++;
                        Wire.Add(new Wire(Wire[index - 1].X - length, Wire[index - 1].Y, -length, 1, index));
                        index++;
                    }
                    else if (direction.Equals("U"))
                    {
                        Wire.Add(new Wire(0, 0, 0, 0, 0));
                        index++;
                        Wire.Add(new Wire(Wire[index - 1].X, Wire[index - 1].Y + length, length, 2, index));
                        index++;
                    }
                    else if (direction.Equals("D"))
                    {
                        Wire.Add(new Wire(0, 0, 0, 0, 0));
                        index++;
                        Wire.Add(new Wire(Wire[index - 1].X, Wire[index - 1].Y - length, -length, 2, index));
                        index++;
                    }
                }
                else
                {
                    if (direction.Equals("R"))
                    {
                        Wire.Add(new Wire(Wire[index - 1].X + length, Wire[index - 1].Y, length, 1, index));
                        index++;
                    }
                    else if (direction.Equals("L"))
                    {
                        Wire.Add(new Wire(Wire[index - 1].X - length, Wire[index - 1].Y, -length, 1, index));
                        index++;
                    }
                    else if (direction.Equals("U"))
                    {
                        Wire.Add(new Wire(Wire[index - 1].X, Wire[index - 1].Y + length, length, 2, index));
                        index++;
                    }
                    else if (direction.Equals("D"))
                    {
                        Wire.Add(new Wire(Wire[index - 1].X, Wire[index - 1].Y - length, -length, 2, index));
                        index++;
                    }
                }
            }
            return Wire;
        }
        private static int ManhattanDistance(int x1, int y1, int x2, int y2)
        {
            int distance = 0;
            distance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return distance;
        }
        private static int GetWireCost(List<Wire> wire, int index)
        {
            int wireCost = 0;
            for (int i = 0; i <= index; i++)
            {
                wireCost += Math.Abs(wire[i].Length);
            }
            return wireCost;
        }
    }
    public class Wire
    {
        public int X = 0;
        public int Y = 0;
        public int Length = 0;
        public int Direction = 0;
        public int Index = 0;
        public Wire(int x, int y, int length, int direction, int index)
        {
            this.X = x;
            this.Y = y;
            this.Length = length;
            this.Direction = direction;
            this.Index = index;
        }
    }

    public class Orbiter
    {
        string DirectOrbits = string.Empty;
        List<string> Orblets = new List<string>();
        string OrbitID = string.Empty;
    }
}
