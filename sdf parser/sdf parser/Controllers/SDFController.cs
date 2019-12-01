using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDFParser.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SDFParser.Controllers
{
	 [Route("api/[controller]")]
	 public class SDFController : Controller
	 {
		  [HttpGet("[action]")]
		  public IEnumerable<Molecule> Molecules()
		  {
				string json = "[{\"Structure\":\"untitled.mol\n  ChemDraw02191907502D\n\n 31 30  0  0  0  0  0  0  0  0999 V2000 ... M  END\",\"Purity_(_)\":\"214 %\",\"Molecular_Weight\":\"203.24 g/mol\",\"Molecular_Formula\":\"C9H17NO4\",\"Submitter_(E_mail)\":\"cheng-cheng.chen@perkinelmer.com\",\"Submitter_(Name)\":\"Cheng-Cheng Chen\",\"Submission_Date\":\"2019-02-15T05:26:30.259Z\",\"Amount\":\"203.115758 g\",\"Chemical_Name\":\"3-acetoxy-4-(trimethylammonio)butanoate\",\"ID\":\"0001-0001\",\"Exact_Mass\":\"203.115758\"},{\"Structure\":\"untitled.mol\n  ChemDraw02191907502D\n\n 14 13  0  0  0  0  0  0  0  0999 V2000 ... M END\",\"Purity_(_)\":\"22.9 %\",\"Molecular_Weight\":\"75.11 g/mol\",\"Molecular_Formula\":\"C3H9NO\",\"Submitter_(E_mail)\":\"cheng-cheng.chen@perkinelmer.com\",\"Submitter_(Name)\":\"Cheng-Cheng Chen\",\"Submission_Date\":\"2019-02-15T05:26:31.251Z\",\"Amount\":\"75.068414 g\",\"Chemical_Name\":\"1-aminopropan-2-ol\",\"ID\":\"0004-0001\",\"Exact_Mass\":\"75.068414\"},{\"Structure\":\"untitled.mol\n  ChemDraw02191907502D\n\n 16 16  0  0  0  0  0  0  0  0999 V2000 ... M END\",\"Purity_(_)\":\"224 %\",\"Molecular_Weight\":\"202.55 g/mol\",\"Molecular_Formula\":\"C6H3ClN2O4\",\"Submitter_(E_mail)\":\"cheng-cheng.chen@perkinelmer.com\",\"Submitter_(Name)\":\"Cheng-Cheng Chen\",\"Submission_Date\":\"2019-02-15T05:26:31.861Z\",\"Amount\":\"201.978134 g\",\"Chemical_Name\":\"1-chloro-2,4-dinitrobenzene\",\"ID\":\"0006-0001\",\"Exact_Mass\":\"201.978134\"}]";

				var molecules = Molecule.FromJson(json);
				return molecules;
		  }

		  [HttpPost("Upload")]
		  public async Task<IActionResult> Upload(List<IFormFile> files)
		  {
				if (files.Count != 1)
				{
					 return BadRequest();
				}

				IFormFile file = files.First();
				long size = file.Length;

				string fileExtension = Path.GetExtension(file.FileName);
				if (size <= 0 || fileExtension != ".sdf" || file.ContentType != MediaTypeNames.Application.Octet)
				{
					 return UnprocessableEntity();
				}
				
				var result = new StringBuilder();
				using (var reader = new StreamReader(file.OpenReadStream()))
				{
					 while (reader.Peek() >= 0)
						  result.AppendLine(await reader.ReadLineAsync());
				}
				string fileContent = result.ToString();

				return Ok(new { file.FileName, size, fileContent });
		  }
	 }
}
