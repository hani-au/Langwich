

function App({Data1}) {
return (
	<div className="App">
	<table>
		<tr>
		<th>Name</th>
		<th>Age</th>
		<th>Gender</th>
		</tr>
		{Data1.map((val, key) => {
		return (
			<tr key={key}>
			<td>{val.name}</td>
			<td>{val.age}</td>
			<td>{val.gender}</td>
			</tr>
		)
		})}
	</table>
	</div>
);
}

export default App;



