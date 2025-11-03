import React from 'react';
import {Link} from 'react-router-dom';

const CategoryList = ({categories, onDelete}) => {
    return (
        <div className={"container"}>
            <h2>Категорії</h2>
            <Link to="/add" className="btn btn-success">Додати категорію</Link>
            <table className={'table table-bordered text-center mt-3'}>
                <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Фото</th>
                    <th scope="col">Назва</th>
                    <th scope="col">Дії</th>
                </tr>
                </thead>
                <tbody>
                {categories.map(category => (
                    <tr key={category.id}>
                        <th>{category.id}</th>
                        <td>
                            <img
                                //тут проксі не працює бо зображення це статичні файли а не /api/...
                                src={`https://localhost:5065${category.image}`}
                                alt={category.name}
                                width="100"
                            />
                        </td>
                        <td>{category.name}</td>
                        <td>
                            <button className={"btn btn-danger"} onClick={() => onDelete(category.id)}>Видалити</button>
                        </td>
                    </tr>

                ))}

                </tbody>

            </table>
        </div>
    );
};

export default CategoryList;