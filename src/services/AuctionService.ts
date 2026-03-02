import type { Auction, AuctionDetails } from "../Types/auction";

const Base_URL = "http://localhost:5019/api";

export const GetAuctions = async (): Promise<Auction[]> => {
  const res = await fetch(`${Base_URL}/auction`);
  if (!res.ok) {
    throw new Error("Kunde inte hämta auktionerna");
  }

  return await res.json();
};

export const GetAuctionDetails = async (
  id: number,
): Promise<AuctionDetails> => {
  const res = await fetch(`${Base_URL}/auction/${id}`);
  if (!res.ok) {
    throw new Error("Kunde inte hämta auktionen");
  }
  return await res.json();
};

export const CreateAuction = async (
  title: string,
  description: string,
  price: number,
  ownerId: number,
): Promise<void> => {
  const res = await fetch(`${Base_URL}/auction`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ title, description, price, ownerId }),
  });
  if (!res.ok) {
    throw new Error("Kunde inte skapa auktionen");
  }
};

export const PlaceBid = async (
  auctionId: number,
  amount: number,
  userId: number,
): Promise<void> => {
  const res = await fetch(`${Base_URL}/bid?auctionId=${auctionId}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ UserId: userId, Amount: amount }),
  });
  if (!res.ok) {
    throw new Error("Kunde inte lägga budet");
  }
};
