import { useNavigate } from "react-router";
import "./header.css"



const Header = () => {

  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("userId");
    navigate("/");
  }

    return(<>
        <header>
        <h1>TOMB RAIDER</h1>
        <button className="logout-btn" onClick={handleLogout}>Logga ut</button>
      </header>
    </>);

}

export default Header;