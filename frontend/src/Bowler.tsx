import { useEffect, useState } from 'react';
import { BowlerTeam } from './types/BowlerTeam';
function Bowler() {
  const [bowlerdata, setbowlerdata] = useState<BowlerTeam[]>([]);

  useEffect(() => {
    const fetchbowlerdata = async () => {
      const rsp = await fetch('http://localhost:5279/bowler');
      const b = await rsp.json();
      setbowlerdata(b);
    };
    fetchbowlerdata();
  }, []);

  return (
    <div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>BowlerName</th>
            <th>TeamName</th>
            <th>BowlerAddress</th>
            <th>BowlerCity</th>
            <th>BowlerState</th>
            <th>BowlerZip</th>
            <th>BowlerPhoneNumber</th>
          </tr>
        </thead>
        <tbody>
          {bowlerdata.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
              </td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Bowler;
