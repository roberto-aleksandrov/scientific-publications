import React, { Component } from 'react';

import Routes from './routes';
import Navigation from './features/navigation';

export default class App extends Component { 
  render() {
    return (
      <div className="App">
        <Navigation />
        <div className="content">
          <Routes />
        </div>
      </div>
    );
  }
}
