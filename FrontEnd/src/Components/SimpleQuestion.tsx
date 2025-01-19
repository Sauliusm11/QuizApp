import FormControlLabel from "@mui/material/FormControlLabel";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import { SyntheticEvent, useEffect } from "react";

interface SimpleQuestionProps{
  question : string;
  answers : string[];
  parentCallback : Function;
}
function SimpleQuestion({question, answers, parentCallback} : SimpleQuestionProps) {

  const handleRadioChange = (event : SyntheticEvent<Element,Event>) => {
    let value : string = (event.currentTarget as HTMLInputElement).value;
    parentCallback(value);
  };
  
  useEffect(() => {
     parentCallback("0");
  }, []);
  return (
    <>
      <h3>{question}</h3>
      <RadioGroup
      defaultValue="0"
      name="radio-buttons-group"
      >
          {answers.map((answer, index)=> ( <FormControlLabel value={index} control={<Radio />} label={answer} onChange={handleRadioChange}/>))}
      </RadioGroup>
    </>
  );
}

export default SimpleQuestion;
