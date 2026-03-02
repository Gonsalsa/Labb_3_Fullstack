import { Route, Routes } from "react-router";
import Register from "./components/Pages/Register/Register";
import Login from "./components/Pages/Login/Login";
import AuctionListPage from "./components/Pages/Auctions/Auctions/AuctionListPage";
import CreateAuction from "./components/Pages/Auctions/Create/CreateAuction";
import AuctionDetailPage from "./components/Pages/Auctions/Details/AuctionDetailPage";
import "./index.css"
function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Login />}></Route>
        <Route path="/register" element={<Register />}></Route>
        <Route path="/auctions" element={<AuctionListPage />}></Route>
        <Route path="/auctions/create" element={<CreateAuction />}></Route>
        <Route path="/auctions/:id" element={<AuctionDetailPage />}></Route>
      </Routes>
    </>
  );
}

export default App;
