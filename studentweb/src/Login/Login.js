import React, { useState } from 'react';
import axios from 'axios';
import queryString from 'query-string';
import { useNavigate } from 'react-router-dom';

function Login() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
    const handleLogin = async (event) => {
        try {
            event.preventDefault();

            const url = 'http://localhost/login';
            const queryParams = queryString.stringify({
                Username: username,
                Password: password,
            });
            const response = await axios.post(`${url}?${queryParams}`);
            const jwtToken = response.data;
            localStorage.setItem('token', jwtToken);
            setIsAuthenticated(true);

        }
        catch (error) {
            console.error('������ �����������:', error);
        }
        if (isAuthenticated) {
            console.log(localStorage.getItem('token'));
            navigate('/Dashboard');
        }

    };

    return (
        <div>
            <h2>Login Page</h2>
            <input
                type="text"
                placeholder="Username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
            />
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button onClick={handleLogin}>Login</button>
        </div>
    );
}

export default Login;
