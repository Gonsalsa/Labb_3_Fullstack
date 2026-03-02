export type Auction = {
  auctionId: number;
  title: string;
  price: number;
  endDate: string;
  highestBid: number;
  isActive: boolean;
  ownerId: number;
};

export type Bid =  {
  bidId: number;
  userId: number;
  amount: number;
  createdAt: string;
};

export type AuctionDetails = {
  auctionId: number;
  title: string;
  description: string;
  price: number;
  startDate: string;
  endDate: string;
  isActive: boolean;
  highestBid: number;
  ownerId: number;
  bids: Bid[];
};
