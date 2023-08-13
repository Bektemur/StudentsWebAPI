import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Dashboard from './Dashboard';
import GroupForm from './GroupForm';
import Login from './Login/Login';
import AddSubject from './AddSubject';
import Student from './Student';

function App() {
    return (
        <Router>
            <div className="App">
                <nav>
                    <ul>
                        <li>
                            <Link to="/login">Login</Link>
                        </li>
                       
                    </ul>
                </nav>

                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/student" element = {<Student/>}/>
                    <Route path="/group" element={<GroupForm />} />
                    <Route path="/subject" element={<AddSubject />} />
                </Routes>
                
            </div>
        </Router>
    );
}

export default App;