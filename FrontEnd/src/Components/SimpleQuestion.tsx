import { FormControlLabel, Radio, RadioGroup } from "@mui/material"

interface SimpleQuestionProps{
    question : string
    answers : string[]
}
function SimpleQuestion({question, answers} : SimpleQuestionProps) {
  return (
    <>
    <h3>{question}</h3>
    <RadioGroup
    name="radio-buttons-group"
    >
        {answers.map((answer, index)=> ( <FormControlLabel value={index} control={<Radio />} label={answer} />))}
    </RadioGroup>
    </>
  )
}

export default SimpleQuestion
