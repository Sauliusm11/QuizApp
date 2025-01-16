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


type Question = {
id: number;
type: number;
question: string;
correctAnswer: string;
answers: string[];
};
function QuizPage() {
  const [questions, setQuestions] = useState<Question[]>([]);
  const [activeStep, setActiveStep] = useState(0);
  const [completed, setCompleted] = useState<{
    [k: number]: boolean;
  }>({});

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
          questions.findIndex((questions, i) => !(i in completed))
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
    handleNext();
  };
  const handleSubmit = () =>{
    //Submition api call here
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
      <h1>Navigation buttons here</h1>
      <div className="card">
        <Stepper nonLinear activeStep={activeStep}>
        {questions.map((question, index) => (
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
            <Typography sx={{ mt: 2, mb: 1 }}>
            This is where email submition will be
          </Typography><Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
              <Box sx={{ flex: '1 1 auto' }} />
              <Button onClick={handleSubmit}>Submit</Button>
            </Box>
            </>

        ) : (
          <>
            <Typography sx={{ mt: 2, mb: 1, py: 1 }}>
              Question {activeStep + 1}
            </Typography>
            {questions[activeStep].type === 0 ?(<SimpleQuestion question={questions[activeStep].question} answers={questions[activeStep].answers}></SimpleQuestion>) 
            :(
              <>
              {questions[activeStep].type === 1 ? (<MultipleQuestion question={questions[activeStep].question} answers={questions[activeStep].answers}></MultipleQuestion>) 
              : (
              <TextQuestion question={questions[activeStep].question}></TextQuestion>)}
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
                  <Button onClick={handleComplete}>
                    {completedSteps() === totalSteps() - 1
                      ? 'Finish'
                      : 'Resubmit answer'}
                  </Button>
                ) : (
                  <Button onClick={handleComplete}>
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
