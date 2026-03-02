import type { Auction } from "../../../../Types/auction";

type AuctionCardProps = {
  auction: Auction;
}

const AuctionCard = ({ auction }: AuctionCardProps) => {
//   const handleClick = () => {
//     alert("Redirect to auction details shall be here");
//   };

  return (
    <div className="auctionStyle">
      <h3>{auction.title}</h3>
      <h4>{auction.highestBid}</h4>
      <p>{auction.endDate}</p>
    </div>
  );
};

export default AuctionCard;