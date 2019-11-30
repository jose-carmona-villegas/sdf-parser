using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sdf_parser.Controllers
{
	 [Route("api/[controller]")]
	 public class SDFController : Controller
	 {
		  private static string[] Summaries = new[]
		  {
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		  };

		  [HttpGet("[action]")]
		  public IEnumerable<Molecule> Molecules()
		  {
				return new List<Molecule>()
				{
					 new Molecule()
					 { 
						  Structure = "untitled.mol\n  ChemDraw02191907502D\n\n 31 30  0  0  0  0  0  0  0  0999 V2000 ... M  END",
						  Purity="214 %", 
						  MolecularWeight="203.24 g/mol",
						  MolecularFormula="C9H17NO4",
						  SubmitterEmail="cheng-cheng.chen@perkinelmer.com",
						  SubmitterName="Cheng-Cheng Chen",
						  SubmissionDate="2019-02-15T05:26:30.259Z",
						  Amount="203.115758 g",
						  ChemicalName="3-acetoxy-4-(trimethylammonio)butanoate",
						  ID="0001-0001",
						  ExactMass="203.115758"
					 },
					 new Molecule()
					 {
						  Structure = "untitled.mol\n  ChemDraw02191907502D\n\n 14 13  0  0  0  0  0  0  0  0999 V2000 ... M END",
						  Purity="22.9 %",
						  MolecularWeight="75.11 g/mol",
						  MolecularFormula="C3H9NO",
						  SubmitterEmail="cheng-cheng.chen@perkinelmer.com",
						  SubmitterName="Cheng-Cheng Chen",
						  SubmissionDate="2019-02-15T05:26:31.251Z",
						  Amount="75.068414 g",
						  ChemicalName="1-aminopropan-2-ol",
						  ID="0004-0001",
						  ExactMass="75.068414"
					 },
					 new Molecule()
					 {
						  Structure = "untitled.mol\n  ChemDraw02191907502D\n\n 16 16  0  0  0  0  0  0  0  0999 V2000 ... M END",
						  Purity="224 %",
						  MolecularWeight="202.55 g/mol",
						  MolecularFormula="C6H3ClN2O4",
						  SubmitterEmail="cheng-cheng.chen@perkinelmer.com",
						  SubmitterName="Cheng-Cheng Chen",
						  SubmissionDate="2019-02-15T05:26:31.861Z",
						  Amount="201.978134 g",
						  ChemicalName="1-chloro-2,4-dinitrobenzene",
						  ID="0006-0001",
						  ExactMass="201.978134"
					 }
				};
		  }

		  public class Molecule
		  {
				public string Structure { get; set; }
				public string Purity { get; set; }
				public string MolecularWeight { get; set; }
				public string MolecularFormula { get; set; }
				public string SubmitterEmail { get; set; }
				public string SubmitterName { get; set; }
				public string SubmissionDate { get; set; }
				public string Amount { get; set; }
				public string ChemicalName { get; set; }
				public string ID { get; set; }
				public string ExactMass { get; set; }
		  }
	 }
}
