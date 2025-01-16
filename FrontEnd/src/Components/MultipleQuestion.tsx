import { Checkbox, FormControlLabel, FormGroup } from "@mui/material"

interface MultipleQuestionProps{
    question : string
    answers : string[]
}
function MultipleQuestion({question, answers} : MultipleQuestionProps) {
  return (
    <>
    <h3>{question}</h3>
    <FormGroup>
        {answers.map((answer, index)=> ( <FormControlLabel value={index} control={<Checkbox />} label={answer} />))}
    </FormGroup>
    </>
  )
}

export default MultipleQuestion
