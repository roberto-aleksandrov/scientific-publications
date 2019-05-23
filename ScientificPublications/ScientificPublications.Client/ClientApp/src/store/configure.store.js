import { createStore, applyMiddleware } from 'redux';
import { createBrowserHistory } from 'history'
import { routerMiddleware } from 'connected-react-router'
import { createEpicMiddleware } from 'redux-observable';
import {composeWithDevTools} from 'redux-devtools-extension'

// import rootEpic from '../epics/rootEpic';
import rootReducer from '../reducers/root.reducer';

const epicMiddleware = createEpicMiddleware();

export const history = createBrowserHistory();

const configureStore = (apis) => {
  const store = createStore(
    rootReducer(history),
    composeWithDevTools(
        applyMiddleware(
            // epicMiddleware,
            routerMiddleware(history)
        )
    )
  );

//   epicMiddleware.run(rootEpic(apis));

  return store;
}

export default configureStore;