using Lotr2Inspector.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lotr2Inspector
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btGenerateTowns_Click(object sender, EventArgs e)
        {
            generateCTXML(Game.Towns, "Town");
		}

        private void btGeneratePlayers_Click(object sender, EventArgs e)
        {
            generateCTXML(Game.Players, "Player");
        }

        private void generateCTXML(MemStruct[] memStructs, String itemName)
		{
            uint ID = 0;
            uint itemNum = 0;
            String VariableType = "";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("\t");
            settings.CloseOutput = true;
            //settings.OmitXmlDeclaration = true;

            using(XmlWriter writer = XmlWriter.Create($"{itemName}.CT", settings))
            {
                writer.WriteStartElement("CheatTable");
                writer.WriteAttributeString("CheatEngineTableVersion", "31");
                writer.WriteStartElement("CheatEntries");

                //////////////////////////////////
                foreach(MemStruct t in memStructs)
                {
                    foreach(KeyValuePair<string, MemStructProperty> m in t.Properties)
                    {
                        switch(m.Value.Size)
                        {
                            default:
                            case 1:
                                VariableType = "Byte";
                            break;

                            case 2:
                                VariableType = "2 Bytes";
                            break;

                            case 4:
                                VariableType = "4 Bytes";
                            break;
                        }

                        writer.WriteStartElement("CheatEntry");
                        writer.WriteElementString("ID", ID++.ToString());
                        writer.WriteElementString("Description", $"\"{itemName} {itemNum} {m.Key}\"");
                        writer.WriteElementString("VariableType", VariableType);
                        writer.WriteElementString("Address", $"Lords2.exe+{t.GetBaseStructAddress(m.Key).ToString("x")}");
                        writer.WriteEndElement(); // CheatEntry
                    }

                    itemNum++;
                }
                //////////////////////////////////

                writer.WriteEndElement(); // CheatEntries

                writer.WriteElementString("UserdefinedSymbols", "");

                writer.WriteEndElement(); // CheatTable
                writer.Flush();
            }
        }
	}
}
