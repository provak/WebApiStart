import React, { useState } from "react";

const FormContact = (props) => {
  const [contactName, setContactName] = useState("");
  const [contactEmail, setContactEmail] = useState("");

  const submit = () => {
    if (contactName.trim() !== "" && contactEmail.trim() !== "") {
      props.addContact(contactName, contactEmail);
      setContactName("");
      setContactEmail("");
    }
    else {
      alert("Проверьте корректность данных!\nИмя и email не должны быть пустыми.");
    }
  }

  return (
    <div>
      <div className="mb-3">
        <form>
          <div className="mb-3">
            <label className="form-label">Введите имя:</label>
            <input id="inputName" className="form-control" type="text" value={contactName}
              onChange={(e) => { setContactName(e.target.value) }} />
          </div>
          <div className="mb-3">
            <label className="form-label">Введите e-mail:</label>
            <input className="form-control" type="text" value={contactEmail}
              onChange={(e) => { setContactEmail(e.target.value) }} />
          </div>
        </form>
      </div>
      <div>
        <button className="btn btn-primary"
          onClick={() => { submit() }}>
          Добавить контакт
        </button>
      </div>
    </div>
  );
}

export default FormContact;
