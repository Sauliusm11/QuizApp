import { Checkbox, FormControlLabel, FormGroup } from "@mui/material";
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
    const handleCheckboxChange = (event : SyntheticEvent<Element,Event>) => {
      let index : number = Number((event.currentTarget as HTMLInputElement).value);
      let checked : boolean = (event.currentTarget as HTMLInputElement).checked;
      let answer : string = (event.currentTarget as HTMLInputElement).value;
      let answerIndexes : string[] =Object.entries(selectedAnswers)
      .filter(([_, isSelected]) => isSelected)
      .map(([index]) => index);
      if(checked){
        answerIndexes.push(answer);
      }
      else{
        answerIndexes = answerIndexes.filter((index) => index !== answer);
      }

      answer = answerIndexes.join(',');
      setSelectedAnswers({
        ...selectedAnswers,
        [index]: checked,
      });
      parentCallback(answer);
    };
    
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
