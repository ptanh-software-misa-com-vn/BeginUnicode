using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Anh.BeginUnicode
{
	/// <summary>
	/// \u Unicode
	/// </summary>
	public class UnicodeUtil
	{
		char X = '\u0058';   // Unicode
		static UnicodeEncoding UTF16 = new UnicodeEncoding();
		public UnicodeUtil()
		{
		}
	}

	public class UnicodeEncodingExample
	{
		public static void Main()
		{
			// The encoding.
			UnicodeEncoding unicode = new UnicodeEncoding();

			// Create a string that contains Unicode characters.
			String unicodeString =
				"This Unicode string contains two characters " +
				"with codes outside the traditional ASCII code range, " +
				"Pi (\u03a0) and Sigma (\u03a3).";
			Console.WriteLine("Original string:");
			Console.WriteLine(unicodeString);

			// Encode the string.
			Byte[] encodedBytes = unicode.GetBytes(unicodeString);
			Console.WriteLine();
			Console.WriteLine("Encoded bytes:");
			foreach (Byte b in encodedBytes)
			{
				Console.Write("[{0}]", b);
			}
			Console.WriteLine();

			// Decode bytes back to string.
			// Notice Pi and Sigma characters are still present.
			String decodedString = unicode.GetString(encodedBytes);
			Console.WriteLine();
			Console.WriteLine("Decoded bytes:");
			Console.WriteLine(decodedString);
		}
	}


	public class Example
	{
		public static void Main()
		{
			// Create a UTF-16 encoding that supports a BOM.
			Encoding unicode = new UnicodeEncoding();

			// A Unicode string with two characters outside an 8-bit code range.
			String unicodeString =
				"This Unicode string has 2 characters outside the " +
				"ASCII range: \n" +
				"Pi (\u03A0)), and Sigma (\u03A3).";
			Console.WriteLine("Original string:");
			Console.WriteLine(unicodeString);
			Console.WriteLine();

			// Encode the string.
			Byte[] encodedBytes = unicode.GetBytes(unicodeString);
			Console.WriteLine("The encoded string has {0} bytes.\n",
							  encodedBytes.Length);

			// Write the bytes to a file with a BOM.
			var fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Create);
			Byte[] bom = unicode.GetPreamble();
			fs.Write(bom, 0, bom.Length);
			fs.Write(encodedBytes, 0, encodedBytes.Length);
			Console.WriteLine("Wrote {0} bytes to the file.\n", fs.Length);
			fs.Close();

			// Open the file using StreamReader.
			var sr = new StreamReader(@".\UTF8Encoding.txt");
			String newString = sr.ReadToEnd();
			sr.Close();
			Console.WriteLine("String read using StreamReader:");
			Console.WriteLine(newString);
			Console.WriteLine();

			// Open the file as a binary file and decode the bytes back to a string.
			fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Open);
			Byte[] bytes = new Byte[fs.Length];
			fs.Read(bytes, 0, (int)fs.Length);
			fs.Close();

			String decodedString = unicode.GetString(bytes);
			Console.WriteLine("Decoded bytes:");
			Console.WriteLine(decodedString);
		}
	}
	// The example displays the following output:
	//    Original string:
	//    This Unicode string has 2 characters outside the ASCII range:
	//    Pi (π), and Sigma (Σ).
	//
	//    The encoded string has 172 bytes.
	//
	//    Wrote 174 bytes to the file.
	//
	//    String read using StreamReader:
	//    This Unicode string has 2 characters outside the ASCII range:
	//    Pi (π), and Sigma (Σ).
	//
	//    Decoded bytes:
	//    This Unicode string has 2 characters outside the ASCII range:
	//    Pi (π), and Sigma (Σ).

	public class XmlUnicodeTable
	{
		public static async Task<UnicodeData[][]> Main()
		{
			UnicodeData[][] x = await Task.Factory.StartNew<UnicodeData[][]>(ReadXml);
			return x;
		}

		private static UnicodeData[][] ReadXml()
		{
			IEnumerable<XElement> IEXelem = XElement.Load(@".\unicode-table.xml").Elements("ul");
			int i = 0, j = 0;
			UnicodeData[][] array2D = new UnicodeData[IEXelem.Count()][];
			foreach (XElement level1Element in IEXelem)
			{
				UnicodeData[] list = new UnicodeData[level1Element.Elements("li").Count()];
				foreach (XElement level2Element in level1Element.Elements("li"))
				{
					if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower().StartsWith("symb"))
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value,
							IsLeaf = true,
							DataCode = int.Parse(level2Element.Attribute("data-code").Value),
							Code = level2Element.Attribute("title") == null ? "" : level2Element.Attribute("title").Value.Split(new char[] { '|' })[0].Trim().Substring(2),
							Title = level2Element.Attribute("title") == null ? "" : level2Element.Attribute("title").Value
						};
					}
					else if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower() == "h")
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value.Trim(),
							IsLeaf = false,
							Code = level2Element.Value.Trim(),
							Title = "",
						};
						list[j].DataCode = Convert.ToInt32("0x" + list[j].Code, 16);
					}
					j++;
					if (j == list.Length)
					{
						j = 0;
					}
				}
				array2D[i] = list;
				i++;
			}
			return array2D;
		}

	}

	public class XmlUnicodeRange
	{
		public static async Task<UniCodeRange[]> Main()
		{
			UniCodeRange[] x = await Task.Factory.StartNew<UniCodeRange[]>(ReadXml);
			return x;
		}

		private static UniCodeRange[] ReadXml()
		{
			IEnumerable<XElement> IEXelem = XElement.Load(@".\unicode-range.xml").Elements("li");
			UniCodeRange[] list = new UniCodeRange[IEXelem.Count()];
			int i = 0;
			foreach (XElement level1Element in IEXelem)
			{
				list[i] = new UniCodeRange()
				{
					DataCode = level1Element.Element("span").Value,
					CodeBegin = level1Element.Element("a").Attribute("data-begin").Value,
					CodeEnd = level1Element.Element("a").Attribute("data-end").Value,
					Value = level1Element.Element("a").Attribute("data-key").Value,
					Name = level1Element.Element("a").Value,
					BaseUrl = "https://unicode-table.com",
					Href = level1Element.Element("a").Attribute("href").Value,
				};
				i++;
			}
			return list;
		}

	}

	public class XmlUnicodeRegion
	{
		public static async Task<UnicodeData[]> Main(params object[] pr)
		{
			if ((bool)pr[1])
			{
				UnicodeData[] x = await Task.Factory.StartNew<UnicodeData[]>((s) =>
																			{
																				return ReadXml((string)s);
																			}, pr[0]);

				return x;
			}
			else
			{
				UnicodeData[] x = await Task.Factory.StartNew<UnicodeData[]>((s) =>
				{
					return ReadXmlFile((string)s);
				}, pr[0]);

				return x;
			}
		}

		private static UnicodeData[] ReadXml(string source)
		{
			IEnumerable<XElement> IEXelem = XElement.Parse(source).Descendants("ul");
			XElement level1Element = null;
			foreach (XElement level1ElementT in IEXelem)
			{
				if (level1ElementT.Attribute("class") != null && level1ElementT.Attribute("class").Value.ToLower().StartsWith("unicode_table"))
				{
					level1Element = level1ElementT;
					break;
				}
			}

			int j = 0;
			UnicodeData[] list = new UnicodeData[level1Element.Elements("li").Count()];
			foreach (XElement level2Element in level1Element.Elements("li"))
			{
				if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower().StartsWith("symb"))
				{
					if (level2Element.Attribute("class").Value.ToLower().Contains("inactive"))
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value,
							IsLeaf = true,
							Inactive = true,
						};
					}
					else
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value,
							IsLeaf = true,
							Code = level2Element.Element("a").Attribute("href").Value.Split(new char[] { '/' })[2].Trim(),
							Title = level2Element.Attribute("title").Value,
						};
						list[j].DataCode = Convert.ToInt32("0x" + list[j].Code, 16);
					}
				}
				else if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower() == "h")
				{
					list[j] = new UnicodeData()
					{
						Name = level2Element.Value.Trim(),
						IsLeaf = false,
						Code = level2Element.Value.Trim(),
						Title = "",
					};
					list[j].DataCode = Convert.ToInt32("0x" + list[j].Code, 16);
				}
				j++;
				if (j == list.Length)
				{
					j = 0;
				}
			}

			return list;
		}
		private static UnicodeData[] ReadXmlFile(string fileName)
		{
			IEnumerable<XElement> level1Element = XElement.Load(fileName).Elements("ul");
			int j = 0;

			UnicodeData[] list = new UnicodeData[level1Element.Elements("li").Count()];
			foreach (XElement level2Element in level1Element.Elements("li"))
			{
				if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower().StartsWith("symb"))
				{
					if (level2Element.Attribute("class").Value.ToLower().Contains("inactive"))
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value,
							IsLeaf = true,
							Inactive = true,
						};
					}
					else
					{
						list[j] = new UnicodeData()
						{
							Name = level2Element.Value,
							IsLeaf = true,
							DataCode = int.Parse(level2Element.Attribute("data-code").Value),
							Code = level2Element.Attribute("data-code").Value,
							Title = level2Element.Attribute("title").Value,
						};
					}
				}
				else if (level2Element.Attribute("class") != null && level2Element.Attribute("class").Value.ToLower() == "h")
				{
					list[j] = new UnicodeData()
					{
						Name = level2Element.Value.Trim(),
						IsLeaf = false,
						Code = level2Element.Value.Trim(),
						Title = "",
					};
					list[j].DataCode = Convert.ToInt32("0x" + list[j].Code, 16);
				}
				j++;
				if (j == list.Length)
				{
					j = 0;
				}
			}

			return list;
		}
		public static void SaveXml(UnicodeData[] list, string fileName)
		{
			XDocument xd = new XDocument();
			XElement root = new XElement("root");
			XElement el = new XElement("ul");
			el.SetAttributeValue("class", "unicode_table");
			foreach (UnicodeData item in list)
			{
				XElement level2El = new XElement("li");
				if (item.IsLeaf)
				{
					level2El.SetAttributeValue("class", item.Inactive ? "symb inactive" : "symb");
					level2El.SetAttributeValue("data-code", item.DataCode);
					level2El.SetAttributeValue("code", item.Code);
					level2El.SetAttributeValue("title", item.Title);
					level2El.SetValue(item.Name);
				}
				else
				{
					level2El.SetAttributeValue("class", "h");
					level2El.SetValue(item.Name);
				}
				el.Add(level2El);
			}
			root.Add(el);
			xd.Add(root);
			xd.Save(fileName);
		}
	}

	public class UnicodeData
	{
		/// <summary>
		/// Key
		/// </summary>
		public int DataCode { get; set; }
		/// <summary>
		/// Unicode
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// Display Name
		/// </summary>
		public string Name { get; set; }
		public bool IsLeaf { get; set; }
		public string Title { get; set; }
		public bool Inactive { get; set; }
	}

	public class UniCodeRange
	{
		/// <summary>
		/// Key
		/// </summary>
		public string DataCode { get; set; }

		/// <summary>
		/// lowest code
		/// </summary>
		public string CodeBegin { get; set; }

		/// <summary>
		/// highest code
		/// </summary>
		public string CodeEnd { get; set; }

		/// <summary>
		/// Value
		/// </summary>
		public string Value { get; set; }
		/// <summary>
		/// Display Text
		/// </summary>
		public string Name { get; set; }

		private string _href;
		public string Href
		{
			get
			{
				if (_href == null || _href.Length == 0)
				{
					return BaseUrl;
				}
				else
				{
					return _href.StartsWith("http") ? _href : BaseUrl + _href;
				}
			}
			set { _href = value; }
		}
		public string BaseUrl { get; set; }
	}

	public class HtmlSourceCode
	{
		public static HtmlDocument Code(string Url)
		{

			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
			myRequest.Method = "GET";
			int loop = 5;
			WebResponse myResponse = null;
			while (loop > 0 && myResponse == null)
			{
				try
				{
					myResponse = myRequest.GetResponse();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					loop--;
				}
			}
			StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
			string result = sr.ReadToEnd();
			sr.Close();
			myResponse.Close();
			WebBrowser browser = new WebBrowser();
			browser.ScriptErrorsSuppressed = true;
			browser.DocumentText = result;
			browser.Document.OpenNew(true);
			browser.Document.Write(result);
			browser.Refresh();
			return browser.Document;
		}
		public static string FindCode(HtmlDocument doc)
		{
			HtmlElement result = null;
			foreach (HtmlElement item in doc.Body.GetElementsByTagName("ul"))
			{
				if (item.GetAttribute("class") != null)
				{
					string outer = item.OuterHtml;
					if (outer.Trim().ToLower().StartsWith(@"<ul class=""unicode_table"))
					{
						result = item;
						break;
					}

				}
			}
			string source = "<root>" + result.OuterHtml.Trim() + "</root>";
			source = source.ToLower();
			Regex regex = new Regex(@"=([\w|\.|\-]+)");
			source = regex.Replace(source, @"=""$1""");
			regex = new Regex(@"=\""\<([\w|\.|\-]+)\>\""");
			source = regex.Replace(source, @"=""$1""");
			//https://en.wikipedia.org/wiki/List_of_XML_and_HTML_character_entity_references
			source = source.Replace("&nbsp;", "&#160;");
			source = source.Replace("&shy;", "&#173;");
			return source;
		}
	}

	public class AppSetting
	{
		public static string GetKey(string key)
		{
			string result = "";
			result = ConfigurationManager.AppSettings[key];
			return result;
		}
		public static void SetKey(string key, string value)
		{
			ConfigurationManager.AppSettings[key] = value;
		}
		public static bool IsOpenFileGegionUnicodeData
		{
			get { return bool.Parse(GetKey("OpenFileGegionUnicodeData")); }
			internal set { SetKey("OpenFileGegionUnicodeData", value.ToString()); }
		}
	}
}
