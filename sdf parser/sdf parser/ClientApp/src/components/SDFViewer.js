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
					 <div key={molecule.id} className="col-sm">
						  <div className="container" style={{backgroundColor: SDFViewer.generateRandomBrightColor()}}>
								<div className="row">Structure: {molecule.structure}</div>
								<div className="row">Purity: {molecule.purity}</div>
								<div className="row">Molecular weight: {molecule.molecularWeight}</div>
								<div className="row">Molecular formula: {molecule.molecularFormula}</div>
								<div className="row">Submitter email: {molecule.submitterEmail}</div>
								<div className="row">Submitter name: {molecule.submitterName}</div>
								<div className="row">Submission date: {molecule.submissionDate}</div>
								<div className="row">Amount: {molecule.amount}</div>
								<div className="row">Chemical name: {molecule.chemicalName}</div>
								<div className="row">ID: {molecule.id}</div>
								<div className="row">Exact mass: {molecule.exactMass}</div>
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
