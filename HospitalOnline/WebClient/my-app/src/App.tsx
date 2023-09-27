import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import DoctorList from './pages/Doctor/DoctorList';
import DoctorCreate from './pages/Doctor/DoctorCreate';
import Pagination from './pages/Doctor/Pagination';
import Header from './layout/Header';
import Footer from './layout/Footer';

const App: React.FC = () => {
  return (
    <div>
      <Header />
      <Router>
        <Routes>
        <Route path='/' element={<DoctorList
            id={1}
            firstName="Tran"
            lastName="Loi"
            specialty="Da Lieu"
            phone="0932123587"
          />} />
        <Route
            path="/create"
            element={<DoctorCreate onCreate={() => {}} />}
          />
                  <Route
            path="/paging"
            element={<Pagination/>}
          />
        </Routes>
      </Router>
      <Footer/>
    </div>
  );
};
export default App;

