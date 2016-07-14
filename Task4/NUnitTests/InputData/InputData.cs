using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;
using NUnitTests.Infrastructure;

namespace NUnitTests.InputData
{
    public static class InputData
    {
        private static JObject Values;


        static InputData()
        {
            Directory.SetCurrentDirectory(NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            Values = JObject.Parse(File.ReadAllText("InputData/InputValues.json"));
        }

        public static IEnumerable<int[]> IntValues
        {
            get { return GetStringValues("intPairs").Select(x => new int[] { int.Parse(x[0]), int.Parse(x[1]) }); }
        }

        public static IEnumerable<string[]> IntStringValues
        {
            get { return GetStringValues("intPairs"); }
        }

        public static IEnumerable<int> IntList
        {
            get
            {
                List<int> values = new List<int>();
                foreach(var item in IntValues)
                {
                    values.AddRange(item);
                }
                return values.Distinct();
            }
        }

        public static IEnumerable<string> IntStringList
        {
            get
            {
                List<string> values = new List<string>();
                foreach (var item in IntStringValues)
                {
                    values.AddRange(item);
                }
                return values.Distinct();
            }
        }

        public static IEnumerable<double[]> DoubleValues
        {
            get { return GetStringValues("doublePairs").Select(x => new double[] { double.Parse(x[0]), double.Parse(x[1]) }); }
        }

        public static IEnumerable<string[]> DoubleStringValues
        {
            get { return GetStringValues("doublePairs").Select(x => new[] { x[0].ToDoubleString(), x[1].ToDoubleString() }); }
        }

        public static IEnumerable<double> DoubleList
        {
            get
            {
                List<double> values = new List<double>();
                foreach (var item in DoubleValues)
                {
                    values.AddRange(item);
                }
                return values.Distinct();
            }
        }

        public static IEnumerable<string> DoubleStringList
        {
            get
            {
                List<string> values = new List<string>();
                foreach (var item in DoubleStringValues)
                {
                    values.AddRange(item);
                }
                return values.Distinct();
            }
        }

        public static IEnumerable<string[]> GetStringValues(string value)
        {
            return Values[value].Children().Select(x => new string[] { (string)x[0], (string)x[1] });
        }

    }
}
