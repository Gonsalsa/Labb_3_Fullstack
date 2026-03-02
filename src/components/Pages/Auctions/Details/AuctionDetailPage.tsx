import { useNavigate, useParams } from "react-router";
import type { AuctionDetails } from "../../../../Types/auction";
import { useEffect, useState } from "react";
import {
  GetAuctionDetails,
  PlaceBid,
} from "../../../../services/AuctionService";
import "./AuctionDetailPage.css";
import Header from "../../../Header/header";

const AuctionDetailPage = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const userId = Number(localStorage.getItem("userId"));

  const [auction, setAuction] = useState<AuctionDetails | null>(null);
  const [bidAmount, setBidAmount] = useState("");
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const [loading, setLoading] = useState(true);

  const fetchAuction = () => {
    if (!id) {
      return;
    }
    GetAuctionDetails(Number(id))
      .then(setAuction)
      .catch(() => setError("Kunde inte ladda auktionen"))
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    fetchAuction();
  }, [id]);

  const handleBid = async () => {
    setError("");
    setSuccess("");
    const amount = Number(bidAmount);
    if (!amount || amount <= 0) {
      setError("Ange ett giltigt belopp på budet");
      return;
    }

    if (auction && amount <= auction.highestBid) {
      setError(
        `Budet måste vara högre än det nuvarande högsta budet (${auction.highestBid} SEK)`,
      );
      return;
    }
    try {
      await PlaceBid(Number(id), amount, userId);
      setSuccess("Budet är nu lagt!");
      setBidAmount("");
      fetchAuction();
    } catch {
      setError("Något gick fel, vänligen försök igen");
    }
  };

  if (loading) {
    return <p className="loading">Laddar auktion...</p>;
  }
  if (!auction) {
    return <p className="loading"> Auktionen hittades inte</p>;
  }

  const isOwner = auction?.ownerId == userId;
  const endDate = new Date(auction?.endDate).toLocaleDateString("sv-SE", {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
  });

  return (
    <>
      <Header />
      <div className="detail-page">
        <div className="detail-card">
          <button className="back-btn" onClick={() => navigate("/auctions")}>
            Tillbaka
          </button>

          <h2 className="detail-title">{auction?.title}</h2>
          <p className="detail-description">{auction?.description}</p>

          <div className="detail-meta">
            <div className="meta-item">
              <span className="meta-lable">Högsta bud</span>
              <span className="meta-value highlight">
                {auction?.highestBid} SEK
              </span>
            </div>
            <div className="meta-item">
              <span className="meta-lable">Slutar</span>
              <span className="meta-value">{endDate}</span>
            </div>
            <div className="meta-item">
              <span className="meta-lable">Status</span>
              <span
                className={`status-badge ${auction?.isActive ? "active" : "ended"}`}
              >
                {auction?.isActive ? "Aktiv" : "Avslutad"}
              </span>
            </div>
          </div>

          {!isOwner && auction?.isActive && (
            <div className="bid-section">
              <h3>Lägg ett bud</h3>
              {error && <p className="error">{error}</p>}
              {success && <p className="success-msg">{success}</p>}
              <div className="bid-input-row">
                <input
                  type="number"
                  placeholder={`Måste vara mer än ${auction.highestBid} SEK`}
                  value={bidAmount}
                  onChange={(e) => setBidAmount(e.target.value)}
                />
                <button onClick={handleBid}>Buda</button>
              </div>
            </div>
          )}
          {isOwner && (
            <p className="owner-notice">
              {" "}
              Du äger denna produkten och kan därför inte lägga ett bud
            </p>
          )}
        </div>

        <div className="bid-history-card">
          <h3>Budhistorik ({auction?.bids.length} bud)</h3>
          {auction?.bids.length === 0 ? (
            <p className="no-bids">Inget bud än, bli den första!</p>
          ) : (
            <ul className="bid-list">
              {auction?.bids.map((bid, index) => (
                <li
                  key={bid.bidId}
                  className={`bid-item ${index === 0 ? "top-bid" : ""}`}
                >
                  <span className="bid-amount">{bid.amount} SEK</span>
                  <span className="bid-meta">
                    Användare #{bid.userId}.{" "}
                    {new Date(bid.createdAt).toLocaleDateString("sv-SE", {
                      month: "2-digit",
                      day: "2-digit",
                      hour: "2-digit",
                      minute: "2-digit",
                    })}
                  </span>
                  {index === 0 && <span className="highest-badge">Högst</span>}
                </li>
              ))}
            </ul>
          )}
        </div>
      </div>
    </>
  );
};
export default AuctionDetailPage;
