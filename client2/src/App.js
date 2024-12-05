import TableComponent from "./Layout/TableComponent/TableComponent";
import axios from 'axios'
import React, { useState, useEffect } from "react";
import FormContact from "./Layout/FormContact/FormContact";

const apiUrl = process.env.REACT_APP_API_URL;

const App = () => {

  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    axios.get(apiUrl).then(res => {
      const data = res.data;
      setContacts(data);
    })
  }, []);

  const addContact = (contactName, contactEmail) => {
    const item = {
      name: contactName,
      email: contactEmail
    };

    axios.post(apiUrl, item)
      .then(response => {
        console.log(response.data);
        setContacts([...contacts, response.data]);
      });
  }

  const removeContact = (id) => {
    const url = `${apiUrl}/${id}`;
    axios.delete(url);
    setContacts(contacts.filter(c => c.id !== id));
  };

  return (
    <div className="container">
      <div className="mt-5 card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableComponent Contacts={contacts} RemoveContact={removeContact} />
          <FormContact Add={addContact} />
        </div>
      </div>
    </div>
  );
}

export default App;
