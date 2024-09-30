import React from 'react';
import NewsList from './components/NewsList';

function App() {
  return (
    <div className="App">
      <header>
        <h1>News App</h1>
      </header>
      <main>
        <NewsList />
      </main>
    </div>
  );
}

export default App;
