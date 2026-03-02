import "./Register.css";
import React, { useState } from "react";
import { RegisterService } from "../../../services/RegisterService";
import { useNavigate } from "react-router";

const Register = () => {
  const [userName, setUserName] = useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const [message, setMessage] = useState<string | null>(null);
  const [isError, setIsError] = useState(false);

  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      await RegisterService(userName, email, password);
      setIsError(false);
      setMessage("Reggistrering lyckades!");

      setTimeout(() => {
        navigate("/");
      }, 1500);
    } catch (err: any) {
      setIsError(true);
      setMessage("Registrering misslyckades: " + err.message);
    }
  };

  return (
    <div className="register-page">
    <section>
      <h1>TOMB RAIDER</h1>

      <h3>Registrera dig</h3>
      <form onSubmit={handleSubmit}>
        <label htmlFor="username">Användarnamn*</label>
        <input
          type="text"
          value={userName}
          onChange={(e) => setUserName(e.target.value)}
          id="username"
          name="username"
          required
        />

        <label htmlFor="useremail">Email*</label>
        <input
          type="text"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          id="useremail"
          name="useremail"
          required
        />

        <label htmlFor="userpassword">Lösenord*</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          id="userpassword"
          name="userpassword"
          required
        />

        <p>* Dessa fält måste fyllas i</p>

        <button type="submit">Registrera dig</button>
      </form>

      <button onClick={() => navigate("/")}>Tillbaka</button>

      {message && (
        <div className={`popup ${isError ? "popup-error" : "popup-success"}`}>
          {message}
        </div>
      )}
    </section>
    </div>
  );
};

export default Register;
