using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019Solver_Silver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string key = Console.ReadLine();
            if (key.Contains("1a") || key.Contains("1b"))
            {
                string Advent1 = Properties.Resources.Advent1;
                string[] Advent1Values = Advent1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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
                string[] Advent2Values = Properties.Resources.Advent2.Split(",", StringSplitOptions.None);
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
                string[] Advent2Values = Properties.Resources.Advent2.Split(",", StringSplitOptions.None);
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
                string[] Advent3Values = Properties.Resources.Advent3.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string[] AdventWire1Values = Advent3Values[0].Split(",", StringSplitOptions.None);
                string[] AdventWire2Values = Advent3Values[1].Split(",", StringSplitOptions.None);
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
            else if (key.Contains("4a"))
            {
                // looking for all combinations that meet conditions
                // It is a six-digit number.
                // The value is within the range given in your puzzle input.
                // Two adjacent digits are the same(like 22 in 122345).
                // Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                int rangeLow = 165432;
                int rangeHigh = 707912;
                List<int> BruteForce = Enumerable.Range(165432, 707912-rangeLow).ToList();
                List<int> BruteForceResult = Advent4FilterCombo(BruteForce);
                Console.WriteLine("Total Combos:" + BruteForceResult.Count());
            }
            else
            {
                Console.WriteLine("No Input");
            }
            Console.ReadLine();
        }

        private static List<int> Advent4FilterCombo(List<int> listOfInts)
        {
            List<int> Result = new List<int>();
            foreach(int value in listOfInts)
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
                if(cond1 && cond2)
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
}
