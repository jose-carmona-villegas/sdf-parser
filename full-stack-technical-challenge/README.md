# Tasks

This exercise will be used to assess your knowledge of backend and frontend technologies and tools. 

## Coding Guide
- You have to use git to manage the change history.
- You have to publish your solution in a public git repository, or as a zip file with the full repository, including the .git folder.
- You have to use different languages for the frontend and the backend (i.e. C# for the backend / javascript for the frontend).
- You should use a CSS framework to style the resulting page (i.e. bootstrap).
- You should have reasonable packages, classes, interfaces, methods and variables.
- You should have necessary code comments.
- You should have unit tests.
- You can setup the projects using your favorite IDE.
- You can use any frameworks or libraries.

## Backend

You have to implement a parser to process a **SDF** file, and to save the parsed result to a JSON file. 

- Input: a SDF file. See an example of the input file format in `examples/sample_1.sdf` or `examples/sample_2.sdf`
- Output: a JSON file. See an example of the output file format in `examples/output_example.json` (part of the `Structure` field is omitted)
- See `Ref. 1: SD Files` below for the format of an SDF file
- Note: the field names (e.g. `ID`, `Chemical_Name`, `Exact_Mass`) are not fixed. You should not write hard-coded field names in your code.

## Frontend

You have to create a web app that allows an user to:

- upload a SDF file using a web browser that will be parsed by the parser implemented in the previous backend task.
- show the different records of the SDF file and their attributes as a list.
- use a text input to filter the list of visible attributes based on a pattern (i.e. show only the attributes that match with "Chemical")
- render the MOL section of the record graphically as a molecule. (*)

(*) Note: To convert the MOL text to PNG image file

- Input: the MOL text extracted from Task 1 (value of `Structure` field). See example MOL file `examples/sample_1_01.mol`
- Output: a PNG file. See example image file `examples/sample_1_01.png`
- See `Ref. 2: CDWS API` below for how to generate the PNG


# References

## Ref. 1: SD Files
The details about SD Files and MOL file can be found in `docs/ctfile.pdf` ("Chapter 6: SDfiles") or `docs/SDfile.PNG`.

## Ref. 2: CDWS API
CDWS (ChemDraw Web Service) is an HTTP service that can support multiple chemical calculation. You can call this service to generate image from MOL text.

- URL: https://chemdrawdirect.perkinelmer.cloud/rest/generateImage
- HTTP Method: POST
- Request body format (JSON):
```json
{
	"chemData": <MOL text here>,
	"chemDataType": "chemical/x-mdl-molfile",
	"imageType": "image/png"
}
```
- Response data format: Image data

For more details, please refer to https://chemdrawdirect.perkinelmer.cloud/rest/help/operations/ToImageResource.
