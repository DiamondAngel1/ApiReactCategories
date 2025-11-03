import React, {useState} from 'react';
import axios from 'axios';
import {useNavigate} from 'react-router-dom';

const AddCategoryForm = () => {
    const [name, setName] = useState('');
    const [image, setImage] = useState(null);
    const navigate = useNavigate();

    const handleBack = () => {
        navigate('/');
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        //додаються данні з форми
        formData.append('Name', name);
        formData.append('Image', image);

        try {
            await axios.post('/api/categories', formData); //надсилає на сервер данні з форми
            navigate('/'); //перенаправляє на головну
        } catch (err) {
            console.error('Помилка при додаванні категорії:', err);
        }
    };

    return (
        <>
            <button onClick={handleBack} className={'btn btn-success'}>Назад</button>
            <form onSubmit={handleSubmit} className={"col-md-6 offset-md-3"}>
                <h2>Додати категорію</h2>
                <div>
                    <label className={'form-label'}>Назва:</label>
                    <input
                        type="text"
                        className={'form-control'}
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                </div>
                <div className={'mb-3'}>
                    <label className={'form-label'}>Зображення:</label>
                    <input
                        type="file"
                        className={'form-control'}
                        onChange={(e) => setImage(e.target.files[0])}
                        accept="image/*"
                        required
                    />
                </div>
                <button type="submit" className={'btn btn-primary'}>Додати</button>
            </form>
        </>
    );
};

export default AddCategoryForm;
