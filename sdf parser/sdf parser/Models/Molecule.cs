using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace sdf_parser.Models
{
	 public partial class Molecule
	 {
		  [JsonProperty("Structure")]
		  public string Structure { get; set; }

		  [JsonProperty("Purity_(_)")]
		  public string Purity { get; set; }

		  [JsonProperty("Molecular_Weight")]
		  public string MolecularWeight { get; set; }

		  [JsonProperty("Molecular_Formula")]
		  public string MolecularFormula { get; set; }

		  [JsonProperty("Submitter_(E_mail)")]
		  public string SubmitterEMail { get; set; }

		  [JsonProperty("Submitter_(Name)")]
		  public string SubmitterName { get; set; }

		  [JsonProperty("Submission_Date")]
		  public string SubmissionDate { get; set; }

		  [JsonProperty("Amount")]
		  public string Amount { get; set; }

		  [JsonProperty("Chemical_Name")]
		  public string ChemicalName { get; set; }

		  [JsonProperty("ID")]
		  public string Id { get; set; }

		  [JsonProperty("Exact_Mass")]
		  public string ExactMass { get; set; }
	 }

	 public partial class Molecule
	 {
		  public static List<Molecule> FromJson(string json) => JsonConvert.DeserializeObject<List<Molecule>>(json, Converter.Settings);
	 }

	 public static class Serialize
	 {
		  public static string ToJson(this List<Molecule> self) => JsonConvert.SerializeObject(self, Converter.Settings);
	 }

	 internal static class Converter
	 {
		  public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		  {
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
				Converters =
				{
					 new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
				},
		  };
	 }
}
