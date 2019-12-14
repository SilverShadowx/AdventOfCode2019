using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    if (NumZeros < LeastZero)
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
            else if (key.Contains("8b"))
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
                foreach (string str in PictureLayers)
                {
                    for (int i = 0; i < Width * Height; i++)
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
                while (Index < Height)
                {
                    Console.WriteLine(TopLevel.Substring(Index * Width, Width));
                    Index++;
                }
                Console.WriteLine("___________________________________________________");
            }
            else if (key.Contains("9a") || key.Contains("9b"))
            {
                string[] Advent9Values = Properties.Resources.Advent9.Split(',');
                //string[] Advent9Values = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',');
                //string[] Advent9Values = "1102,34915192,34915192,7,4,7,99,0".Split(','); 
                //string[] Advent9Values = "3,225,1,225,6,6,1100,1,238,225,104,0,1001,210,88,224,101,-143,224,224,4,224,1002,223,8,223,101,3,224,224,1,223,224,223,101,42,92,224,101,-78,224,224,4,224,1002,223,8,223,1001,224,3,224,1,223,224,223,1101,73,10,225,1102,38,21,225,1102,62,32,225,1,218,61,224,1001,224,-132,224,4,224,102,8,223,223,1001,224,5,224,1,224,223,223,1102,19,36,225,102,79,65,224,101,-4898,224,224,4,224,102,8,223,223,101,4,224,224,1,224,223,223,1101,66,56,224,1001,224,-122,224,4,224,102,8,223,223,1001,224,2,224,1,224,223,223,1002,58,82,224,101,-820,224,224,4,224,1002,223,8,223,101,3,224,224,1,223,224,223,2,206,214,224,1001,224,-648,224,4,224,102,8,223,223,101,3,224,224,1,223,224,223,1102,76,56,224,1001,224,-4256,224,4,224,102,8,223,223,1001,224,6,224,1,223,224,223,1102,37,8,225,1101,82,55,225,1102,76,81,225,1101,10,94,225,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,8,226,677,224,102,2,223,223,1005,224,329,101,1,223,223,1008,677,677,224,1002,223,2,223,1006,224,344,1001,223,1,223,107,226,677,224,102,2,223,223,1005,224,359,1001,223,1,223,1108,677,677,224,1002,223,2,223,1006,224,374,101,1,223,223,1107,677,677,224,1002,223,2,223,1006,224,389,101,1,223,223,108,226,677,224,102,2,223,223,1006,224,404,101,1,223,223,7,677,677,224,102,2,223,223,1006,224,419,101,1,223,223,108,677,677,224,102,2,223,223,1006,224,434,1001,223,1,223,7,226,677,224,102,2,223,223,1006,224,449,1001,223,1,223,108,226,226,224,102,2,223,223,1005,224,464,101,1,223,223,8,226,226,224,1002,223,2,223,1006,224,479,101,1,223,223,1008,226,226,224,102,2,223,223,1005,224,494,1001,223,1,223,1008,677,226,224,1002,223,2,223,1005,224,509,101,1,223,223,7,677,226,224,102,2,223,223,1006,224,524,101,1,223,223,1007,677,226,224,1002,223,2,223,1006,224,539,1001,223,1,223,1108,677,226,224,102,2,223,223,1005,224,554,1001,223,1,223,8,677,226,224,1002,223,2,223,1005,224,569,101,1,223,223,1108,226,677,224,1002,223,2,223,1005,224,584,101,1,223,223,1107,677,226,224,102,2,223,223,1006,224,599,101,1,223,223,107,226,226,224,102,2,223,223,1006,224,614,1001,223,1,223,107,677,677,224,1002,223,2,223,1005,224,629,1001,223,1,223,1107,226,677,224,1002,223,2,223,1006,224,644,101,1,223,223,1007,677,677,224,102,2,223,223,1006,224,659,1001,223,1,223,1007,226,226,224,1002,223,2,223,1006,224,674,1001,223,1,223,4,223,99,226".Split(',');
                //string[] Advent9Values = "104,1125899906842624,99".Split(',');
                long input = key.Contains("9b") ? 2 : 1;//(key.Contains("5a")) ? 1 : 5; //43210
                Dictionary<long, long> DictionaryOfInt = new Dictionary<long, long>();
                for (int i = 0; i < Advent9Values.Length; i++)
                {
                    DictionaryOfInt[i] = long.Parse(Advent9Values[i]);
                }
                long result = Advent9OpCodeReader(DictionaryOfInt, input);
                Console.WriteLine("Exiting Day 9a: " + result);
            }
            else if (key.Contains("10a"))
            {
                List<string> AsteroidLocations = Properties.Resources.Advent10.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                //List<string> AsteroidLocations = Properties.Resources.Advent10Test1.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();//40 asters
                //List<string> AsteroidLocations = Properties.Resources.Advent10Test2.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();//40 asters
                //List<string> AsteroidLocations = Properties.Resources.Advent10Test3.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();//40 asters
                List<Asteroid> AsteroidCoordPairs = new List<Asteroid>();
                int HighestCount = 0;
                string Coordinates = string.Empty;
                int[] CoordinatesAsRectangular = { 0, 0 };
                Asteroid AsteroidWithLaser = new Asteroid(0, 0);
                for (int y = 0; y < AsteroidLocations.Count; y++)
                {
                    string str = AsteroidLocations[y];
                    for (int x = 0; x < str.Length; x++)
                    {
                        if (str[x] == '#')
                        {
                            AsteroidCoordPairs.Add(new Asteroid(x, y));
                        }
                    }
                }
                foreach (Asteroid Astra in AsteroidCoordPairs)
                {
                    List<Asteroid> AsteroidsInBoard = new List<Asteroid>(AsteroidCoordPairs);
                    Dictionary<int, Asteroid> CurrentDetected = new Dictionary<int, Asteroid>();
                    List<string> AsteroidsInSight = new List<string>();
                    int Index = 0;
                    // I'm sure there is an simpler way
                    foreach (Asteroid Aether in AsteroidsInBoard)
                    {
                        if (!((Aether.X == Astra.X) && (Aether.Y == Astra.Y)))
                        {
                            CurrentDetected[Index] = Aether;
                            Index++;
                        }
                        else
                        {

                        }
                    }
                    // comparing current Asteroid to all others
                    foreach (KeyValuePair<int, Asteroid> GibbsFreeEnergy in CurrentDetected)
                    {
                        // Get slope, y2 - y1/ x1 - x2
                        bool NegativeY = ((Astra.Y - GibbsFreeEnergy.Value.Y) < 0);
                        bool NegativeX = ((Astra.X - GibbsFreeEnergy.Value.X) < 0);
                        int[] RunRise = { Math.Abs(Astra.X - GibbsFreeEnergy.Value.X), Math.Abs(Astra.Y - GibbsFreeEnergy.Value.Y) };
                        Simplify(RunRise);
                        // Positive Slopes
                        if (!(AsteroidsInSight.Contains(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))) && !NegativeY && !NegativeX)
                        {
                            AsteroidsInSight.Add(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                        }
                        // Down and Right
                        if (NegativeY && !NegativeX)
                        {
                            RunRise[1] = RunRise[1] * -1;
                            if (!(AsteroidsInSight.Contains(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsInSight.Add(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                            }
                        }
                        // Up and Left
                        if (!NegativeY && NegativeX)
                        {
                            RunRise[0] = RunRise[0] * -1;
                            if (!(AsteroidsInSight.Contains(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsInSight.Add(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                            }
                        }
                        // Down and Right
                        if (NegativeY && NegativeX)
                        {
                            RunRise[0] = RunRise[0] * -1;
                            RunRise[1] = RunRise[1] * -1;
                            if (!(AsteroidsInSight.Contains(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsInSight.Add(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                            }
                        }


                    }
                    Astra.VisibleAsteroids = AsteroidsInSight.Count;
                    if (AsteroidsInSight.Count > HighestCount)
                    {
                        HighestCount = AsteroidsInSight.Count;
                        Coordinates = Astra.X.ToString() + ", " + Astra.Y.ToString();
                        CoordinatesAsRectangular[0] = Astra.X;
                        CoordinatesAsRectangular[1] = Astra.Y;
                        AsteroidWithLaser = Astra;
                    }
                }
                //int[] intArray = { Math.Abs(-4), 8 };
                //Simplify(intArray);
                Console.WriteLine("Exiting Day 10a Coordinates found: " + Coordinates + " With Number of Visible Asteroids." + HighestCount);
            }
            else if (key.Contains("10b"))
            {
                List<string> AsteroidLocations = Properties.Resources.Advent10.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();//40 asters
                List<Asteroid> AsteroidCoordPairs = new List<Asteroid>();
                Asteroid AsteroidWithLaser = new Asteroid(11, 11);
                for (int y = 0; y < AsteroidLocations.Count; y++)
                {
                    string str = AsteroidLocations[y];
                    for (int x = 0; x < str.Length; x++)
                    {
                        if (str[x] == '#')
                        {
                            AsteroidCoordPairs.Add(new Asteroid(x, y));
                        }
                    }
                }
                //Start 10b
                List<Asteroid> AsteroidsInMap = new List<Asteroid>(AsteroidCoordPairs);
                Dictionary<int, Asteroid> AsteroidsLiving = new Dictionary<int, Asteroid>();
                int NumberOfAsteroids = 0;
                bool NotDestoryed = true;
                int Destoryed = 0;
                // I'm sure there is an simpler way
                AsteroidsInMap = AsteroidsInMap.OrderBy(o => o.X).ToList();
                foreach (Asteroid Aether in AsteroidsInMap)
                {
                    if (!((Aether.X == AsteroidWithLaser.X) && (Aether.Y == AsteroidWithLaser.Y)))
                    {
                        AsteroidsLiving[NumberOfAsteroids] = Aether;
                        NumberOfAsteroids++;
                    }
                    else
                    {

                    }
                }
                while (NotDestoryed)
                {
                    List<Asteroid> Detected = new List<Asteroid>();
                    List<Asteroid> NotDetected = new List<Asteroid>();
                    Dictionary<int, string> AsteroidsLineOfSight = new Dictionary<int, string>();
                    // remove Asteroids in Asteroid living based on those detected
                    int numberDetect = 0;
                    foreach (KeyValuePair<int, Asteroid> GibbsFreeEnergy in AsteroidsLiving)
                    {
                        // Get slope, y2 - y1/ x1 - x2
                        bool NegativeY = ((GibbsFreeEnergy.Value.Y - AsteroidWithLaser.Y) < 0);
                        bool NegativeX = ((GibbsFreeEnergy.Value.X - AsteroidWithLaser.X) < 0);
                        int[] RunRise = { Math.Abs(AsteroidWithLaser.X - GibbsFreeEnergy.Value.X), Math.Abs(AsteroidWithLaser.Y - GibbsFreeEnergy.Value.Y) };
                        Simplify(RunRise);
                        // Positive Slopes
                        if (!NegativeX && !NegativeY)
                        {
                            if (!(AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))) && !NegativeY && !NegativeX)
                            {
                                AsteroidsLineOfSight[numberDetect] = (String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                                Detected.Add(GibbsFreeEnergy.Value);
                                numberDetect++;
                            }
                            else if (AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray())))
                            {
                                var otherAster = AsteroidsLineOfSight.Where(kvp => (kvp.Value == (String.Join(",", RunRise.Select(p => p.ToString()))))).First();
                                if (ManhattanDistance(Detected[otherAster.Key].X, Detected[otherAster.Key].Y, AsteroidWithLaser.X, AsteroidWithLaser.Y) > ManhattanDistance(GibbsFreeEnergy.Value.X, GibbsFreeEnergy.Value.Y, AsteroidWithLaser.X, AsteroidWithLaser.Y))
                                {
                                    Detected[otherAster.Key] = GibbsFreeEnergy.Value;
                                }
                            }
                        }
                        // Down and Right
                        if (NegativeY && !NegativeX)
                        {
                            RunRise[1] = RunRise[1] * -1;
                            if (!(AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsLineOfSight[numberDetect] = (String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                                Detected.Add(GibbsFreeEnergy.Value);
                                numberDetect++;
                            }
                            else if (AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray())))
                            {
                                var otherAster = AsteroidsLineOfSight.Where(kvp => (kvp.Value == (String.Join(",", RunRise.Select(p => p.ToString()))))).First();
                                if (ManhattanDistance(Detected[otherAster.Key].X, Detected[otherAster.Key].Y, AsteroidWithLaser.X, AsteroidWithLaser.Y) > ManhattanDistance(GibbsFreeEnergy.Value.X, GibbsFreeEnergy.Value.Y, AsteroidWithLaser.X, AsteroidWithLaser.Y))
                                {
                                    Detected[otherAster.Key] = GibbsFreeEnergy.Value;
                                }
                            }
                        }
                        // Up and Left
                        if (!NegativeY && NegativeX)
                        {
                            RunRise[0] = RunRise[0] * -1;
                            if (!(AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsLineOfSight[numberDetect] = (String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                                Detected.Add(GibbsFreeEnergy.Value);
                                numberDetect++;
                            }
                            else if (AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray())))
                            {
                                var otherAster = AsteroidsLineOfSight.Where(kvp => (kvp.Value == (String.Join(",", RunRise.Select(p => p.ToString()))))).First();
                                if (ManhattanDistance(Detected[otherAster.Key].X, Detected[otherAster.Key].Y, AsteroidWithLaser.X, AsteroidWithLaser.Y) > ManhattanDistance(GibbsFreeEnergy.Value.X, GibbsFreeEnergy.Value.Y, AsteroidWithLaser.X, AsteroidWithLaser.Y))
                                {
                                    Detected[otherAster.Key] = GibbsFreeEnergy.Value;
                                }
                            }
                        }
                        // Down and Right
                        if (NegativeY && NegativeX)
                        {
                            RunRise[0] = RunRise[0] * -1;
                            RunRise[1] = RunRise[1] * -1;
                            if (!(AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray()))))
                            {
                                AsteroidsLineOfSight[numberDetect] = (String.Join(",", RunRise.Select(p => p.ToString()).ToArray()));
                                Detected.Add(GibbsFreeEnergy.Value);
                                numberDetect++;
                            }
                            else if (AsteroidsLineOfSight.ContainsValue(String.Join(",", RunRise.Select(p => p.ToString()).ToArray())))
                            {
                                var otherAster = AsteroidsLineOfSight.Where(kvp => (kvp.Value == (String.Join(",", RunRise.Select(p => p.ToString()))))).First();
                                if (ManhattanDistance(Detected[otherAster.Key].X, Detected[otherAster.Key].Y, AsteroidWithLaser.X, AsteroidWithLaser.Y) > ManhattanDistance(GibbsFreeEnergy.Value.X, GibbsFreeEnergy.Value.Y, AsteroidWithLaser.X, AsteroidWithLaser.Y))
                                {
                                    Detected[otherAster.Key] = GibbsFreeEnergy.Value;
                                }
                            }
                        }

                    }
                    //comapare them
                    //Console.WriteLine("Deleting");
                    NotDestoryed = AsteroidsLiving.Count > 0;
                    if (Detected.Any(posTarget => posTarget.X >= AsteroidWithLaser.X && posTarget.Y < AsteroidWithLaser.Y))
                    {
                        var posTargetList = Detected.Where(posTarget => posTarget.X >= AsteroidWithLaser.X && posTarget.Y < AsteroidWithLaser.Y).ToList();
                        posTargetList = posTargetList.OrderBy(o => Math.Abs(AsteroidWithLaser.X - o.X) / (AsteroidWithLaser.Y - o.Y != 0 ? Math.Abs(AsteroidWithLaser.Y - o.Y) : .1)).ToList();
                        if (posTargetList.Count() < 200 - Destoryed)
                        {
                            foreach (Asteroid posAsters in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAsters.X && kvp.Value.Y == posAsters.Y));
                                if (item.Count() > 0)
                                {
                                    Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                    AsteroidsLiving.Remove(item.First().Key);
                                    Destoryed++;
                                }
                            }
                        }
                        else // there are more items than the number we would destroy
                        {
                            foreach (Asteroid posAstersALot in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAstersALot.X && kvp.Value.Y == posAstersALot.Y));
                                Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                AsteroidsLiving.Remove(item.First().Key);
                                Destoryed++;
                                if (Destoryed == 200)
                                {
                                    Console.WriteLine("CoordsLocatedForLastTarget: " + posAstersALot.X.ToString() + ", " + posAstersALot.Y.ToString());
                                    Console.WriteLine("10b Bet winning asteroid: " + (posAstersALot.X * 100 + posAstersALot.Y).ToString());
                                }
                            }
                        }
                    }
                    //LowerRightCords
                    if (Detected.Any(posTarget => posTarget.X > AsteroidWithLaser.X && posTarget.Y >= AsteroidWithLaser.Y))
                    {
                        var posTargetList = Detected.Where(posTarget => posTarget.X > AsteroidWithLaser.X && posTarget.Y >= AsteroidWithLaser.Y).ToList();
                        posTargetList = posTargetList.OrderBy(o =>
                        Math.Abs(AsteroidWithLaser.X - o.X) / (AsteroidWithLaser.Y - o.Y != 0 ? AsteroidWithLaser.Y - o.Y : -.1)).ToList();
                        if (posTargetList.Count() < 200 - Destoryed)
                        {
                            foreach (Asteroid posAsters in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAsters.X && kvp.Value.Y == posAsters.Y));
                                if (item.Count() > 0)
                                {
                                    Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                    AsteroidsLiving.Remove(item.First().Key);
                                    Destoryed++;
                                }
                            }
                        }
                        else // there are more items than the number we would destroy
                        {
                            foreach (Asteroid posAstersALot in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAstersALot.X && kvp.Value.Y == posAstersALot.Y));
                                Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                AsteroidsLiving.Remove(item.First().Key);
                                Destoryed++;
                                if (Destoryed == 200)
                                {
                                    Console.WriteLine("CoordsLocatedForLastTarget: " + posAstersALot.X.ToString() + ", " + posAstersALot.Y.ToString());
                                    Console.WriteLine("10b Bet winning asteroid: " + (posAstersALot.X * 100 + posAstersALot.Y).ToString());
                                }
                            }
                        }
                    }
                    //LowerLeftCords
                    if (Detected.Any(posTarget => posTarget.X <= AsteroidWithLaser.X && posTarget.Y > AsteroidWithLaser.Y))
                    {
                        var posTargetList = Detected.Where(posTarget => posTarget.X <= AsteroidWithLaser.X && posTarget.Y > AsteroidWithLaser.Y).ToList();
                        posTargetList = posTargetList.OrderBy(o =>
                        Math.Abs(AsteroidWithLaser.X - o.X) / (AsteroidWithLaser.Y - o.Y != 0 ? Math.Abs(AsteroidWithLaser.Y - o.Y) : .1)).ToList();
                        if (posTargetList.Count() < 200 - Destoryed)
                        {
                            foreach (Asteroid posAsters in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAsters.X && kvp.Value.Y == posAsters.Y));
                                if (item.Count() > 0)
                                {
                                    Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                    AsteroidsLiving.Remove(item.First().Key);
                                    Destoryed++;
                                }
                            }
                        }
                        else // there are more items than the number we would destroy
                        {
                            foreach (Asteroid posAstersALot in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAstersALot.X && kvp.Value.Y == posAstersALot.Y));
                                Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                AsteroidsLiving.Remove(item.First().Key);
                                Destoryed++;
                                if (Destoryed == 200)
                                {
                                    Console.WriteLine("CoordsLocatedForLastTarget: " + posAstersALot.X.ToString() + ", " + posAstersALot.Y.ToString());
                                    Console.WriteLine("10b Bet winning asteroid: " + (posAstersALot.X * 100 + posAstersALot.Y).ToString());
                                }
                            }
                        }
                    }
                    //UpperLeftCords
                    if (Detected.Any(posTarget => posTarget.X < AsteroidWithLaser.X && posTarget.Y <= AsteroidWithLaser.Y))
                    {
                        var posTargetList = Detected.Where(posTarget => posTarget.X < AsteroidWithLaser.X && posTarget.Y <= AsteroidWithLaser.Y).ToList();
                        posTargetList = posTargetList.OrderBy(o => Math.Abs(AsteroidWithLaser.X - o.X)
                        / (AsteroidWithLaser.Y - o.Y != 0 ? Math.Abs(AsteroidWithLaser.Y - o.Y) : .1)
                        ).ToList();
                        posTargetList.Reverse();
                        if (posTargetList.Count() < 200 - Destoryed)
                        {
                            foreach (Asteroid posAsters in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAsters.X && kvp.Value.Y == posAsters.Y));
                                if (item.Count() > 0)
                                {
                                    Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                    AsteroidsLiving.Remove(item.First().Key);
                                    Destoryed++;
                                }
                            }
                        }
                        else // there are more items than the number we would destroy
                        {
                            //make ordered because i'm not lazy any more
                            foreach (Asteroid posAstersALot in posTargetList)
                            {
                                var item = AsteroidsLiving.Where(kvp => (kvp.Value.X == posAstersALot.X && kvp.Value.Y == posAstersALot.Y));
                                Console.WriteLine("Bam " + Destoryed + " : " + item.First().Value.X + ", " + item.First().Value.Y);
                                AsteroidsLiving.Remove(item.First().Key);
                                Destoryed++;
                                if (Destoryed == 200)
                                {
                                    Console.WriteLine("CoordsLocatedForLastTarget: " + posAstersALot.X.ToString() + ", " + posAstersALot.Y.ToString());
                                    Console.WriteLine("10b Bet winning asteroid: " + (posAstersALot.X * 100 + posAstersALot.Y).ToString());
                                }
                            }
                        }

                        //var item in AsteroidsLiving.Where(kvp => kvp.Value == DustAsteroid)
                    }
                }
            }
            else if (key.Contains("11a"))
            {
                string[] Advent11Values = Properties.Resources.Advent11.Split(',');
                Dictionary<long, long> DictionaryInstructions = new Dictionary<long, long>();
                for (int i = 0; i < Advent11Values.Length; i++)
                {
                    DictionaryInstructions[i] = long.Parse(Advent11Values[i]);
                }
                // Now take a robot and feed it instruction outputs
                Robot EmergencyPaintingBot = new Robot();
                EmergencyPaintingBot.Location.Color = 0;
                long index = 0;
                long relativeBase = 0;
                bool Running = true;
                while (Running)
                {
                    List<long> BrainOutputs = Advent11OpCodeReader(DictionaryInstructions, EmergencyPaintingBot.Location.Color, index, relativeBase, 4);
                    if (BrainOutputs.Count > 3) //Has three outputs
                    {
                        Console.WriteLine("Painting Panel (" + EmergencyPaintingBot.Location.X.ToString() + ", " + EmergencyPaintingBot.Location.Y.ToString() + ") Color: " + (BrainOutputs[0] == 0 ? "Black" : "White"));
                        EmergencyPaintingBot.Location.Color = Convert.ToInt32(BrainOutputs[0]);
                        EmergencyPaintingBot.Forward(Convert.ToInt32(BrainOutputs[1]));
                        index = BrainOutputs[2];
                        relativeBase = BrainOutputs[3];
                    }
                    else
                    {
                        Running = false;
                    }
                }
                Console.WriteLine("Robot is Finished and done 10a");

            }
            else if (key.Contains("11b"))
            {
                string[] Advent11Values = Properties.Resources.Advent11.Split(',');
                Dictionary<long, long> DictionaryInstructions = new Dictionary<long, long>();
                for (int i = 0; i < Advent11Values.Length; i++)
                {
                    DictionaryInstructions[i] = long.Parse(Advent11Values[i]);
                }
                // Now take a robot and feed it instruction outputs
                Robot EmergencyPaintingBot = new Robot();
                EmergencyPaintingBot.Location.Color = 1;
                long index = 0;
                bool Running = true;
                long relativeBase = 0;
                while (Running)
                {
                    List<long> BrainOutputs = Advent11OpCodeReader(DictionaryInstructions, EmergencyPaintingBot.Location.Color, index, relativeBase);
                    if (BrainOutputs.Count > 3) //Has three outputs
                    {
                        Console.WriteLine("Painting Panel (" + EmergencyPaintingBot.Location.X.ToString() + ", " + EmergencyPaintingBot.Location.Y.ToString() + ") Color: " + (BrainOutputs[0] == 0 ? "Black" : "White"));
                        EmergencyPaintingBot.Location.Color = Convert.ToInt32(BrainOutputs[0]);
                        EmergencyPaintingBot.Forward(Convert.ToInt32(BrainOutputs[1]));
                        index = BrainOutputs[2];
                        relativeBase = BrainOutputs[3];
                    }
                    else
                    {
                        Running = false;
                    }
                }
                if (!EmergencyPaintingBot.UniquePanels.Any(kvp => kvp.Value.X == EmergencyPaintingBot.Location.X && kvp.Value.Y == EmergencyPaintingBot.Location.Y))
                {
                    EmergencyPaintingBot.UniquePanels[EmergencyPaintingBot.UniquePanels.Count] = new Panel(EmergencyPaintingBot.Location);
                }
                // Brute Force Static Write
                for (int y = 0; y >= -5; y--)
                {
                    for (int x = 0; x <= 40; x++)
                    {
                        if (EmergencyPaintingBot.UniquePanels.Any(kvp => kvp.Value.X == x && kvp.Value.Y == y))
                        {
                            Console.Write(EmergencyPaintingBot.UniquePanels.Where(kvp => kvp.Value.X == x && kvp.Value.Y == y).First().Value.Color);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write(Environment.NewLine);
                }
                Console.WriteLine("Robot is Finished and done 10b");

            }
            else if (key.Contains("12a"))
            {
                //12a inputs
                //Moon Tharcia = new Moon("Tharcia", 7, 10, 17, 0, 0, 0);
                //Moon Valentia = new Moon("Valentia", -2, 7, 0, 0, 0, 0);
                //Moon Hoshido = new Moon("Hoshido", 12, 5, 12, 0, 0, 0);
                //Moon Noir = new Moon("Noir", 5, -8, 6, 0, 0, 0);

                //12a Test
                //Moon Tharcia = new Moon("Tharcia", -8, -10, 0, 0, 0, 0);
                //Moon Valentia = new Moon("Valentia", 5, 5, 10, 0, 0, 0);
                //Moon Hoshido = new Moon("Hoshido", 2, -7, 3, 0, 0, 0);
                //Moon Noir = new Moon("Noir", 9, -8, -3, 0, 0, 0);

                Moon Tharcia = new Moon("Tharcia", -1, -0, 2, 0, 0, 0);
                Moon Valentia = new Moon("Valentia", 2, -10, -7, 0, 0, 0);
                Moon Hoshido = new Moon("Hoshido", 4, -8, 8, 0, 0, 0);
                Moon Noir = new Moon("Noir", 3, 5, -1, 0, 0, 0);
                long timeSpan = 0;
                while (timeSpan != 11)
                {
                    Console.WriteLine("Current Step: " + timeSpan);
                    Console.WriteLine("Tharcia Pos; " + Tharcia.xPos + " " + Tharcia.yPos + " " + Tharcia.zPos);
                    Console.WriteLine("Tharcia Vel; " + Tharcia.xVel + " " + Tharcia.yVel + " " + Tharcia.zVel);
                    Console.WriteLine("Valentia Pos; " + Valentia.xPos + " " + Valentia.yPos + " " + Valentia.zPos);
                    Console.WriteLine("Valentia Vel; " + Valentia.xVel + " " + Valentia.yVel + " " + Valentia.zVel);
                    Console.WriteLine("Hoshido Pos; " + Hoshido.xPos + " " + Hoshido.yPos + " " + Hoshido.zPos);
                    Console.WriteLine("Hoshido Vel; " + Hoshido.xVel + " " + Hoshido.yVel + " " + Hoshido.zVel);
                    Console.WriteLine("Noir Pos; " + Noir.xPos + " " + Noir.yPos + " " + Noir.zPos);
                    Console.WriteLine("Noir Vel; " + Noir.xVel + " " + Noir.yVel + " " + Noir.zVel);
                    Console.WriteLine("__________________________________");
                    Tharcia.CalculateVelocity(Valentia);
                    Tharcia.CalculateVelocity(Hoshido);
                    Tharcia.CalculateVelocity(Noir);
                    Valentia.CalculateVelocity(Hoshido);
                    Valentia.CalculateVelocity(Noir);
                    Noir.CalculateVelocity(Hoshido);
                    Tharcia.MoveMoon();
                    Valentia.MoveMoon();
                    Hoshido.MoveMoon();
                    Noir.MoveMoon();
                    //Console.WriteLine("Tharcia : Potential Energy: " + Tharcia.GetPotentialEnergy() + " Tharcia : Kinetic Energy: " + Tharcia.GetKineticEnergy());
                    //Console.WriteLine("Valentia : Potential Energy: " + Valentia.GetPotentialEnergy() + " Valentia : Kinetic Energy: " + Valentia.GetKineticEnergy());
                    //Console.WriteLine("Hoshido : Potential Energy: " + Hoshido.GetPotentialEnergy() + " Hoshido : Kinetic Energy: " + Hoshido.GetKineticEnergy());
                    //Console.WriteLine("Noir : Potential Energy: " + Noir.GetPotentialEnergy() + " Noir : Kinetic Energy: " + Noir.GetKineticEnergy());
                    timeSpan++;
                }
                Console.WriteLine("Day 12a: Total Energy: " + (Tharcia.GetEnergy() + Valentia.GetEnergy() + Hoshido.GetEnergy() + Noir.GetEnergy()));
            }
            else if (key.Contains("12b"))
            {
                //12b inputs
                Moon Tharcia = new Moon("Tharcia", 7, 10, 17, 0, 0, 0);
                Moon Valentia = new Moon("Valentia", -2, 7, 0, 0, 0, 0);
                Moon Hoshido = new Moon("Hoshido", 12, 5, 12, 0, 0, 0);
                Moon Noir = new Moon("Noir", 5, -8, 6, 0, 0, 0);

                //12b Test
                //Moon Tharcia = new Moon("Tharcia", -8, -10, 0, 0, 0, 0);
                //Moon Valentia = new Moon("Valentia", 5, 5, 10, 0, 0, 0);
                //Moon Hoshido = new Moon("Hoshido", 2, -7, 3, 0, 0, 0);
                //Moon Noir = new Moon("Noir", 9, -8, -3, 0, 0, 0);

                //12b Test2
                //Moon Tharcia = new Moon("Tharcia", -1, -0, 2, 0, 0, 0);
                //Moon Valentia = new Moon("Valentia", 2, -10, -7, 0, 0, 0);
                //Moon Hoshido = new Moon("Hoshido", 4, -8, 8, 0, 0, 0);
                //Moon Noir = new Moon("Noir", 3, 5, -1, 0, 0, 0);
                long timeSpan = 0;
                List<long> UniverseEnergy = new List<long>();
                string initialState = Tharcia.GenerateState() + "|" + Valentia.GenerateState() + "|" + Hoshido.GenerateState() + "|" + Noir.GenerateState();
                Dictionary<long, List<string>> Universe = new Dictionary<long, List<string>>();
                bool Repeat = false;
                #region rest
                //while (!Repeat)
                //{
                //    //List<Moon> Moons = new List<Moon>();
                //    Tharcia.CalculateVelocity(Valentia);
                //    Tharcia.CalculateVelocity(Hoshido);
                //    Tharcia.CalculateVelocity(Noir);
                //    Valentia.CalculateVelocity(Hoshido);
                //    Valentia.CalculateVelocity(Noir);
                //    Noir.CalculateVelocity(Hoshido);

                //    Tharcia.MoveMoon();
                //    Valentia.MoveMoon();
                //    Hoshido.MoveMoon();
                //    Noir.MoveMoon();
                //    #region oldcode
                //    //Console.WriteLine("Tharcia : Potential Energy: " + Tharcia.GetPotentialEnergy() + " Tharcia : Kinetic Energy: " + Tharcia.GetKineticEnergy());
                //    //Console.WriteLine("Valentia : Potential Energy: " + Valentia.GetPotentialEnergy() + " Valentia : Kinetic Energy: " + Valentia.GetKineticEnergy());
                //    //Console.WriteLine("Hoshido : Potential Energy: " + Hoshido.GetPotentialEnergy() + " Hoshido : Kinetic Energy: " + Hoshido.GetKineticEnergy());
                //    //Console.WriteLine("Noir : Potential Energy: " + Noir.GetPotentialEnergy() + " Noir : Kinetic Energy: " + Noir.GetKineticEnergy());
                //    //Moons.Add(new Moon(Tharcia));
                //    //Moons.Add(new Moon(Valentia));
                //    //Moons.Add(new Moon(Hoshido));
                //    //Moons.Add(new Moon(Noir));
                //    //timeSpan = timeSpan + 1;
                //    //var SameEnergy = from long energy in UniverseEnergy.AsParallel()
                //    //                 where energy == GibbsNotSoFreeEnergy
                //    //                 select energy;
                //    //if (SameEnergy.Count() > 0)
                //    //{
                //    //    var Repeated = from state in Universe[GibbsNotSoFreeEnergy].AsParallel()
                //    //                   where state == UniverseState
                //    //                   select state;
                //    //    if (Repeated.Count() > 0)
                //    //    {
                //    //        Repeat = true;
                //    //    }
                //    //    else
                //    //    {
                //    //        Universe[GibbsNotSoFreeEnergy].Add(UniverseState);
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    UniverseEnergy.Add(GibbsNotSoFreeEnergy);
                //    //    List<string> SameEnergyStates = new List<string>();
                //    //    SameEnergyStates.Add(UniverseState);
                //    //    Universe.Add(GibbsNotSoFreeEnergy, SameEnergyStates);
                //    //}
                //    #endregion oldcode
                //    long GibbsNotSoFreeEnergy = Tharcia.GetEnergy() + Valentia.GetEnergy() + Hoshido.GetEnergy() + Noir.GetEnergy();
                //    string UniverseState = Tharcia.GenerateState() + "|" + Valentia.GenerateState() + "|" + Hoshido.GenerateState() + "|" + Noir.GenerateState();

                //    if(initialState.Equals(UniverseState))
                //    {
                //        Repeat = true;
                //    }
                //    else
                //    {
                //        timeSpan = timeSpan + 1;
                //    }



                //}
                #endregion rest
                Console.WriteLine("Cycle X: " + FindCycleX(new Moon(Tharcia), new Moon(Valentia), new Moon(Hoshido), new Moon(Noir)));
                Console.WriteLine("Cycle Y: " + FindCycleY(new Moon(Tharcia), new Moon(Valentia), new Moon(Hoshido), new Moon(Noir)));
                Console.WriteLine("Cycle Z: " + FindCycleZ(new Moon(Tharcia), new Moon(Valentia), new Moon(Hoshido), new Moon(Noir)));
                Console.WriteLine("Day 12b: Simply find the GCM Now");
            }
            else if (key.Contains("13a"))
            {
                string[] Advent13Values = Properties.Resources.Advent13.Split(',');
                Dictionary<long, long> DictionaryInstructions = new Dictionary<long, long>();
                long index = 0;
                long relativeBase = 0;
                bool Running = true;
                Dictionary<long, Panel> PanelDictionary = new Dictionary<long, Panel>();
                long numPanels = 0;
                for (int i = 0; i < Advent13Values.Length; i++)
                {
                    DictionaryInstructions[i] = long.Parse(Advent13Values[i]);
                }
                while (Running)
                {
                    List<long> ScreenOutput = Advent11OpCodeReader(DictionaryInstructions, 0, index, relativeBase, 3);
                    //Console.WriteLine(ScreenOutput[0] + ScreenOutput[1] + ScreenOutput[2] + ScreenOutput[3] + ScreenOutput[4]);

                    if (ScreenOutput.Count() == 5)
                    {
                        index = ScreenOutput[3];
                        relativeBase = ScreenOutput[4];
                        Panel currentPanel = new Panel(Convert.ToInt32(ScreenOutput[0]), Convert.ToInt32(ScreenOutput[1]), Convert.ToInt32(ScreenOutput[2]));
                        if (!PanelDictionary.Any(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y)) //Add the unique panel
                        {
                            PanelDictionary.Add(numPanels, new Panel(currentPanel));
                            numPanels++;
                        }
                        else if (PanelDictionary.Any(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y)) //Update the Panel
                        {
                            PanelDictionary[PanelDictionary.Where(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y).First().Key] = new Panel(currentPanel);
                        }
                    }
                    else
                    {
                        Running = false;
                    }
                }
                var result = from Panel panel in PanelDictionary.Values
                             where panel.Color == 2
                             select panel;
                Console.WriteLine("Day 13a: Number of block tiles: " + result.Count());
            }
            else if (key.Contains("13b"))
            {
                string[] Advent13Values = Properties.Resources.Advent13.Split(',');
                Dictionary<long, long> DictionaryInstructions = new Dictionary<long, long>();
                long index = 0;
                long relativeBase = 0;
                bool Running = true;
                bool BlocksExist = true;
                long Score = 0;
                long input = 0;
                Advent13Values[0] = "2";
                Dictionary<long, Panel> PanelDictionary = new Dictionary<long, Panel>();
                long numPanels = 0;
                //PanelDictionary.Values.ToList().Sort(kvp => kvp.X)
                List<Panel> TestList = new List<Panel>();
                for (int i = 0; i < Advent13Values.Length; i++)
                {
                    DictionaryInstructions[i] = long.Parse(Advent13Values[i]);
                }
                while (BlocksExist)
                {
                    while (Running)
                    {
                        List<long> ScreenOutput = Advent11OpCodeReader(DictionaryInstructions, input, index, relativeBase, 3);
                        //Console.WriteLine(ScreenOutput[0] + ScreenOutput[1] + ScreenOutput[2] + ScreenOutput[3] + ScreenOutput[4]);
                        //X => 0 36
                        //Y => 0 21
                        if (ScreenOutput.Count() == 5)
                        {
                            index = ScreenOutput[3];
                            relativeBase = ScreenOutput[4];
                            if (ScreenOutput[0] == -1 && ScreenOutput[1] == 0)
                            {
                                Score = ScreenOutput[3];
                            }
                            Panel currentPanel = new Panel(Convert.ToInt32(ScreenOutput[0]), Convert.ToInt32(ScreenOutput[1]), Convert.ToInt32(ScreenOutput[1]) != 21 || Convert.ToInt32(ScreenOutput[2]) == 4 ? Convert.ToInt32(ScreenOutput[2]) : 1);
                            if (!PanelDictionary.Any(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y)) //Add the unique panel
                            {
                                PanelDictionary.Add(numPanels, new Panel(currentPanel));
                                numPanels++;
                            }
                            else if (PanelDictionary.Any(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y)) //Update the Panel
                            {
                                PanelDictionary[PanelDictionary.Where(KVP => KVP.Value.X == currentPanel.X && KVP.Value.Y == currentPanel.Y).First().Key] = new Panel(currentPanel);
                            }
                            var ball = from Panel panel in PanelDictionary.Values
                                        where panel.Color == 4
                                        select panel;
                            var paddle = from Panel panel in PanelDictionary.Values
                                            where panel.Color == 3
                                            select panel;
                            if (ball.Count() > 0 && paddle.Count() > 0)
                            {
                                if (ball.First().X > paddle.First().X)
                                {
                                    input = 1;// Right
                                }
                                else if (ball.First().X < paddle.First().X)
                                {
                                    input = -1;// Left
                                }
                                else
                                {
                                    input = 0;
                                }
                            }
                            //disable the screen for instant output
                            Console.Clear();
                            for (int y = 0; y <= 21; y++)
                            {
                                for (int x = 0; x <= 36; x++)
                                {
                                    if (PanelDictionary.Any(kvp => kvp.Value.X == x && kvp.Value.Y == y))
                                    {
                                        long color = PanelDictionary.Where(kvp => kvp.Value.X == x && kvp.Value.Y == y).First().Value.Color;
                                        if (color == 0)
                                        {
                                            Console.Write(" ");
                                        }
                                        if (color == 1)
                                        {
                                            Console.Write("|");
                                        }
                                        if (color == 2)
                                        {
                                            Console.Write("H");
                                        }
                                        if (color == 3)
                                        {
                                            Console.Write("~");
                                        }
                                        if (color == 4)
                                        {
                                            Console.Write("O");
                                        }
                                        if (color > 4 || color < 0)
                                        {
                                            Console.Write("X");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write(" ");
                                    }
                                }
                                Console.Write(Environment.NewLine);
                                
                            }
                        }
                        else
                        {
                            Running = false;
                        }
                    }
                    var result = from Panel panel in PanelDictionary.Values
                                 where panel.Color == 2
                                 select panel;
                    Console.WriteLine("Number of blocks: " + result.Count());
                    if (result.Count() > 0)
                    {
                        index = 0;
                        //relativeBase = 0;
                        Running = true;
                        var ball = from Panel panel in PanelDictionary.Values
                                   where panel.Color == 4
                                   select panel;
                        var paddle = from Panel panel in PanelDictionary.Values
                                     where panel.Color == 3
                                     select panel;
                        if (ball.First().X > paddle.First().X)
                        {
                            input = 1;// Right
                        }
                        else if (ball.First().X < paddle.First().X)
                        {
                            input = -1;// Left
                        }
                        else
                        {
                            input = 0;
                        }

                        for (int y = 0; y <= 21; y++)
                        {
                            for (int x = 0; x <= 36; x++)
                            {
                                if (PanelDictionary.Any(kvp => kvp.Value.X == x && kvp.Value.Y == y))
                                {
                                    long color = PanelDictionary.Where(kvp => kvp.Value.X == x && kvp.Value.Y == y).First().Value.Color;
                                    if (color == 0)
                                    {
                                        Console.Write(" ");
                                    }
                                    if (color == 1)
                                    {
                                        Console.Write("|");
                                    }
                                    if (color == 2)
                                    {
                                        Console.Write("H");
                                    }
                                    if (color == 3)
                                    {
                                        Console.Write("~");
                                    }
                                    if (color == 4)
                                    {
                                        Console.Write("O");
                                    }
                                    if (color > 4 || color < 0)
                                    {
                                        Console.Write("X");
                                    }
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                            Console.Write(Environment.NewLine);
                        }
                    }
                    else
                    {
                        BlocksExist = false;
                        var ScorePanel = from Panel panel in PanelDictionary.Values
                                where panel.X == -1 && panel.Y == 0
                                select panel;
                        Score = ScorePanel.First().Color;
                    }
                }

                Console.WriteLine("Day 13a: Score" + Score);
            }
            else if (key.Contains("Test1"))
            {
                Robot EmergencyPaintingBot = new Robot();
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
                EmergencyPaintingBot.Location.Color = 1;
                EmergencyPaintingBot.Forward(1);
                Console.WriteLine(EmergencyPaintingBot.Location.X + ", " + EmergencyPaintingBot.Location.Y);
            }
            else if (key.Contains("Test2"))
            {
                string[] Advent11Values = Properties.Resources.Advent11.Split(',');
                Dictionary<long, long> DictionaryInstructions = new Dictionary<long, long>();
                for (int i = 0; i < Advent11Values.Length; i++)
                {
                    DictionaryInstructions[i] = long.Parse(Advent11Values[i]);
                }
                long index = 0;
                List<long> inputs = new List<long>();//0, 0, 0, 0, 1, 0, 0);
                inputs.Add(0);
                inputs.Add(0);
                inputs.Add(0);
                inputs.Add(0);
                inputs.Add(1);
                inputs.Add(0);
                inputs.Add(0);
                foreach (long input in inputs)
                {
                    List<long> outputs = new List<long>();
                    outputs = Advent11OpCodeReader(DictionaryInstructions, input, index);
                    if (outputs.Count > 0)
                    {
                        index = outputs[2];
                        Console.WriteLine("output 1: " + outputs[0] + " output 2: " + outputs[1] + " index: " + outputs[2]);
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("No Input");
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
        public static long FindCycleX (Moon moon1, Moon moon2, Moon moon3, Moon moon4)
        {
            bool Repeat = false;
            // get initial state
            long md1 = moon1.xPos;
            long mv1 = moon1.xVel;
            long md2 = moon2.xPos;
            long mv2 = moon2.xVel;
            long md3 = moon3.xPos;
            long mv3 = moon3.xVel;
            long md4 = moon4.xPos;
            long mv4 = moon4.xVel;
            long TimeSpan = 0;
            while (!Repeat)
            {
                moon1.CalculateVelocity(moon2);
                moon1.CalculateVelocity(moon3);
                moon1.CalculateVelocity(moon4);
                moon2.CalculateVelocity(moon3);
                moon2.CalculateVelocity(moon4);
                moon4.CalculateVelocity(moon3);

                moon1.MoveMoon();
                moon2.MoveMoon();
                moon3.MoveMoon();
                moon4.MoveMoon();
                TimeSpan++;
                if (moon1.xPos == md1 && moon1.xVel == mv1)
                {
                    if(moon2.xPos == md2 && moon2.xVel == mv2)
                    {
                        if (moon3.xPos == md3 && moon3.xVel == mv3)
                        {
                            if (moon4.xPos == md4 && moon4.xVel == mv4)
                            {
                                Repeat = true;
                            }
                        }
                    }
                }
            }
            return TimeSpan;
        }
        public static long FindCycleY(Moon moon1, Moon moon2, Moon moon3, Moon moon4)
        {
            bool Repeat = false;
            long md1 = moon1.yPos;
            long mv1 = moon1.yVel;
            long md2 = moon2.yPos;
            long mv2 = moon2.yVel;
            long md3 = moon3.yPos;
            long mv3 = moon3.yVel;
            long md4 = moon4.yPos;
            long mv4 = moon4.yVel;
            long TimeSpan = 0;
            while (!Repeat)
            {
                moon1.CalculateVelocity(moon2);
                moon1.CalculateVelocity(moon3);
                moon1.CalculateVelocity(moon4);
                moon2.CalculateVelocity(moon3);
                moon2.CalculateVelocity(moon4);
                moon4.CalculateVelocity(moon3);

                moon1.MoveMoon();
                moon2.MoveMoon();
                moon3.MoveMoon();
                moon4.MoveMoon();
                TimeSpan++;
                if (moon1.yPos == md1 && moon1.yVel == mv1)
                {
                    if (moon2.yPos == md2 && moon2.yVel == mv2)
                    {
                        if (moon3.yPos == md3 && moon3.yVel == mv3)
                        {
                            if (moon4.yPos == md4 && moon4.yVel == mv4)
                            {
                                Repeat = true;
                            }
                        }
                    }
                }
            }
            return TimeSpan;
        }
        public static long FindCycleZ(Moon moon1, Moon moon2, Moon moon3, Moon moon4)
        {
            bool Repeat = false;
            long md1 = moon1.zPos;
            long mv1 = moon1.zVel;
            long md2 = moon2.zPos;
            long mv2 = moon2.zVel;
            long md3 = moon3.zPos;
            long mv3 = moon3.zVel;
            long md4 = moon4.zPos;
            long mv4 = moon4.zVel;
            long TimeSpan = 0;
            while (!Repeat)
            {
                moon1.CalculateVelocity(moon2);
                moon1.CalculateVelocity(moon3);
                moon1.CalculateVelocity(moon4);
                moon2.CalculateVelocity(moon3);
                moon2.CalculateVelocity(moon4);
                moon4.CalculateVelocity(moon3);

                moon1.MoveMoon();
                moon2.MoveMoon();
                moon3.MoveMoon();
                moon4.MoveMoon();
                TimeSpan++;
                if (moon1.zPos == md1 && moon1.zVel == mv1)
                {
                    if (moon2.zPos == md2 && moon2.zVel == mv2)
                    {
                        if (moon3.zPos == md3 && moon3.zVel == mv3)
                        {
                            if (moon4.zPos == md4 && moon4.zVel == mv4)
                            {
                                Repeat = true;
                            }
                        }
                    }
                }
            }
            return TimeSpan;
        }

        public static bool CompareMoon(Moon moon1, Moon moon2)
        {
            return (moon1.xPos == moon2.xPos) && (moon1.yPos == moon2.yPos) && (moon1.zPos == moon2.zPos) && (moon1.xVel == moon2.xVel) && (moon1.yVel == moon2.yVel) && (moon1.zVel == moon2.zVel);
        }
        private static List<long> Advent11OpCodeReader(Dictionary<long, long> TheCode, long input1, long index = 0, long relativeIndex = 0, long numberOutputs = 0)
        {
            long i = index;
            bool flag = true;
            long relativeBase = relativeIndex;
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
                        WriteModeAdvent9(TheCode, LocCode, i + 1, 2, input1, relativeBase);
                    i += 2;
                }
                else if (OpCode == 4)
                {
                    // need to output

                    ListOfOutputs.Add(ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase));
                    i += 2;
                    if(ListOfOutputs.Count == numberOutputs)
                    {
                        ListOfOutputs.Add(i);
                        ListOfOutputs.Add(relativeBase);
                        break;
                    }
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
                    relativeBase = relativeBase + ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase);
                    i += 2;
                }
                else
                {
                    Console.WriteLine("Instruction at was odd for i:" + i);
                }
            }
            if (LastTwoDigitHelperAdvent5(TheCode[i]) == 99 && ListOfOutputs.Count > 0)
            {
                Console.WriteLine("Robot Processed Instruction");
                //foreach (long test in ListOfOutputs)
                //{
                //    Console.WriteLine(test);
                //}
            }
            return ListOfOutputs;
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
                    relativeBase = relativeBase + ReadModeAdvent9(TheCode, LocCode, i + 1, 2, relativeBase);
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
                    if (items.ContainsKey(index))
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
                    if (items.ContainsKey(index)) //minor change
                    {
                        if (items.ContainsKey(items[index] + relativeBase))
                        {
                            result = items[items[index] + relativeBase];
                        }
                        else
                        {
                            items[items[index] + relativeBase] = 0;
                            result = items[items[index] + relativeBase];
                        }
                    }
                    else
                    {
                        items[index] = 0;
                        if (items.ContainsKey(items[items[index] + relativeBase]))
                        {
                            result = items[items[index] + relativeBase];
                        }
                        else
                        {
                            items[items[index] + relativeBase] = 0;
                            result = items[items[index] + relativeBase];
                        }
                    }
                }
                else//Positional
                {
                    if (items.ContainsKey(items[index]))
                    {
                        result = items[items[index]];
                    }
                    else
                    {
                        items[items[index]] = 0;
                        result = items[items[index]];
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
                    if (items.ContainsKey(index)) //minor change
                    {
                        if (items.ContainsKey(items[index] + relativeBase))
                        {
                            items[items[index] + relativeBase] = result;
                        }
                        else
                        {
                            items[items[index] + relativeBase] = 0;
                            items[items[index] + relativeBase] = result;
                        }
                    }
                    else
                    {
                        items[index] = 0;
                        if (items.ContainsKey(items[items[index] + relativeBase]))
                        {
                            items[items[index] + relativeBase] = result;
                        }
                        else
                        {
                            items[items[index] + relativeBase] = 0;
                            items[items[index] + relativeBase] = result;
                        }
                    }
                }
                else//Positional
                {
                    if (items.ContainsKey(items[index]))
                    {
                        items[items[index]] = result;
                    }
                    else
                    {
                        items[items[index]] = 0;
                        items[items[index]] = result;
                    }
                }
            }
        }
        private class Robot
        {
            public int Direction = 0;// 0 = north, 1 = east, 2 = South, 3 = West
            public Dictionary<int, Panel> UniquePanels = new Dictionary<int, Panel>();
            public int DistanceTraveled = 0;
            public Panel Location = new Panel(0, 0, 0);
            public List<Panel> PathTaken = new List<Panel>();

            public Robot()
            {
                // nothing here
            }

            public void Forward(int turn)
            {
                Turn(turn);
                PathTaken.Add(Location);               
                int moveX = 0;
                int moveY = 0;
                if(Direction == 0)
                {
                    moveY = 1;
                }
                else if(Direction == 1)
                {
                    moveX = 1;
                }
                else if(Direction == 2)
                {
                    moveY = -1;
                }
                else if(Direction == 3)
                {
                    moveX = -1;
                }
                if (!UniquePanels.Any(KVP => KVP.Value.X == this.Location.X && KVP.Value.Y == this.Location.Y)) //Add the unique panel
                {
                    UniquePanels.Add(DistanceTraveled, new Panel(Location));
                }
                else if(UniquePanels.Any(KVP => KVP.Value.X == this.Location.X && KVP.Value.Y == this.Location.Y)) //Update the Panel
                {
                    UniquePanels[UniquePanels.Where(KVP => KVP.Value.X == this.Location.X && KVP.Value.Y == this.Location.Y).First().Key] = new Panel(Location);
                }
                DistanceTraveled++;
                if (UniquePanels.Any(KVP => KVP.Value.X == (this.Location.X+moveX) && KVP.Value.Y == (this.Location.Y+moveY)))
                {
                    Location = new Panel(UniquePanels.Where(KVP => KVP.Value.X == this.Location.X + moveX && KVP.Value.Y == this.Location.Y + moveY).First().Value);
                }
                else if((!(UniquePanels.Any(KVP => KVP.Value.X == (this.Location.X + moveX) && KVP.Value.Y == (this.Location.Y + moveY)))))
                {
                    Location = new Panel(Location.X + moveX, Location.Y + moveY, 0);
                }
                else
                {
                    //Consult the dev
                }

            }

            public void Turn(int turn)
            {
                // North to West or East
                if(Direction == 0)
                {
                    if(turn == 0)
                    {
                        Direction = 3; // West
                    }
                    else if(turn == 1)
                    {
                        Direction = 1; // East
                    }
                }
                // East
                else if(Direction == 1)
                {
                    if (turn == 0)
                    {
                        Direction = 0;
                    }
                    else if(turn == 1)
                    {
                        Direction = 2;
                    }
                }
                // South
                else if (Direction == 2)
                {
                    if (turn == 0)
                    {
                        Direction = 1;
                    }
                    else if(turn == 1)
                    {
                        Direction = 3;
                    }
                }
                // West
                else if (Direction == 3)
                {
                    if (turn == 0)
                    {
                        Direction = 2;
                    }
                    else if(turn == 1)
                    {
                        Direction = 0;
                    }
                }
                else if(turn > 1 || turn < 0)
                {

                }
            }
        }
        //private class ScreenMaker
        //{

        //}
        private class Panel
        {
            public int X = 0;
            public int Y = 0;
            public int Color = 0; 
            //0, black| 1, white
            //0, Empty| 1, Wall| 2, Block| 3, Horizontal| 4, Ball|

            public Panel(int x, int y, int Color)
            {
                this.X = x;
                this.Y = y;
                this.Color = Color;
            }

            public Panel(Panel Old)
            {
                this.X = Old.X;
                this.Y = Old.Y;
                this.Color = Old.Color;
            }
        }
        private class Asteroid
        {
            public int X = 0;
            public int Y = 0;
            public int VisibleAsteroids = 0;
            public Asteroid(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public class Moon
        {
            public string Name;
            public int xPos;
            public int yPos;
            public int zPos;
            public int xVel;
            public int yVel;
            public int zVel;

            public Moon (Moon moon)
            {
                this.Name = moon.Name;
                this.xPos = moon.xPos;
                this.yPos = moon.yPos;
                this.zPos = moon.zPos;
                this.xVel = moon.xVel;
                this.yVel = moon.yVel;
                this.zVel = moon.zVel;
            }
            public Moon (string name, int x, int y, int z, int xV, int yV, int zV)
            {
                this.Name = name;
                this.xPos = x;
                this.yPos = y;
                this.zPos = z;
                this.xVel = xV;
                this.yVel = yV;
                this.zVel = zV;
            }
            public string GenerateState()
            {
                return "|" + xPos + "|" + yPos + "|" + zPos + "|" + xVel + "|" + yVel + "|" + zVel + "|";
            }

            public void CalculateVelocity(Moon otherMoon)
            {
                if(this.xPos > otherMoon.xPos)
                {
                    this.xVel--;
                    otherMoon.xVel++;
                }
                else if(this.xPos < otherMoon.xPos)
                {
                    this.xVel++;
                    otherMoon.xVel--;
                }
                if(this.yPos > otherMoon.yPos)
                {
                    this.yVel--;
                    otherMoon.yVel++;
                }
                else if (this.yPos < otherMoon.yPos)
                {
                    this.yVel++;
                    otherMoon.yVel--;
                }
                if (this.zPos > otherMoon.zPos)
                {
                    this.zVel--;
                    otherMoon.zVel++;
                }
                else if (this.zPos < otherMoon.zPos)
                {
                    this.zVel++;
                    otherMoon.zVel--;
                }
            }

            public void MoveMoon()
            {
                this.xPos += this.xVel;
                this.yPos += this.yVel;
                this.zPos += this.zVel;
            }

            public int GetPotentialEnergy()
            {
                return Math.Abs(this.xPos) + Math.Abs(this.yPos) + Math.Abs(this.zPos);
            }

            public int GetKineticEnergy()
            {
                return Math.Abs(this.xVel) + Math.Abs(this.yVel) + Math.Abs(this.zVel);
            }

            public int GetEnergy()
            {
                return GetPotentialEnergy() * GetKineticEnergy();
            }
        }
        //Stack Overflow function/methods borrowed
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
        //
        private static void Simplify(int[] numbers)
        {
            int gcd = GCD(numbers);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] /= gcd;
        }
        private static int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
        private static int GCD(int[] args)
        {
            // using LINQ:
            return args.Aggregate((gcd, arg) => GCD(gcd, arg));
        }
        private static int ManhattanDistance(int x1, int y1, int x2, int y2)
        {
            int distance = 0;
            distance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return distance;
        }
    }
}
