import { FormGroup, TextField } from "@mui/material"
import { SyntheticEvent, useEffect } from "react";

interface TextQuestionProps{
    question : string
    parentCallback : Function
}
function TextQuestion({question, parentCallback} : TextQuestionProps) {

  const handleTextChange = (event : SyntheticEvent<Element,Event>) => {
    let value : string = (event.currentTarget as HTMLInputElement).value
    parentCallback(value)
  };

  useEffect(() => {
      parentCallback("")
    }, []);
  return (
    <>
    <h3>{question}</h3>
    <FormGroup>
        <TextField id="outlined-basic" autoFocus label="Answer" variant="outlined" onChange={handleTextChange}/>
    </FormGroup>
    </>
  )
}

export default TextQuestion
