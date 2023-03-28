import { Component } from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { StudentList } from './components/StudentList';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import StudentCourseMatchedList from './components/StudentCourseMatchedList';
import AddStudent from './components/AddStudent';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="App">
          <Navbar title="KUSYS-DEMO" />
          <hr />
          <Routes>
            <Route path='/' Component={StudentList} />
            <Route path='/matchList' Component={StudentCourseMatchedList} />
            <Route path='/test' Component={AddStudent} />
          </Routes>
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
