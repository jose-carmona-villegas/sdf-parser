import React, { Component } from 'react';

export class Home extends Component
{
	 displayName = Home.name

	 constructor(props) {
		  super(props);
		  this.state = {
				parsedJson: "", loading: true };

		  fetch('api/SDF/ParsedSDF')
				.then(response => response.text())
				.then(data => {
					 this.setState({ parsedJson: data, loading: false });
				});
	 }

	 render()
	 {
		  let contents = this.state.loading
				? <p><em>Loading...</em></p>
				: <div className="container"><p>{this.state.parsedJson}</p></div>;
		  
		  return (
			 <div>
					 <h1>Upload your SDF file</h1>

					 <form method="post" encType="multipart/form-data" action="api/SDF/Upload">
						  <div>
								<input type="file" name="files" />
						  </div>
						  <div>
								<input type="submit" value="Upload" />
						  </div>
					 </form>

					 {contents}
				</div>
		  );
	 }
}
