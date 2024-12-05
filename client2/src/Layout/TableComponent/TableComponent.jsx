import React from 'react';
import RowTableComponent from './RowTableComponent/RowTableComponent';

const TableComponent = (props) => {
    const contacts = props.Contacts;

    return (
        <table className='table table-hover'>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Полное имя</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                {
                    contacts.map(contact =>
                        <RowTableComponent key={contact.id} Contact={contact}
                            RemoveContact={props.RemoveContact} />
                    )
                }
            </tbody>
        </table>
    );
}

export default TableComponent;