using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIst.ValueType.Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//List<string> list1 = new List<string>{"a","b","c"};
			//List<string> list2 = list1;
			//list2[0] = "aaa";

			//Console.WriteLine(list1[0] +"  "+ list2[0]);

			string blue = "藍";
			string green = "綠";
			string yellow = "黃";
			string red = "紅";

			List<string> colorList = new List<string> { "藍", "綠", "黃", "紅" };

			for (int i = 0; i < 100; i++)
			{
				List<string> textsLeft = new List<string>(colorList);
				List<string> labelsLeft = new List<string>(colorList);

				string labelGreen = Choose(textsLeft, labelsLeft, green);
				string labelBlue = Choose(textsLeft, labelsLeft, blue);
				string labelRed = Choose(textsLeft, labelsLeft, red);
				string labelYellow = Choose(textsLeft, labelsLeft, yellow);

				string result = labelGreen + labelBlue + labelRed + labelYellow;
				Console.WriteLine(result);
			}
		}
		private static string Choose(List<string> textsLeft, List<string> labelsLeft, string labelColor)
		{
			int index;
			string labelText;

			//為了不讓最後剩的顏色和Label對應到的顏色相同
			if (textsLeft.Count == 2)
			{
				foreach (var text in textsLeft)
				{
					if (labelsLeft.Contains(text) && labelColor != text)
					{
						textsLeft.Remove(text);
						labelsLeft.Remove(labelColor);

						return text;
					}
				}
			}

			int count = 0;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			do
			{
				count++;
				if (count > 100) return string.Empty;
				index = random.Next(0, textsLeft.Count);
				labelText = textsLeft[index];
			} while (labelColor == labelText);

			textsLeft.RemoveAt(index);
			labelsLeft.Remove(labelColor);

			return labelText;
		}

	}
}
