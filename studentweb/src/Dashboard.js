﻿import React from 'react';
import { Link } from 'react-router-dom';

function Dashboard() {
    return (
        <div>
            <h2>Dashboard Page</h2>
            <Link to="/group">Группы</Link>
            {}
        </div>
    );
}

export default Dashboard;