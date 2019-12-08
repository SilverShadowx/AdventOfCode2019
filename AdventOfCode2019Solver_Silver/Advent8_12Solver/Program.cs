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
            else
            {
                Console.WriteLine("No Input");
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
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
