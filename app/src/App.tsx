import { Route, BrowserRouter as Router, Routes } from 'react-router-dom'
import './App.css'
import NavBar from './Components/NavBar';
import AllBoards from './pages/AllBoards';
import Board from './pages/Board';
import Home from './pages/Home';
import NotFound from './pages/NotFound';

function App() {
  return (
    <div className='App'>
      <Router>
        <NavBar />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/boards" element={<AllBoards />} />
            <Route path="/boards/:id" element={<Board />} />
            <Route path="*" element={<NotFound />} />
          </Routes>
      </Router>
    </div>
  );
}

export default App
