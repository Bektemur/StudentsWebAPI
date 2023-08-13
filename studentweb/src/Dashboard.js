import React from 'react';
import { Link } from 'react-router-dom';

function Dashboard() {
    return (
        <div>
            <h2>Главная страница</h2>
            <Link to="/group">Группы</Link>
            <br/>
            <Link to="/subject">Предмет</Link>
            <br/>
            <Link to="/student">Студенты</Link>
        </div>
    );
}

export default Dashboard;