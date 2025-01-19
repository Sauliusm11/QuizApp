import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormGroup from "@mui/material/FormGroup";
import { SyntheticEvent, useEffect, useState } from "react";

interface MultipleQuestionProps{
  question : string;
  answers : string[];
  parentCallback : Function;
}

function MultipleQuestion({question, answers, parentCallback} : MultipleQuestionProps) {

  const [selectedAnswers, setSelectedAnswers] = useState<{
    [k: number]: boolean;
  }>({});

  //Sends the updated set of answers to the parent
  const handleCheckboxChange = (event : SyntheticEvent<Element,Event>) => {
    let index : number = Number((event.currentTarget as HTMLInputElement).value);
    let checked : boolean = (event.currentTarget as HTMLInputElement).checked;
    let answer : string = (event.currentTarget as HTMLInputElement).value;
    //Gets all currently selected answers
    let answerIndexes : string[] =Object.entries(selectedAnswers)
    .filter(([_, isSelected]) => isSelected)
    .map(([index]) => index);

    if(checked){
      //If the answer is not selected add it to the list
      answerIndexes.push(answer);
    }
    else{
      //Else - remove it from the list
      answerIndexes = answerIndexes.filter((index) => index !== answer);
    }
    //Put the list of answers back together
    answer = answerIndexes.join(',');
    //Store the new list internaly
    setSelectedAnswers({
      ...selectedAnswers,
      [index]: checked,
    });
    //And send it to the parent
    parentCallback(answer);
  };
  //On remount, reset parent anwser string
  useEffect(() => {
      parentCallback("");
  }, []);

  return (
    <>
      <h3>{question}</h3>
      <FormGroup>
          {answers.map((answer, index)=> ( <FormControlLabel value={index} control={<Checkbox />} label={answer} onChange={handleCheckboxChange}/>))}
      </FormGroup>
    </>
  );
}

export default MultipleQuestion;
