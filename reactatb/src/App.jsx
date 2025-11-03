import React from 'react';
import { Routes, Route} from 'react-router-dom';
import Home from './pages/Home.jsx';
import AddCategoryPage from "./pages/AddCategoryPage.jsx";


function App() {
    return (
        <>
            <header className={'text-center d-flex justify-content-between m-4 text-center'}>
                <h1>АТБ Магазин</h1>
            </header>
            <main>
                <div className={'container'}>
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/add" element={<AddCategoryPage />} />
                    </Routes>
                </div>
            </main>
        </>
    );
}

export default App;
