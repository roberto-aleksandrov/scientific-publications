import React from 'react';
import { Route, Redirect, Switch } from 'react-router-dom';
import routesConfig from './routes-config';

const Routes = () => (
  <Switch>
    <Route 
      exact
      path={routesConfig.registerAuthor.path}
      component={routesConfig.registerAuthor.component} 
    />
    <Redirect to="/" />
  </Switch>
);

export default Routes;
