import { useEffect, useState } from "react";
import "./../App.css";

function ShowData() {
  const [data, setData] = useState([]);

  const fetchData = () => {
    fetch(`https://localhost:7297/Traslation`)
      .then((response) => response.json())
      .then((actualData) => {
        
        setData(actualData.responseData);
        
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    
    <div className="App">
      
      <table>
        <tbody>
        <tr>
          <th>Id</th>
          <th>English</th>
          <th>Hungerian</th>
        </tr>
        {data.map((item, index) => (
          <tr key={index}>
            <td>{item.id}</td>
            <td>{item.sourceEng}</td>
            <td>{item.targetlanguage}</td>
            
          </tr>
        ))}
      </tbody>
      </table>
    </div>
  );
}

export default ShowData;