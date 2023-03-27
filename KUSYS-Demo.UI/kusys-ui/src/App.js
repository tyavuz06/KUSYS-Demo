import { Component } from 'react';
import './App.css';
import AddStudent from './components/AddStudent';
import Navbar from './components/Navbar';
import { StudentList } from './components/StudentList';

class App extends Component {
  render(){
    return (
      <div className="App">
        {/* <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>
            Edit <code>src/App.js</code> and save to reload.
          </p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
          </a>
        </header> */}
        <Navbar title="KUSYS-DEMO" />
        <hr/>
        <AddStudent/>
        <StudentList/>
      </div>
    );
  }  
}

export default App;
