import React, { useEffect, useState } from 'react';
import axios from 'axios';
import CategoryList from "../Components/CategoryList.jsx";

const Home = () => {
    const [categories, setCategories] = useState([]);

    //завантажує список категорій
    useEffect(() => {
        axios.get('/api/categories')
            .then(response => setCategories(response.data))
            .catch(err => console.error('Помилка при завантаженні категорій:', err));
    }, []);

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/api/categories/${id}`); //запит на видалення
            setCategories(prev => prev.filter(c => c.id !== id)); //оновлення списку
        } catch (err) {
            console.error('Помилка при видаленні категорії:', err);
        }
    };

    return (
        <CategoryList categories={categories} onDelete={handleDelete}></CategoryList>
    );
};

export default Home;