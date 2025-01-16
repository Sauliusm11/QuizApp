import { useEffect, useState } from 'react'
import './QuizPage.css'
import axios from 'axios';

function GetQuizQuestions(){
    axios({
        method: 'get',
        url: `${import.meta.env.VITE_REACT_APP_BASE_URL}/quizQuestions`,
        responseType: 'json'
    })
    .then(function (response) {
        console.log(response)
    })
    .catch(function (error) {
        console.log(error)
    });
}

function QuizPage() {
  const [count, setCount] = useState(0)
  useEffect(() => {
   GetQuizQuestions()
 }, []);
  return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
        </a>
        <a href="https://react.dev" target="_blank">
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          This is the quiz page
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default QuizPage
