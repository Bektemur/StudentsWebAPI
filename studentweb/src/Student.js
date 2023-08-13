import React, { useState, useEffect } from 'react';

function AddStudent() {
    const [groups, setGroups] = useState([]);
    const token = localStorage.getItem("token");
    const [selectedGroup, setSelectedGroup] = useState('');
    const [student, setStudent] = useState({
        firstName: '',
        lastName: '',
        email: ''
    });

    useEffect(() => {
        fetchGroups();
    }, []);

    const fetchGroups = async () => {
        try {
          
            const response = await fetch('http://localhost/Groups/all', {
                headers: {
                    'Authorization': `Bearer ${token}`,  
                    'Content-Type': 'application/json'
                }
            });
    
            if (!response.ok) {
                throw new Error('Ошибка сети или сервера');
            }
    
            const data = await response.json();
            setGroups(data);
        } catch (error) {
            console.error("Произошла ошибка при получении групп:", error);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        
        fetch('http://localhost/Students/add', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,  
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ...student,
                GroupId: selectedGroup
            })
        })
        .then(response => response.json())
        .then(data => {
            console.log(data);
        });
    };

    return (
        <div>
            <h2>Добавить студента</h2>
            <form onSubmit={handleSubmit}>
                <input
                    value={student.firstName}
                    onChange={e => setStudent({ ...student, firstName: e.target.value })}
                    placeholder="Имя"
                    required
                />
                <input
                    value={student.lastName}
                    onChange={e => setStudent({ ...student, lastName: e.target.value })}
                    placeholder="Фамилия"
                    required
                />
                <input
                    value={student.email}
                    onChange={e => setStudent({ ...student, email: e.target.value })}
                    placeholder="Email"
                    required
                />
                <select value={selectedGroup} onChange={e => setSelectedGroup(e.target.value)}>
                    {groups.map(GroupId => (
                        <option key={GroupId.id} value={GroupId.id}>
                            {GroupId.name}
                        </option>
                    ))}
                </select>
                <button type="submit">Добавить</button>
            </form>
        </div>
    );
}

export default AddStudent;
