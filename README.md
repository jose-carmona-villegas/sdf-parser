# SDFParser

## Links

- [Published app on Azure](https://sdfparser.azurewebsites.net)
- [Published repository](https://github.com/Zalioth/sdf-parser)

## Technology stack

Implemented using:

- ASP.NET Core 2.1.1
- React.js 16.0
- Bootstrap 4.4.1

IDE used:

- Visual Studio 2017 Community edition

## TODO

Still pending:

- Unit test the classes.
- Prettify the generated JSON file.
- Use the memory representation of the parsed SDF file to populate the SDF Viewer section (at the moment it uses mocked data) and add the attribute filtering by pattern.
- Fetch the molecules' rendering from the ChemDraw Web Service (for each molecule, simply send the mol data and receive the image as response).

## Future considerations

- Improve the UI to show user friendly error messages (at the moment it shows the error code only).
- Enable/disable the Upload button depending on whether a file was selected (hook up the events).
- Currently, the JSON code is stored in a memory cache, and a multi-user environment will cause trouble. In the future, a hashed id should be generated for the user who requests the parsing (and sent back to the client) so the client can later request the corresponding json (and not the one from some other client).
- As the SDF files can potentially be used as a non-relational database, the parser could be paralelized (once split by molecule, each molecule can be parsed separately) to improve its efficiency.
- In order to assure scalability, the controller should not simply call the parser. Instead, depending on the size of the file, the parsing should be marshalized into a task (which, as stated in the previous line, could also be paralellized for increased efficiency). Beware of overheads.
- If the amount of users is extremely large, it might be necessary to process the parsings in a set of queues (depending on our available resources).
- Validate the JSON (for now I manually checked the outputs were valid on [JSON Formatter & Validator](https://jsonformatter.curiousconcept.com).
- Validate the input SDF files (currently the application assumes the format will be valid, although it makes sure the file's size, extension and MIME type are valid).
- Unit testing will require implementing some adapters or refactoring some static functions (Parser and Molecule). Using [xUnit](https://xunit.net) is recommended since its high paralellization capabilities would maximize efficiency. [NSubstitute](https://nsubstitute.github.io) as a mocking library is highly recommended due to its simple and readable syntax.
- The serializable class Molecule assumes only supports some attributes, but since the attribute names are not set by the format, a generic class could be implemented, or a different representation should be used (such as the internal representation in the parser). The Molecule class was generated using [Quicktype](https://quicktype.io/) to easily mock data and work on the viewer UI.
- Several libraries could be used to expand the application's functionality, such as [Open Babel](http://openbabel.org) or [RDKit](http://www.rdkit.org/). In the case of RDKit, as it has a C++ implementation, a direct usage could be achieved though the .NET Interop package.
- Through WebGL, a 3D rendering of the molecule could also be served.
