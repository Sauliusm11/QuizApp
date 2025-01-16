import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import ScorePage from './ScorePage.tsx'
import { BrowserRouter, Routes, Route } from "react-router";
import QuizPage from './QuizPage.tsx';

createRoot(document.getElementById('root')!).render(
  <BrowserRouter>
  <StrictMode>
    <Routes>
      <Route path="quiz" element={<QuizPage />} />
      <Route path="high-scores" element={<ScorePage />} />
    </Routes>
  </StrictMode>
  </BrowserRouter>,
)
