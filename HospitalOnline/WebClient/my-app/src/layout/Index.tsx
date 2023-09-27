import React from 'react';
import Header from './Header';
import Footer from '../layout/Footer';
import Nav from '../layout/Nav';

const App: React.FC = () => {
  return (
    <div>
      <Header />
      <Nav />

      <main>
        Hello
      </main>

      <Footer />
    </div>
  );
};

export default App;
