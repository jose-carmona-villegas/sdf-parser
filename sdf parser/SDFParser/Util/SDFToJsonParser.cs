using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SDFParser.Util
{
	 public class SDFToJsonParser
	 {
		  private const string EndOfMoleculeDelimiter = "$$$$";
		  private static readonly string StartOfDataHeaderPattern = $"{Environment.NewLine}> ";
		  private const string MolfileTitle = "Structure";
		  private const string MolecularAttributeNamePattern = "<(.+)>";

		  public static string ToJson(string sdf)
		  {
				var parsedMolecules = new List<List<KeyValuePair<string, string>>>();

				var sdfMolecules = sdf.Split(EndOfMoleculeDelimiter);
				foreach (string sdfMolecule in sdfMolecules)
				{
					 var sdfAttributes = sdfMolecule.Trim().Split(StartOfDataHeaderPattern);
					 if (sdfAttributes.Count() == 1 && sdfAttributes.First() == string.Empty)
					 {
						  // Skip trailing new lines that may exist after the last end of molecule delimiter.
						  continue;
					 }

					 var parsedAttributes = new List<KeyValuePair<string, string>>();
					 foreach (string sdfAttribute in sdfAttributes)
					 {
						  if (sdfAttribute.Equals(sdfAttributes.First()))
						  {
								parsedAttributes.Add(new KeyValuePair<string, string>(MolfileTitle, sdfAttribute));
						  }
						  else
						  {
								Regex regex = new Regex(MolecularAttributeNamePattern);
								Match match = regex.Match(sdfAttribute);
								if (match.Success)
								{
									 // Get the Data Header
									 var parsedAttributeName = match.Value.Trim(new char[] { '<', '>' });

									 // Skip the Data Header line and join the rest
									 var parsedAttributeValue = string.Join(Environment.NewLine, sdfAttribute.Split(Environment.NewLine).Skip(1)).Trim();

									 parsedAttributes.Add(new KeyValuePair<string, string>(parsedAttributeName, parsedAttributeValue));
								}
								else
								{
									 throw new FormatException($"Couldn't find any molecular attribute in {sdfAttribute}");
								}
						  }
					 }

					 parsedMolecules.Add(parsedAttributes);
				}

				return ToJson(parsedMolecules);
		  }

		  private static string ToJson(List<List<KeyValuePair<string, string>>> sdf)
		  {
				string sequenceSeparator;
				string json = "[" + Environment.NewLine;
				foreach (var molecule in sdf)
				{
					 json += "\t{" + Environment.NewLine;

					 foreach (var attribute in molecule)
					 {
						  sequenceSeparator  = attribute.Key == molecule.Last().Key ? "" : ",";
						  json += $"\t\t\"{attribute.Key}\": \"{attribute.Value.Replace(Environment.NewLine, "\\n")}\"{sequenceSeparator}" + Environment.NewLine;
					 }

					 sequenceSeparator = molecule == sdf.Last() ? "" : ",";
					 json += $"\t}}{sequenceSeparator}" + Environment.NewLine;
				}
				json += "]" + Environment.NewLine;
				
				return json;
		  }
	 }
}
