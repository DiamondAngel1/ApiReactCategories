import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
    plugins: [react()],
    server:{
        port: 5062, //порт для локал хосту

        //налаштовується проксі щоб не прописувати
        // "https://localhost:5065" завжди при запиті на /api
        proxy: {
            '/api': {
                target: 'https://localhost:5065', //порт на якому працює серверна частина
                changeOrigin: true,
                secure: false //вирішує проблеми CORS
            }
        }
    }
})