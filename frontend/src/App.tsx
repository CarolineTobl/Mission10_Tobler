import React from 'react';
import './App.css';
import BowlerList from './BowlerList/BowlerList';

function Header() {
  return (
    <header className="App-header">
      <h1 className="App-title">Pin Prospects</h1>
      <h6>Find Information on all your favorite bowlers.</h6>
    </header>
  );
}

function Footer() {
  return (
    <footer className="App-footer">
      <p>Thank you for viewing my website. I appreciate you coming here.</p>
    </footer>
  );
}

function Content() {
  return <p>This is where I will display the bowlers.</p>;
}

function App() {
  return (
    <div className="App">
      <Header />
      <main className="App-content">
        <BowlerList />
      </main>
      <Footer />
    </div>
  );
}

export default App;
