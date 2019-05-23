import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router'

import App from './app';
import registerServiceWorker from './registerServiceWorker';
import configureStore, { history } from './store/configure.store';

import 'bootstrap/dist/css/bootstrap.css';

const apis = {};

ReactDOM.render(
  <Provider store={configureStore(apis)}> 
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter>
   </Provider>,
  document.getElementById('root')
);

registerServiceWorker();
