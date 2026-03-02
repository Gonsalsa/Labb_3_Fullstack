import { useState } from "react";
import "./Login.css";
import { LoginUser } from "../../../services/LoginService";
import { Link, useNavigate } from "react-router";

const Login = () => {
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const navigate = useNavigate();

  const HandleLogin = async () => {
    const resultat = await LoginUser(userName, password);
    console.log(resultat);

    localStorage.setItem("userId", resultat);

    if(resultat > 0)
    {
      navigate("/auctions");
    }

  };

  return (
    <div className="loginPage">
    <section className="LoginCard">
      <h1>TOMB RAIDER</h1>
      <h3>Logga in</h3>
      <div>
        <form action="/login" method="POST">
          <label>Anändarnamn</label>
          <input
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            type="text"
            id="username"
            name="username"
            required
          />

          <label>Lösenord</label>
          <input
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            type="password"
            id="password"
            name="password"
            required
          />
        </form>
        <button onClick={HandleLogin}>Logga in</button>
        <Link id="registerlink" to="/register">Har du inget konto? Tryck här för att registrera dig!</Link>
      </div>
    </section>
    </div>
  );
};

export default Login;
