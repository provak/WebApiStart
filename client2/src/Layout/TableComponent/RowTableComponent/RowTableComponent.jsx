import React from 'react';

const RowTableComponent = (props) => {
    const contact = props.Contact;
    const remove = props.RemoveContact;

    return (
        <tr onClick={() => remove(contact.id)}>
            <td>{contact.id}</td>
            <td>{contact.name}</td>
            <td>{contact.email}</td>
        </tr>
    );
}

export default RowTableComponent;