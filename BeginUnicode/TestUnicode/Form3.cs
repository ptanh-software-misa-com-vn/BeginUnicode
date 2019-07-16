using Anh.BeginUnicode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Anh.TestUnicode
{
    public partial class Form3 : Form
    {
        #region Field
        #endregion

        #region Constructor
        public Form3()
        {
            InitializeComponent();
            Task.Factory.StartNew(Initialize2);
        }
        #endregion

        #region Initialize
        private async Task Initialize2()
        {
            Task<UniCodeRange[]> t = Task.Run(() =>
            {
                UniCodeRange[] list = new UniCodeRange[]
                {
                    new UniCodeRange(){DataCode ="",CodeBegin = "0020",CodeEnd ="007F",Value = "0020-007F",Name = "Basic Latin",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0020-007F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "00A0",CodeEnd ="00FF",Value = "00A0-00FF",Name = "Latin 1 Supplement",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "00A0-00FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0100",CodeEnd ="017F",Value = "0100-017F",Name = "Latin Extended A",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0100-017F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0180",CodeEnd ="024F",Value = "0180-024F",Name = "Latin Extended B",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0180-024F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0250",CodeEnd ="02AF",Value = "0250-02AF",Name = "IPA Extensions",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0250-02AF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "02B0",CodeEnd ="02FF",Value = "02B0-02FF",Name = "Spacing Modifier Letters",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "02B0-02FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0300",CodeEnd ="036F",Value = "0300-036F",Name = "Combining Diacritical Marks",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0300-036F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0370",CodeEnd ="03FF",Value = "0370-03FF",Name = "Greek and Coptic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0370-03FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0400",CodeEnd ="04FF",Value = "0400-04FF",Name = "Cyrillic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0400-04FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0500",CodeEnd ="052F",Value = "0500-052F",Name = "Cyrillic Supplementary",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0500-052F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0530",CodeEnd ="058F",Value = "0530-058F",Name = "Armenian",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0530-058F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0590",CodeEnd ="05FF",Value = "0590-05FF",Name = "Hebrew",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0590-05FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0600",CodeEnd ="06FF",Value = "0600-06FF",Name = "Arabic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0600-06FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0700",CodeEnd ="074F",Value = "0700-074F",Name = "Syriac",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0700-074F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0780",CodeEnd ="07BF",Value = "0780-07BF",Name = "Thaana",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0780-07BF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0900",CodeEnd ="097F",Value = "0900-097F",Name = "Devanagari",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0900-097F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0980",CodeEnd ="09FF",Value = "0980-09FF",Name = "Bengali",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0980-09FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0A00",CodeEnd ="0A7F",Value = "0A00-0A7F",Name = "Gurmukhi",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0A00-0A7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0A80",CodeEnd ="0AFF",Value = "0A80-0AFF",Name = "Gujarati",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0A80-0AFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0B00",CodeEnd ="0B7F",Value = "0B00-0B7F",Name = "Oriya",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0B00-0B7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0B80",CodeEnd ="0BFF",Value = "0B80-0BFF",Name = "Tamil",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0B80-0BFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0C00",CodeEnd ="0C7F",Value = "0C00-0C7F",Name = "Telugu",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0C00-0C7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0C80",CodeEnd ="0CFF",Value = "0C80-0CFF",Name = "Kannada",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0C80-0CFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0D00",CodeEnd ="0D7F",Value = "0D00-0D7F",Name = "Malayalam",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0D00-0D7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0D80",CodeEnd ="0DFF",Value = "0D80-0DFF",Name = "Sinhala",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0D80-0DFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0E00",CodeEnd ="0E7F",Value = "0E00-0E7F",Name = "Thai",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0E00-0E7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0E80",CodeEnd ="0EFF",Value = "0E80-0EFF",Name = "Lao",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0E80-0EFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "0F00",CodeEnd ="0FFF",Value = "0F00-0FFF",Name = "Tibetan",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "0F00-0FFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1000",CodeEnd ="109F",Value = "1000-109F",Name = "Myanmar",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1000-109F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10A0",CodeEnd ="10FF",Value = "10A0-10FF",Name = "Georgian",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10A0-10FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1100",CodeEnd ="11FF",Value = "1100-11FF",Name = "Hangul Jamo",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1100-11FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1200",CodeEnd ="137F",Value = "1200-137F",Name = "Ethiopic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1200-137F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "13A0",CodeEnd ="13FF",Value = "13A0-13FF",Name = "Cherokee",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "13A0-13FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1400",CodeEnd ="167F",Value = "1400-167F",Name = "Unified Canadian Aboriginal Syllabics",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1400-167F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1680",CodeEnd ="169F",Value = "1680-169F",Name = "Ogham",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1680-169F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "16A0",CodeEnd ="16FF",Value = "16A0-16FF",Name = "Runic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "16A0-16FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1700",CodeEnd ="171F",Value = "1700-171F",Name = "Tagalog",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1700-171F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1720",CodeEnd ="173F",Value = "1720-173F",Name = "Hanunoo",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1720-173F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1740",CodeEnd ="175F",Value = "1740-175F",Name = "Buhid",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1740-175F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1760",CodeEnd ="177F",Value = "1760-177F",Name = "Tagbanwa",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1760-177F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1780",CodeEnd ="17FF",Value = "1780-17FF",Name = "Khmer",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1780-17FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1800",CodeEnd ="18AF",Value = "1800-18AF",Name = "Mongolian",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1800-18AF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1900",CodeEnd ="194F",Value = "1900-194F",Name = "Limbu",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1900-194F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1950",CodeEnd ="197F",Value = "1950-197F",Name = "Tai Le",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1950-197F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "19E0",CodeEnd ="19FF",Value = "19E0-19FF",Name = "Khmer Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "19E0-19FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1D00",CodeEnd ="1D7F",Value = "1D00-1D7F",Name = "Phonetic Extensions",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1D00-1D7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1E00",CodeEnd ="1EFF",Value = "1E00-1EFF",Name = "Latin Extended Additional",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1E00-1EFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1F00",CodeEnd ="1FFF",Value = "1F00-1FFF",Name = "Greek Extended",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1F00-1FFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2000",CodeEnd ="206F",Value = "2000-206F",Name = "General Punctuation",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2000-206F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2070",CodeEnd ="209F",Value = "2070-209F",Name = "Superscripts and Subscripts",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2070-209F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "20A0",CodeEnd ="20CF",Value = "20A0-20CF",Name = "Currency Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "20A0-20CF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "20D0",CodeEnd ="20FF",Value = "20D0-20FF",Name = "Combining Diacritical Marks for Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "20D0-20FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2100",CodeEnd ="214F",Value = "2100-214F",Name = "Letterlike Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2100-214F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2150",CodeEnd ="218F",Value = "2150-218F",Name = "Number Forms",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2150-218F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2190",CodeEnd ="21FF",Value = "2190-21FF",Name = "Arrows",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2190-21FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2200",CodeEnd ="22FF",Value = "2200-22FF",Name = "Mathematical Operators",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2200-22FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2300",CodeEnd ="23FF",Value = "2300-23FF",Name = "Miscellaneous Technical",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2300-23FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2400",CodeEnd ="243F",Value = "2400-243F",Name = "Control Pictures",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2400-243F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2440",CodeEnd ="245F",Value = "2440-245F",Name = "Optical Character Recognition",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2440-245F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2460",CodeEnd ="24FF",Value = "2460-24FF",Name = "Enclosed Alphanumerics",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2460-24FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2500",CodeEnd ="257F",Value = "2500-257F",Name = "Box Drawing",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2500-257F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2580",CodeEnd ="259F",Value = "2580-259F",Name = "Block Elements",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2580-259F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "25A0",CodeEnd ="25FF",Value = "25A0-25FF",Name = "Geometric Shapes",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "25A0-25FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2600",CodeEnd ="26FF",Value = "2600-26FF",Name = "Miscellaneous Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2600-26FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2700",CodeEnd ="27BF",Value = "2700-27BF",Name = "Dingbats",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2700-27BF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "27C0",CodeEnd ="27EF",Value = "27C0-27EF",Name = "Miscellaneous Mathematical Symbols A",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "27C0-27EF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "27F0",CodeEnd ="27FF",Value = "27F0-27FF",Name = "Supplemental Arrows A",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "27F0-27FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2800",CodeEnd ="28FF",Value = "2800-28FF",Name = "Braille Patterns",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2800-28FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2900",CodeEnd ="297F",Value = "2900-297F",Name = "Supplemental Arrows B",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2900-297F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2980",CodeEnd ="29FF",Value = "2980-29FF",Name = "Miscellaneous Mathematical Symbols B",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2980-29FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2A00",CodeEnd ="2AFF",Value = "2A00-2AFF",Name = "Supplemental Mathematical Operators",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2A00-2AFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2B00",CodeEnd ="2BFF",Value = "2B00-2BFF",Name = "Miscellaneous Symbols and Arrows",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2B00-2BFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2E80",CodeEnd ="2EFF",Value = "2E80-2EFF",Name = "CJK Radicals Supplement",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2E80-2EFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2F00",CodeEnd ="2FDF",Value = "2F00-2FDF",Name = "Kangxi Radicals",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2F00-2FDF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2FF0",CodeEnd ="2FFF",Value = "2FF0-2FFF",Name = "Ideographic Description Characters",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2FF0-2FFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3000",CodeEnd ="303F",Value = "3000-303F",Name = "CJK Symbols and Punctuation",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3000-303F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3040",CodeEnd ="309F",Value = "3040-309F",Name = "Hiragana",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3040-309F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "30A0",CodeEnd ="30FF",Value = "30A0-30FF",Name = "Katakana",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "30A0-30FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3100",CodeEnd ="312F",Value = "3100-312F",Name = "Bopomofo",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3100-312F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3130",CodeEnd ="318F",Value = "3130-318F",Name = "Hangul Compatibility Jamo",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3130-318F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3190",CodeEnd ="319F",Value = "3190-319F",Name = "Kanbun",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3190-319F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "31A0",CodeEnd ="31BF",Value = "31A0-31BF",Name = "Bopomofo Extended",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "31A0-31BF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "31F0",CodeEnd ="31FF",Value = "31F0-31FF",Name = "Katakana Phonetic Extensions",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "31F0-31FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3200",CodeEnd ="32FF",Value = "3200-32FF",Name = "Enclosed CJK Letters and Months",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3200-32FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3300",CodeEnd ="33FF",Value = "3300-33FF",Name = "CJK Compatibility",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3300-33FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "3400",CodeEnd ="4DBF",Value = "3400-4DBF",Name = "CJK Unified Ideographs Extension A",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "3400-4DBF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "4DC0",CodeEnd ="4DFF",Value = "4DC0-4DFF",Name = "Yijing Hexagram Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "4DC0-4DFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "4E00",CodeEnd ="9FFF",Value = "4E00-9FFF",Name = "CJK Unified Ideographs",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "4E00-9FFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "A000",CodeEnd ="A48F",Value = "A000-A48F",Name = "Yi Syllables",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "A000-A48F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "A490",CodeEnd ="A4CF",Value = "A490-A4CF",Name = "Yi Radicals",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "A490-A4CF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "AC00",CodeEnd ="D7AF",Value = "AC00-D7AF",Name = "Hangul Syllables",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "AC00-D7AF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "D800",CodeEnd ="DB7F",Value = "D800-DB7F",Name = "High Surrogates",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "D800-DB7F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "DB80",CodeEnd ="DBFF",Value = "DB80-DBFF",Name = "High Private Use Surrogates",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "DB80-DBFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "DC00",CodeEnd ="DFFF",Value = "DC00-DFFF",Name = "Low Surrogates",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "DC00-DFFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "E000",CodeEnd ="F8FF",Value = "E000-F8FF",Name = "Private Use Area",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "E000-F8FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "F900",CodeEnd ="FAFF",Value = "F900-FAFF",Name = "CJK Compatibility Ideographs",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "F900-FAFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FB00",CodeEnd ="FB4F",Value = "FB00-FB4F",Name = "Alphabetic Presentation Forms",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FB00-FB4F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FB50",CodeEnd ="FDFF",Value = "FB50-FDFF",Name = "Arabic Presentation Forms A",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FB50-FDFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FE00",CodeEnd ="FE0F",Value = "FE00-FE0F",Name = "Variation Selectors",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FE00-FE0F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FE20",CodeEnd ="FE2F",Value = "FE20-FE2F",Name = "Combining Half Marks",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FE20-FE2F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FE30",CodeEnd ="FE4F",Value = "FE30-FE4F",Name = "CJK Compatibility Forms",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FE30-FE4F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FE50",CodeEnd ="FE6F",Value = "FE50-FE6F",Name = "Small Form Variants",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FE50-FE6F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FE70",CodeEnd ="FEFF",Value = "FE70-FEFF",Name = "Arabic Presentation Forms B",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FE70-FEFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FF00",CodeEnd ="FFEF",Value = "FF00-FFEF",Name = "Halfwidth and Fullwidth Forms",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FF00-FFEF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "FFF0",CodeEnd ="FFFF",Value = "FFF0-FFFF",Name = "Specials",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "FFF0-FFFF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10000",CodeEnd ="1007F",Value = "10000-1007F",Name = "Linear B Syllabary",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10000-1007F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10080",CodeEnd ="100FF",Value = "10080-100FF",Name = "Linear B Ideograms",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10080-100FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10100",CodeEnd ="1013F",Value = "10100-1013F",Name = "Aegean Numbers",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10100-1013F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10300",CodeEnd ="1032F",Value = "10300-1032F",Name = "Old Italic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10300-1032F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10330",CodeEnd ="1034F",Value = "10330-1034F",Name = "Gothic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10330-1034F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10380",CodeEnd ="1039F",Value = "10380-1039F",Name = "Ugaritic",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10380-1039F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10400",CodeEnd ="1044F",Value = "10400-1044F",Name = "Deseret",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10400-1044F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10450",CodeEnd ="1047F",Value = "10450-1047F",Name = "Shavian",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10450-1047F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10480",CodeEnd ="104AF",Value = "10480-104AF",Name = "Osmanya",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10480-104AF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "10800",CodeEnd ="1083F",Value = "10800-1083F",Name = "Cypriot Syllabary",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "10800-1083F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1D000",CodeEnd ="1D0FF",Value = "1D000-1D0FF",Name = "Byzantine Musical Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1D000-1D0FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1D100",CodeEnd ="1D1FF",Value = "1D100-1D1FF",Name = "Musical Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1D100-1D1FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1D300",CodeEnd ="1D35F",Value = "1D300-1D35F",Name = "Tai Xuan Jing Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1D300-1D35F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "1D400",CodeEnd ="1D7FF",Value = "1D400-1D7FF",Name = "Mathematical Alphanumeric Symbols",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "1D400-1D7FF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "20000",CodeEnd ="2A6DF",Value = "20000-2A6DF",Name = "CJK Unified Ideographs Extension B",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "20000-2A6DF",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "2F800",CodeEnd ="2FA1F",Value = "2F800-2FA1F",Name = "CJK Compatibility Ideographs Supplement",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "2F800-2FA1F",},
                    new UniCodeRange(){DataCode ="",CodeBegin = "E0000",CodeEnd ="E007F",Value = "E0000-E007F",Name = "Tags",BaseUrl = "https://jrgraphix.net/r/Unicode/",Href = "E0000-E007F",},

                };

                return list;
            });

            UniCodeRange[] array1D = await t;
            BeginInvoke(new Action(() =>
            {
                //cboUnicodeRange.Items.AddRange(array1D.Take(3).ToArray());
                cboUnicodeRange.Items.AddRange(array1D);
                cboUnicodeRange.ValueMember = "Value";
                cboUnicodeRange.DisplayMember = "Name";
            }));
        }
        #endregion

        #region Bussiness

        #endregion

        #region EVENTS

        #region cboUnicodeRange_SelectedIndexChanged
        private async void cboUnicodeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            UniCodeRange range = cboUnicodeRange.SelectedItem as UniCodeRange;
            string source = await Code(range.Href);
            UnicodeData[] us = await ReadXml(source);
            StringBuilder sbText = new StringBuilder();
            UnicodeData item = null;
            for (int i = 0; i < us.Count(); i++)
            {
                item = us[i];
                if (item != null)
                {
                    int c = item.DataCode;
                    string s = ((char)c).ToString();
                    sbText.AppendLine(s);
                }
            }
           
            textBox1.Text = sbText.ToString();

        }
        #endregion

        #region btnUnicode_Click
        private void btnUnicode_Click(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            UnicodeData d = butt.Tag as UnicodeData;
            //int c = Convert.ToInt32("0x" + d.Code, 16);
            int c = d.DataCode;
            string s = ((char)c).ToString();
            textBox1.AppendText(s);
        }
        #endregion

        #endregion

        private async void btnPut_Click(object sender, EventArgs e)
        {
            if (cboUnicodeRange.SelectedValue == null)
            {
                cboUnicodeRange.SelectedValue = "4E00-9FFF";
            }
            UniCodeRange range = cboUnicodeRange.SelectedItem as UniCodeRange;
            string source = await Code(range.Href);
            UnicodeData[] us = await ReadXml(source);
            StringBuilder sbText = new StringBuilder();
            foreach (var item in us)
            {
                if (item != null)
                {
                    int c = item.DataCode;
                    string s = ((char)c).ToString();
                    sbText.AppendLine(s);
                }
            }
            textBox1.Text = sbText.ToString();
        }

        private async static Task<string> Code(string Url)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task<string> t = Task.Run(() =>
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
                myRequest.Method = "GET";
                int loop = 10;
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
                if (myResponse == null)
                {
                    throw new System.Net.WebException(Url);
                }
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                return result;
            }).ContinueWith<HtmlDocument>((r) =>
            {
                WebBrowser browser = new WebBrowser();
                browser.ScriptErrorsSuppressed = true;
                browser.DocumentText = r.Result;
                browser.Document.OpenNew(true);
                browser.Document.Write(r.Result);
                browser.Refresh();
                browser.Document.Title = Url;
                return browser.Document;
            }, scheduler).ContinueWith<string>((r) =>
            {
                return FindCode(r.Result);
            }, scheduler);
            string res = await t;
            return res;
        }

        private static string FindCode(HtmlDocument doc)
        {

            List<HtmlElement> result = new List<HtmlElement>();
            foreach (HtmlElement item in doc.Body.GetElementsByTagName("div"))
            {
                if (item.GetAttribute("class") != null)
                {
                    string outer = item.OuterHtml;
                    if (outer.Trim().ToLower().StartsWith(@"<div class=row"))
                    {
                        result.Add(item);
                    }

                }
            }
            if (result == null)
            {
                return "<root></root>";
            }
            StringBuilder sbSource = new StringBuilder();
            string source = "";
            sbSource.AppendLine("<root>");
            foreach (var item in result)
            {
                sbSource.Append(item.InnerHtml.Trim());
            }
            sbSource.AppendLine("</root>");
            source = sbSource.ToString();
            source = source.ToLower();
            Regex regex = new Regex(@"=([\w|\.|\-]+)");
            source = regex.Replace(source, @"=""$1""");
            regex = new Regex(@"=\""\<([\w|\.|\-]+)\>\""");
            source = regex.Replace(source, @"=""$1""");
            regex = new Regex(@"=\""\<([\w|\s]+)\>\""");
            source = regex.Replace(source, @"=""$1""");
            //https://en.wikipedia.org/wiki/List_of_XML_and_HTML_character_entity_references
            source = source.Replace("&nbsp;", "&#160;");
            source = source.Replace("&shy;", "&#173;");

            return source;
        }

        private async static Task<UnicodeData[]> ReadXml(string source)
        {
            Task<UnicodeData[]> t = Task.Run(() =>
            {
                IEnumerable<XElement> IEXelem = XElement.Parse(source).Descendants();
                int j = 0;
                UnicodeData[] list = new UnicodeData[IEXelem.Count()];
                foreach (XElement level1Element in IEXelem)
                {
                    //< div class="u"><span>䷀</span><tt>4dc0</tt></div>
                    if (level1Element.Attribute("class") != null && level1Element.Attribute("class").Value.ToLower().StartsWith("u"))
                    {
                        list[j] = new UnicodeData()
                        {
                            Name = level1Element.Element("span").Value,
                            IsLeaf = true,
                            Code = level1Element.Element("tt").Value,
                            Title = level1Element.Element("span").Value,
                        };
                        list[j].DataCode = Convert.ToInt32("0x" + list[j].Code, 16);
                    }
                    j++;
                }

                return list;
            });
            UnicodeData[] res = await t;
            return res;
        }
    }
}
