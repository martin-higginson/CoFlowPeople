import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [people, setPeople] = useState();
    const handelDelete = async (id) => {
        console.log("id : -", id);
        try {
            const response = await fetch("api/people/" + id, {
                method: "DELETE",
            });
            if (!response.ok) {
                throw new Error("Failed to delete item");
            }
            populatePeopleData();
        } catch (error) {
            alert(error.message)
        }
    };

    //Not Fully Implemented
    const handelAdd = async() => {
        try {
            const response = await fetch("api/people", {
                method: "POST",
            });
            if (!response.ok) {
                throw new Error("Failed to create item");
            }
        } catch (error) {
            alert(error.message)
        }
    }

    //Not Fully Implemented
    const handelUpdate = async(id) => {
        try {
            const response = await fetch("api/people/" + id, {
                method: "PUT",
            });
            if (!response.ok) {
                throw new Error("Failed to update item");
            }
            populatePeopleData();
        } catch (error) {
            alert(error.message)
        }

    }

    useEffect(() => {
        populatePeopleData();
    }, []);

    const contents = people === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : 
        <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Date of Birth</th>
                    <th>Age</th>
                    <th>Tools</th>
                    <th><a onClick={() => handelAdd() }>Add</a></th>
                </tr>
            </thead>
            <tbody>
                {people.map(p =>
                    <tr key={p.id}>
                        <td>{p.firstName}</td>
                        <td>{p.lastName}</td>
                        <td>{p.dateOfBirth}</td>
                        <td>{p.age}</td>
                        <td> <a onClick={() => handelDelete(p.id)}>Delete</a> | <a onClick={() => handelUpdate(p.id)}>Update</a></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">People</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populatePeopleData() {
        const response = await fetch('api/people');
        if (response.ok) {
            const data = await response.json();
            setPeople(data);
        }
    }
}

export default App;