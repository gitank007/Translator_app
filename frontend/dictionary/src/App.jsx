import "./App.css";
import React, { useState } from 'react'

function App() {
    const [text, setId] = useState('')
    const [data, setData] = useState(null)

    const handleClick = async () => {
        try {
            const data = await (await fetch(`https://localhost:7297/engTraslation/${text}`,{
              method: 'GET',
              mode:"no-cors",
            headers: {
              Accept: 'application/json',
              Authentication: 'Bearer Token',
              'X-Custom-Header': 'header value'
            }})).json();
            setData(data)
        } catch (err) {
            console.log(err.message)
        }
    }
    function checkResponse(data) {
        if (data) {
            console.log(data)
            return <div className='App'>{data}</div>;
        } else {
            return null;
        }

    }

    return (
        <div>
            <h1> Trasnlater APP</h1>
                <h2> I can Translaet from English to Hungerain , i Know some of the words </h2>
            <input className='usertext' required="required" placeholder='Enter the text' value={text} onChange={e => setId(e.target.value)} />

            <button type="submit" onClick={handleClick} >Tranlate</button>
           <h2> Traslated text is :{checkResponse(data)}</h2> 
        </div>
    )

}

export default App;







