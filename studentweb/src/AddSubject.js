import React, { useState } from 'react';

function AddSubject() {
    const [subjectName, setSubjectName] = useState('');
    const token = localStorage.getItem("token");
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            const response = await fetch('http://localhost/Subject/add', {
                method: 'POST',
                headers: {
                    Authorization: `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ name: subjectName })
            });

            if (!response.ok) {
                throw new Error('Ошибка сети или сервера');
            }

            const data = await response.json();
            console.log(data);
            setSubjectName('');
        } catch (error) {
            console.error("Произошла ошибка при добавлении предмета:", error);
        }
    };

    return (
        <div>
            <h2>Добавить предмет</h2>
            <form onSubmit={handleSubmit}>
                <input
                    value={subjectName}
                    onChange={e => setSubjectName(e.target.value)}
                    placeholder="Название предмета"
                    required
                />
                <button type="submit">Добавить</button>
            </form>
        </div>
    );
}

export default AddSubject;