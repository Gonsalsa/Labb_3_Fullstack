import { useState, useEffect } from "react";
import type { Auction } from "../../../../Types/auction";
import { GetAuctions } from "../../../../services/AuctionService";
import "./AuctionListPage.css";
import Header from "../../../Header/header";
import { useNavigate } from "react-router";

const AuctionListPage = () => {
  const [auctions, setAuctions] = useState<Auction[]>([]);
  const [search, setSearch] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    GetAuctions().then(setAuctions).catch(console.error);
  }, []);

  const filterd =
    search.trim() === ""
      ? auctions
      : auctions.filter((a) =>
          a.title.toLowerCase().includes(search.toLowerCase()),
        );

  return (
    <>
      <Header />
      <section className="AuctionListSection">
        <div>
          <div className="interactives">
            <input
              type="text"
              placeholder="Sök efter en auktion"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
            <button onClick={() => navigate("/auctions/create")}>
              Skapa ny auktion
            </button>
          </div>

          <div className="auction-grid">
            {filterd.map((a) => (
              <div
                key={a.auctionId}
                onClick={() => navigate(`/auctions/${a.auctionId}`)}
                style={{cursor: "pointer"}}
                className="auction-card"
              >
                <h2>{a.title}</h2>
                <h2>{a.highestBid} SEK</h2>
                <h2>
                  Slutar:{" "}
                  {new Date(a.endDate).toLocaleDateString("sv-SE", {
                    year: "numeric",
                    month: "2-digit",
                    day: "2-digit",
                    hour: "2-digit",
                    minute: "2-digit",
                    second: "2-digit",
                  })}
                </h2>
              </div>
            ))}
          </div>
        </div>
      </section>
    </>
  );
};

export default AuctionListPage;
