import React, { useState } from 'react';
import axios from 'axios';
function GroupForm() {
    const [name, setGroupName] = useState('');
    const handleGroupNameChange = (event) => {
        setGroupName(event.target.value);
    };

    

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const token = localStorage.getItem('token');
            const response = await axios.post(
                'http://localhost/Groups/add',
                {
                    name,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );

            console.log('Group added:', response.data);
        } catch (error) {
            console.error('Error adding group:', error);
        }
    };

return (
        <div>
            <h2>Create Group</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Group Name:</label>
                    <input
                        type="text"
                        value={name}
                        onChange={handleGroupNameChange}
                    />
                </div>
                <button type="submit">Добавить</button>
            </form>
        </div>
);
}
export default GroupForm;