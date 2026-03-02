import { useState } from "react";
import "./CreateAuction.css";
import { useNavigate } from "react-router";
import { CreateAuction as CreateAuctionAPI } from "../../../../services/AuctionService";

const CreateAuction = () => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async () => {
    const userId = Number(localStorage.getItem("userId"));

    if (!userId) {
      setError("Du måste vara inloggad.");
      return;
    }

    if (!title || !price) {
      setError("Du måste ha både en Rubrik och pris");
      return;
    }

    try {
      await CreateAuctionAPI(title, description, Number(price), userId);
      navigate("/auctions");
    } catch {
      setError("Något gick fel, försök igen");
    }
  };

  return (
    <div className="create-page">
      <section>
        <h1>Skapa en auktion</h1>

        {error && <p className="error">{error}</p>}

        <div className="form">
          <label>Rubrik</label>
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />

          <label>Beskrivning</label>
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            maxLength={120}
          ></textarea>

          <label>Utropspris (SEK)</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
          />

          <button onClick={handleSubmit}>Skapa auktionen</button>
          <button className="secondary" onClick={() => navigate("/auctions")}>
            Avbryt
          </button>
        </div>
      </section>
    </div>
  );
};

export default CreateAuction;
