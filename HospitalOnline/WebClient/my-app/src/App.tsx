import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import DoctorList from './pages/Doctor/DoctorList';
import DoctorCreate from './pages/Doctor/DoctorCreate';

function App() {
  return (
    <div className="App">
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
        </Routes>
      </Router>
    </div>
  );
}

export default App;

