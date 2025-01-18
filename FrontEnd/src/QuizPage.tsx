import { useEffect, useState } from 'react'
import './QuizPage.css'
import axios from 'axios';
import SimpleQuestion from './Components/SimpleQuestion';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepButton from '@mui/material/StepButton';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import MultipleQuestion from './Components/MultipleQuestion';
import TextQuestion from './Components/TextQuestion';
import FormGroup from '@mui/material/FormGroup';
import TextField from '@mui/material/TextField';
import { useNavigate } from 'react-router';


type Question = {
id: number;
type: number;
question: string;
correctAnswer: string;
answers: string[];
};
function QuizPage() {
  const [email, setEmail] = useState("");
  const [questions, setQuestions] = useState<Question[]>([]);
  const [activeStep, setActiveStep] = useState(0);
  const [answer, setAnswer] = useState("");
  const [answers, setAnswers] = useState<{
    [k: number]: string;
  }>({});
  const [completed, setCompleted] = useState<{
    [k: number]: boolean;
  }>({});
  const navigate = useNavigate();

  const handleCallback = (childData : string) =>{
    // console.log(childData)
    setAnswer(childData)
  }

  const totalSteps = () => {
    return questions.length;
  };

  const completedSteps = () => {
    return Object.keys(completed).length;
  };

  const isLastStep = () => {
    return activeStep === totalSteps() - 1;
  };

  const allStepsCompleted = () => {
    return completedSteps() === totalSteps();
  };

  const handleNext = () => {
    const newActiveStep =
      isLastStep() && !allStepsCompleted()
        ? // It's the last step, but not all steps have been completed,
          // find the first step that has not been completed
          questions.findIndex((_, i) => !(i in completed))
        : activeStep + 1;
    setActiveStep(newActiveStep);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleStep = (step: number) => () => {
    setActiveStep(step);
  };

  const handleComplete = () => {
    setCompleted({
      ...completed,
      [activeStep]: true,
    });
    setAnswers({
      ...answers,
      [activeStep]: answer,
    })
    handleNext();
  };
  const handleSubmit = () =>{
    //Could not figure out how to pass the built in validation to here so I used the closest thing I found https://stackoverflow.com/a/7786283
    let emailRegEx : RegExp = new RegExp("[a-z0-9!#$%&'*+/=?^_`{|}~.-]+@[a-z0-9-]+(\.[a-z0-9-]+)*")
    if(emailRegEx.test(email)){
      console.log(answers)
      axios.post(`${import.meta.env.VITE_REACT_APP_BASE_URL}/quizSubmit`,{
        answers: Object.entries(answers).map(([_, value]) => value),
        email: email
      })
    .then(function (response) {
        console.log(response.data)
        navigate("/high-scores")
    })
    .catch(function (error) {
        console.log(error)
    });
    }
  }
  function GetQuizQuestions(){
    axios({
        method: 'get',
        url: `${import.meta.env.VITE_REACT_APP_BASE_URL}/quizQuestions`,
        responseType: 'json'
    })
    .then(function (response) {
        // const data: Question[] = response.data;
        setQuestions(response.data)
    })
    .catch(function (error) {
        console.log(error)
    });
}
  useEffect(() => {
   GetQuizQuestions()
 }, []);
  return (
    <>
      <div className="card">
        <Stepper nonLinear activeStep={activeStep}>
        {questions.map((_, index) => (
          <Step key={index} completed={completed[index]}>
            <StepButton color="inherit" onClick={handleStep(index)}>
              {"Question"+(index+1)}
            </StepButton>
          </Step>
        ))}
      </Stepper>
      </div>
      <div>
        {allStepsCompleted() ? (
            <>
          <FormGroup onSubmit={handleSubmit}>
              Enter your email
              <TextField id="outlined-basic" autoFocus required label="Email" type="email" variant="outlined" onChange={e => setEmail(e.target.value)}/>
              <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
              <Box sx={{ flex: '1 1 auto' }} />
              <Button onClick={handleSubmit}>Submit</Button>
            </Box>
          </FormGroup>
            </>

        ) : (
          <>
                {activeStep !== questions.length &&
                (completed[activeStep] ? (
                  <p>Submited answer: { questions[activeStep].type !== 2 ? (questions[activeStep].answers.filter((_,index)=>answers[activeStep].split(",").map(Number).includes(index)).map((answer) => (
                    <p>{answer}</p>
                  ))):(<p>{answers[activeStep]}</p>)}</p>
                ) : (
                  <p>Unanswered question</p>
                ))}
            <Typography sx={{ mt: 2, mb: 1, py: 1 }}>
              Question {activeStep + 1}
            </Typography>
            {questions[activeStep].type === 0 ?(<SimpleQuestion question={questions[activeStep].question} answers={questions[activeStep].answers} parentCallback ={handleCallback} key={activeStep}></SimpleQuestion>) 
            : (
              <>
              {questions[activeStep].type === 1 ? (<MultipleQuestion question={questions[activeStep].question} answers={questions[activeStep].answers} parentCallback={handleCallback} key={activeStep}></MultipleQuestion>) 
              : (
              <TextQuestion question={questions[activeStep].question} parentCallback={handleCallback} key={activeStep}></TextQuestion>)}
              </>)  
            }
            <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
              <Button
                color="inherit"
                disabled={activeStep === 0}
                onClick={handleBack}
                sx={{ mr: 1 }}
              >
                Back
              </Button>
              <Box sx={{ flex: '1 1 auto' }} />
              <Button onClick={handleNext} sx={{ mr: 1 }}>
                Next
              </Button>
              {activeStep !== questions.length &&
                (completed[activeStep] ? (
                  // https://stackoverflow.com/questions/70886553/submitting-form-from-parent-component
                  <Button onClick={handleComplete} disabled={(answer === ""?true:false)}>
                    Resubmit answer
                  </Button>
                ) : (
                  <Button onClick={handleComplete} disabled={(answer === ""?true:false)}>
                    {completedSteps() === totalSteps() - 1
                      ? 'Finish'
                      : 'Submit answer'}
                  </Button>
                ))}
            </Box>
          </>
        )}
      </div>
    </>
  )
}

export default QuizPage
