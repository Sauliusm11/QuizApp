import FormGroup from "@mui/material/FormGroup";
import TextField from "@mui/material/TextField";
import { SyntheticEvent, useEffect } from "react";

interface TextQuestionProps{
  question : string;
  parentCallback : Function;
}
function TextQuestion({question, parentCallback} : TextQuestionProps) {
  //Sends the updated answer to the parent
  const handleTextChange = (event : SyntheticEvent<Element,Event>) => {
    let value : string = (event.currentTarget as HTMLInputElement).value;
    parentCallback(value);
  };
  //On remount, reset parent anwser string
  useEffect(() => {
      parentCallback("");
  }, []);
  return (
    <>
      <h3>{question}</h3>
      <FormGroup>
          <TextField id="outlined-basic" autoFocus label="Answer" variant="outlined" onChange={handleTextChange}/>
      </FormGroup>
    </>
  );
}

export default TextQuestion;
