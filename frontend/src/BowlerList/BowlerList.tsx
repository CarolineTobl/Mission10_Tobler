import React, { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBowlerData = async () => {
      try {
        const rsp = await fetch('http://localhost:5129/bowlers');
        if (!rsp.ok) {
          throw new Error(`HTTP error! status: ${rsp.status}`);
        }
        let data = await rsp.json();
        data = data.filter(
          (bowler: Bowler) =>
            bowler.teamName === 'Marlins' || bowler.teamName === 'Sharks',
        );
        setBowlerData(data); // Directly set the data as it's already an array
      } catch (error) {
        console.error('Fetch error: ', error);
        setError('Failed to load data'); // Set error state
      }
    };
    fetchBowlerData();
  }, []);

  if (error) {
    return <div>Error: {error}</div>; // Render error state
  }

  return (
    <div className="container">
      <div className="row">
        <div className="col-12">
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Name</th>
                <th>Team Name</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone Number</th>
              </tr>
            </thead>
            <tbody>
              {bowlerData.map((f) => (
                <tr key={f.bowlerId}>
                  <td>
                    {f.bowlerFirstName}{' '}
                    {f.bowlerMiddleInit ? f.bowlerMiddleInit : ''}{' '}
                    {f.bowlerLastName}
                  </td>
                  <td>{f.teamName}</td>
                  <td>{f.bowlerAddress}</td>
                  <td>{f.bowlerCity}</td>
                  <td>{f.bowlerState}</td>
                  <td>{f.bowlerZip}</td>
                  <td>{f.bowlerPhoneNumber}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default BowlerList;
