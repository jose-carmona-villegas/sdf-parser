import React, { Component } from 'react';

export class SDFViewer extends Component {
	 displayName = SDFViewer.name

	 constructor(props) {
		  super(props);
		  this.state = { molecules: [], loading: true };

		  fetch('api/SDF/Molecules')
				.then(response => response.json())
				.then(data => {
					 this.setState({ molecules: data, loading: false });
				});
	 }

	 static renderMoleculesTable(molecules) {
		  return (
				molecules.map(molecule =>
					 <div key={molecule.ID} className="col-sm">
						  <div className="container" style={{backgroundColor: SDFViewer.generateRandomBrightColor()}}>
								<div className="row">Structure: {molecule.Structure}</div>
								<div className="row">Purity: {molecule["Purity_(_)"]}</div>
								<div className="row">Molecular weight: {molecule["Molecular_Weight"]}</div>
								<div className="row">Molecular formula: {molecule["Molecular_Formula"]}</div>
								<div className="row">Submitter email: {molecule["Submitter_(E_mail)"]}</div>
								<div className="row">Submitter name: {molecule["Submitter_(Name)"]}</div>
								<div className="row">Submission date: {molecule["Submission_Date"]}</div>
								<div className="row">Amount: {molecule.Amount}</div>
								<div className="row">Chemical name: {molecule["Chemical_Name"]}</div>
								<div className="row">ID: {molecule.ID}</div>
								<div className="row">Exact mass: {molecule["Exact_Mass"]}</div>
						  </div>
					 </div>
				));
	 }

	 static generateRandomBrightColor() {
		  let r = Math.round((Math.random() * 120) + 135);
		  let g = Math.round((Math.random() * 120) + 135);
		  let b = Math.round((Math.random() * 120) + 135);
		  return 'rgb(' + r + ', ' + g + ', ' + b + ')';
	 };

	 render() {
		  let contents = this.state.loading
				? <p><em>Loading...</em></p>
				: <div className="container"><div className="row">{SDFViewer.renderMoleculesTable(this.state.molecules)}</div></div>;

		  return (
				<div>
					 <h1>SDF Viewer</h1>
					 {contents}
				</div>
		  );
	 }
}
