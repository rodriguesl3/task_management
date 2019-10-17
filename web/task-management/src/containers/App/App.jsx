import React from 'react';
import logo from '../../logo.svg';
import './App.css';
import thunk from 'redux-thunk';
import { createStore, applyMiddleware, compose } from 'redux';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import rootReducers from '../../redux-flow/reducers/index';

import MainContainer from '../MainContainer/MainContainer';

const store = createStore(rootReducers,
  compose(applyMiddleware(thunk),
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()));

//const store = createStore(rootReducers, compose(applyMiddleware(thunk)));

const App = () => (
  <Provider store={store}>
    <Router>
      <Switch>
        <div>
          <Route exact path="/" component={MainContainer} />
        </div>
      </Switch>
    </Router>
  </Provider>
)


// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

export default App;
