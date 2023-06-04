import "./Dictionary.css";

function Dictionary({DynamicData}) {
  return (
    <><img src="./logo1.png" class="logo1" /><div class="users">

      <div class="teach">
        <div class="head">
        <h5>A user who will teach <br></br>you the language:</h5>
        </div>
        {Object.entries(DynamicData[0]).map(([key, value]) => (
          <table>
            <tr>
              <><td class="key">{key}</td><td>{value}</td></>
            </tr>
          </table>
        ))}
      </div>
      <div class="teach">
      <div class="head">
        <h5>User you will teach <br></br>him the language:</h5>
        </div>
        {Object.entries(DynamicData[1]).map(([key, value]) => (
          <table>
            <tr>
              <><td class="key">{key}</td><td>{value}</td></>
            </tr>
          </table>
        ))}
      </div>
    </div></>
  );
}
export default Dictionary;