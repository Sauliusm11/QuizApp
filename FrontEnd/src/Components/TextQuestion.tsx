import { FormGroup, TextField } from "@mui/material"

interface TextQuestionProps{
    question : string
}
function TextQuestion({question} : TextQuestionProps) {
  return (
    <>
    <h3>{question}</h3>
    <FormGroup>
        <TextField id="outlined-basic" label="Answer" variant="outlined" />
    </FormGroup>
    </>
  )
}

export default TextQuestion
