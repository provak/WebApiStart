import React from 'react';
import RowTableContact from './Components/RowTableContact';

const TableContact = (props) => {
  const contacts = props.contacts;

  return (
    <table className="table table-hover">
      <thead>
        <tr>
          <th>#</th>
          <th>Имя контакта</th>
          <th>Email</th>
          <tr></tr>
        </tr>
      </thead>
      <tbody>
        {
          contacts.map(contact =>
            <RowTableContact
              key={contact.id}
              id={contact.id}
              name={contact.name}
              email={contact.email} />
          )
        }
      </tbody>
    </table>
  );
}

export default TableContact;
